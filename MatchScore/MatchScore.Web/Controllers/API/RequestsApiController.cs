using AutoMapper;
using MatchScore.Data.Constants;
using MatchScore.Data.Enums;
using MatchScore.Data.Models;
using MatchScore.Data.Models.QueryParameters;
using MatchScore.Exceptions;
using MatchScore.Services.Services.Contracts;
using MatchScore.Web.DTOs.RequestDTOs;
using MatchScore.Web.DTOs.UserDTOs;
using MatchScore.Web.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using static MatchScore.Data.Constants.Messages;
using Request = MatchScore.Data.Models.Request;
using User = MatchScore.Data.Models.User;

namespace MatchScore.Web.Controllers.API
{
    [Route("api/requests")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class RequestsApiController : ControllerBase
    {
        private readonly IRequestsService requestsService;
        private readonly IUsersService usersService;
        private readonly IMapper mapper;
        private readonly AuthHelper authHelper;

        public RequestsApiController(IRequestsService requestsService, IUsersService usersService, IMapper mapper, AuthHelper authHelper)
        {
            this.requestsService = requestsService;
            this.usersService = usersService;
            this.mapper = mapper;
            this.authHelper = authHelper;
        }

        [HttpPost]
        public IActionResult Create([FromBody] RequestPostDto requestPostDto)
        {
            Request newRequest = this.mapper.Map<Request>(requestPostDto);

            this.requestsService.Create(newRequest);

            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpGet]
        public IActionResult GetRequests([FromQuery] RequestQueryParameters requestQueryParameters)
        {
            List<RequestGetDto> requestsToGet = this.requestsService.FilterBy(requestQueryParameters)
                .Select(r => this.mapper.Map<RequestGetDto>(r)).ToList();

            return StatusCode(StatusCodes.Status200OK, requestsToGet);
        }

        [AllowAnonymous]
        [HttpGet("{requestId}")]
        public IActionResult GetById(int requestId)
        {
            try
            {
                RequestGetDto userToGet = this.mapper.Map<RequestGetDto>(this.requestsService.GetById(requestId));

                if (userToGet != null)
                {
                    return StatusCode(StatusCodes.Status200OK, userToGet);
                }

                throw new EntityNotFoundException(string.Format(Messages.DoesNotExistErrorLong, "Request", "Id", requestId));
            }
            catch (EntityNotFoundException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }

        [HttpPut("{requestId}")]
        public IActionResult Update([FromHeader] string credentials, int requestId, [FromBody] RequestPutDto requestPutDto)
        {
            string[] credentialsString = this.authHelper.ProcessCredentials(credentials);

            try
            {
                User user = this.usersService.GetByUsername(credentialsString[0]);

                if (!this.authHelper.VerifyPasswordHash(credentialsString[1], user.PasswordSalt, user.PasswordHash))
                {
                    throw new UnauthorizedOperationException(string.Format(UnauthenticatedError));
                }

                if (!user.Role.Equals(Roles.Admin))
                {
                    throw new UnauthorizedOperationException(string.Format(AdminRequiredError, "update", "requests"));
                }

                Request requestUpdates = this.mapper.Map<Request>(requestPutDto);

                Request updatedRequest = this.requestsService.Update(requestId, requestUpdates);

                return StatusCode(StatusCodes.Status200OK, updatedRequest);
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

        [HttpDelete("{requestId}")]
        public IActionResult Delete([FromHeader] string credentials, int requestId)
        {
            string[] credentialsString = this.authHelper.ProcessCredentials(credentials);

            try
            {
                User user = this.usersService.GetByUsername(credentialsString[0]);

                if (!this.authHelper.VerifyPasswordHash(credentialsString[1], user.PasswordSalt, user.PasswordHash))
                {
                    throw new UnauthorizedOperationException(string.Format(UnauthenticatedError));
                }

                if (!user.Role.Equals(Roles.Admin))
                {
                    throw new UnauthorizedOperationException(string.Format(AdminRequiredError, "delete", "requests"));
                }

                this.requestsService.Delete(requestId);

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
