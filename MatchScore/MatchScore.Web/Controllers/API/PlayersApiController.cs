using System;
using System.IO;
using System.Linq;
using AutoMapper;
using MatchScore.Data.Constants;
using MatchScore.Data.Models;
using MatchScore.Data.Models.QueryParameters;
using MatchScore.Exceptions;
using MatchScore.Services.Services.Contracts;
using MatchScore.Web.ViewModels.PlayerViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MatchScore.Web.Controllers.API
{
    [Route("api/players")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class PlayersApiController : ControllerBase
    {
        private readonly IPlayersService playersService;
        private readonly ISportsClubsService sportsClubsService;
        private readonly IUsersService usersService;
        private readonly IMapper mapper;

        public PlayersApiController(IPlayersService playersService,
            ISportsClubsService sportsClubsService, IUsersService usersService,
            IMapper mapper)
		{
            this.playersService = playersService;
            this.sportsClubsService = sportsClubsService;
            this.usersService = usersService;
            this.mapper = mapper;
		}

        [AllowAnonymous]
        [HttpGet("")]
        public IActionResult Get([FromQuery] PlayerQueryParameters parameters)
        {
            try
            {
                var players = this.playersService.FilterBy(parameters);

                var playersVM = players.Select(p => mapper.Map<PlayerShortVM>(p)).ToList();
       
                return this.StatusCode(StatusCodes.Status200OK, playersVM);
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
                var player = this.playersService.GetById(id);
                var playerVM = mapper.Map<PlayerDetailsVM>(player);
                return this.StatusCode(StatusCodes.Status200OK, playerVM);
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
        public IActionResult Post([FromBody] PlayerCreateVM playerVM)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return this.StatusCode(StatusCodes.Status406NotAcceptable, Messages.InvalidInfo);
                }

                Player player = this.mapper.Map<Player>(playerVM);
                player.SportsClub = this.sportsClubsService.GetById(playerVM.SportsClubId);
                var user = this.usersService.GetByUsername(User.Claims.FirstOrDefault(c => c.Type.Equals("username")).Value);

                if (playerVM.Photo != null)
                {
                    var ms = new MemoryStream();
                    playerVM.Photo.CopyTo(ms);
                    var bytes = ms.ToArray();
                    player.Photo = bytes;
                }

                var createdPlayer = this.playersService.Create(player, user);
                var createdPlayerVM = mapper.Map<PlayerDetailsVM>(createdPlayer);
                return this.StatusCode(StatusCodes.Status200OK, createdPlayerVM);
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
        public IActionResult Put(int id, [FromBody] PlayerEditVM playerVM)
        {
            if (!this.ModelState.IsValid)
            {
                return this.StatusCode(StatusCodes.Status406NotAcceptable, Messages.InvalidInfo);
            }

            try
            {
                var playerWithUpdates = this.mapper.Map<Player>(playerVM);
                playerWithUpdates.PlayerId = id;

                var user = this.usersService.GetByUsername(User.Claims.FirstOrDefault(c => c.Type.Equals("username")).Value);

                if (playerVM.Photo != null)
                {
                    var ms = new MemoryStream();
                    playerVM.Photo.CopyTo(ms);
                    var bytes = ms.ToArray();
                    playerWithUpdates.Photo = bytes;
                }

                var updatedPlayer = this.playersService.Update(playerWithUpdates, user);
                var updatedPlayerVM = this.mapper.Map<PlayerDetailsVM>(updatedPlayer);
                return this.StatusCode(StatusCodes.Status200OK, updatedPlayerVM);
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
                this.playersService.Delete(id, user);
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
            catch (DeleteConnectedEntityException ex)
            {
                return this.StatusCode(StatusCodes.Status403Forbidden, ex.Message);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
    }
}

