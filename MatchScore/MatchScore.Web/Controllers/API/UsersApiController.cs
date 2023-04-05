using AutoMapper;
using MatchScore.Data.Constants;
using MatchScore.Data.Models.QueryParameters;
using MatchScore.Exceptions;
using MatchScore.Services.Services.Contracts;
using MatchScore.Web.DTOs.UserDTOs;
using MatchScore.Web.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using User = MatchScore.Data.Models.User;

namespace MatchScore.Web.Controllers.API
{
    [Route("api/users")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class UsersApiController : ControllerBase
    {
        private readonly IUsersService usersService;
        private readonly IMapper mapper;
        private readonly AuthHelper authHelper;

        public UsersApiController(IUsersService usersService, IMapper mapper, AuthHelper authHelper)
        {
            this.usersService = usersService;
            this.mapper = mapper;
            this.authHelper = authHelper;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Create([FromBody] UserPostDto userPostDto)
        {
            try
            {
                if (usersService.GetByUsername(userPostDto.Username) != null)
                {
                    throw new DuplicateEntityException(string.Format(Messages.AlreadyExistsError, "User", "username", userPostDto.Username));
                }

                authHelper.CreatePasswordHash(userPostDto.Password, out byte[] passwordSalt, out byte[] passwordHash);

                User newUser = mapper.Map<User>(userPostDto);

                newUser.PasswordSalt = passwordSalt;

                newUser.PasswordHash = passwordHash;

                UserGetDto createdUser = mapper.Map<UserGetDto>(usersService.Create(newUser));

                return StatusCode(StatusCodes.Status200OK, createdUser);
            }

            catch (DuplicateEntityException ex)
            {
                return StatusCode(StatusCodes.Status409Conflict, ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromHeader] string credentials)
        {
            string[] credentialsString = this.authHelper.ProcessCredentials(credentials);

            try
            {
                User user = this.usersService.GetByUsername(credentialsString[0]);

                if (user == null)
                {
                    throw new EntityNotFoundException(string.Format(Messages.DoesNotExistErrorLong, "User", "username", credentialsString[0]));
                }

                if (!this.authHelper.VerifyPasswordHash(credentialsString[1], user.PasswordSalt, user.PasswordHash))
                {
                    throw new UnauthorizedOperationException(string.Format(Messages.UnauthenticatedError));
                }

                string jwtTokenString = authHelper.CreateToken(user);

                return StatusCode(StatusCodes.Status200OK, jwtTokenString);
            }
            catch (EntityNotFoundException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
            catch (UnauthorizedOperationException ex)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetUsers([FromQuery] UserQueryParameters userQueryParameters)
        {
            List<UserGetDto> usersToGet = this.usersService.FilterBy(userQueryParameters).Select(u => this.mapper.Map<UserGetDto>(u)).ToList();

            return StatusCode(StatusCodes.Status200OK, usersToGet);

        }

        [AllowAnonymous]
        [HttpGet("{userId}")]
        public IActionResult GetById(int userId)
        {
            try
            {
                UserGetDto userToGet = this.mapper.Map<UserGetDto>(this.usersService.GetById(userId));

                if (userToGet != null)
                {
                    return StatusCode(StatusCodes.Status200OK, userToGet);
                }

                throw new EntityNotFoundException(string.Format(Messages.DoesNotExistErrorLong, "User", "Id", userId));
            }
            catch (EntityNotFoundException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }

        [HttpPut("{userId}")]
        public IActionResult Update([FromHeader] string credentials, int userId, [FromBody] UserPutDto userPutDto)
        {
            string[] credentialsString = this.authHelper.ProcessCredentials(credentials);

            try
            {
                User user = this.usersService.GetById(userId);

                if (!this.authHelper.VerifyPasswordHash(credentialsString[1], user.PasswordSalt, user.PasswordHash))
                {
                    throw new UnauthorizedOperationException(string.Format(Messages.UnauthenticatedError));
                }

                User userUpdates = this.mapper.Map<User>(userPutDto);

                this.usersService.Update(userId, userUpdates);

                return StatusCode(StatusCodes.Status200OK);
            }
            catch (EntityNotFoundException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
            catch (UnauthorizedOperationException ex)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, ex.Message);
            }
        }

        [HttpDelete("{userId}")]
        public IActionResult Delete([FromHeader] string credentials, int userId)
        {
            string[] credentialsString = this.authHelper.ProcessCredentials(credentials);

            try
            {
                User user = this.usersService.GetById(userId);

                if (!this.authHelper.VerifyPasswordHash(credentialsString[1], user.PasswordSalt, user.PasswordHash))
                {
                    throw new UnauthorizedOperationException(string.Format(Messages.UnauthenticatedError));
                }

                this.usersService.Delete(userId);

                return StatusCode(StatusCodes.Status200OK);
            }
            catch (EntityNotFoundException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
            catch (UnauthorizedOperationException ex)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, ex.Message);
            }
        }
    }
}
