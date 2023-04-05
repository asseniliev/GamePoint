using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MatchScore.Data.Constants;
using MatchScore.Data.Models;
using MatchScore.Data.Models.QueryParameters;
using MatchScore.Exceptions;
using MatchScore.Services.Services.Contracts;
using MatchScore.Web.ViewModels.PlayerViewModels;
using MatchScore.Web.ViewModels.SportsClubViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MatchScore.Web.Controllers.API
{
    [Route("api/sportsclubs")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class SportsClubsApiController : ControllerBase
    {
        private readonly ISportsClubsService sportsClubsService;
        private readonly IUsersService usersService;
        private readonly IMapper mapper;

        public SportsClubsApiController(ISportsClubsService sportsClubsService,
            IUsersService usersService, IMapper mapper)
        {
            this.sportsClubsService = sportsClubsService;
            this.usersService = usersService;
            this.mapper = mapper;
        }


        [AllowAnonymous]
        [HttpGet("")]
        public IActionResult Get()
        {
            try
            {
                var sportsClubs = this.sportsClubsService.GetAll();

                List<SportsClubDetailsVM> sportsClubsVMs = sportsClubs.Select(mapper.Map<SportsClubDetailsVM>).ToList();

                return this.StatusCode(StatusCodes.Status200OK, sportsClubsVMs);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var sportsClub = this.sportsClubsService.GetById(id);
                var sportsClubVM = mapper.Map<SportsClubDetailsVM>(sportsClub);
                return this.StatusCode(StatusCodes.Status200OK, sportsClubVM);
            }
            catch (EntityNotFoundException ex)
            {
                return this.StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }

        [HttpPost("")]
        public IActionResult Post([FromHeader] string name)
        {
            try
            {
                if (string.IsNullOrEmpty(name) || name.Length < 4 || name.Length > 40)
                {
                    return this.StatusCode(StatusCodes.Status406NotAcceptable, Messages.InvalidInfo);
                }

                var sportsClub = new SportsClub() { Name = name };
                var user = this.usersService.GetByUsername(User.Claims.FirstOrDefault(c => c.Type.Equals("username")).Value);

                var newClub = this.sportsClubsService.Create(sportsClub, user);
                var newClubVM = mapper.Map<SportsClubDetailsVM>(newClub);

                return this.StatusCode(StatusCodes.Status200OK, newClubVM);
            }
            catch (EntityNotFoundException ex)
            {
                return this.StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
            catch (UnauthorizedOperationException ex)
            {
                return this.StatusCode(StatusCodes.Status401Unauthorized, ex.Message);
            }
            catch (DuplicateEntityException ex)
            {
                return this.StatusCode(StatusCodes.Status409Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromHeader] string name)
        {
            try
            {
                if (string.IsNullOrEmpty(name) || name.Length < 4 || name.Length > 40)
                {
                    return this.StatusCode(StatusCodes.Status406NotAcceptable, Messages.InvalidInfo);
                }

                var sportsClubToUpdate = this.sportsClubsService.GetById(id);
                sportsClubToUpdate.Name = name;
                var user = this.usersService.GetByUsername(User.Claims.FirstOrDefault(c => c.Type.Equals("username")).Value);

                var updatedClub = this.sportsClubsService.Update(sportsClubToUpdate, user);
                var updatedClubVM = mapper.Map<SportsClubDetailsVM>(updatedClub);

                return this.StatusCode(StatusCodes.Status200OK, updatedClubVM);
            }
            catch (EntityNotFoundException ex)
            {
                return this.StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
            catch (UnauthorizedOperationException ex)
            {
                return this.StatusCode(StatusCodes.Status401Unauthorized, ex.Message);
            }
            catch (DuplicateEntityException ex)
            {
                return this.StatusCode(StatusCodes.Status409Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var user = this.usersService.GetByUsername(User.Claims.FirstOrDefault(c => c.Type.Equals("username")).Value);
                this.sportsClubsService.Delete(id, user);
                return this.StatusCode(StatusCodes.Status200OK);
            }
            catch (EntityNotFoundException ex)
            {
                return this.StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
            catch (UnauthorizedOperationException ex)
            {
                return this.StatusCode(StatusCodes.Status401Unauthorized, ex.Message);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
    }
}

