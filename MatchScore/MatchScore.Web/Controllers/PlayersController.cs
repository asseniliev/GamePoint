using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using AutoMapper;
using EnumsNET;
using MatchScore.Data.Enums;
using MatchScore.Data.Helpers;
using MatchScore.Data.Models;
using MatchScore.Data.Models.QueryParameters;
using MatchScore.Exceptions;
using MatchScore.Services.Services.Contracts;
using MatchScore.Web.ViewModels.EventViewModels;
using MatchScore.Web.ViewModels.PlayerViewModels;
using MatchScore.Web.ViewModels.SportsClubViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MatchScore.Web.Controllers
{
    [Authorize]
    public class PlayersController : Controller
    {
        private readonly IPlayersService playerService;
        private readonly ISportsClubsService sportsClubsService;
        private readonly IUsersService usersService;
        private readonly IRankingsService rankingsService;
        private readonly IEventsService eventsService;
        private readonly IMapper mapper;

        public PlayersController(IPlayersService playerService,
            ISportsClubsService sportsClubsService, IUsersService usersService,
            IRankingsService rankingsService, IEventsService eventsService,
            IMapper mapper)
        {
            this.playerService = playerService;
            this.sportsClubsService = sportsClubsService;
            this.usersService = usersService;
            this.rankingsService = rankingsService;
            this.eventsService = eventsService;
            this.mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index(PlayerQueryParameters parameters)
        {
            try
            {
                var players = this.playerService.FilterBy(parameters);

                var playersVM = players.Select(p => mapper.Map<PlayerShortVM>(p)).ToList();
                var playersIndexVM = new PlayersIndexVM()
                {
                    Players = playersVM,
                    HasNextPage = players.HasNextPage,
                    HasPrevPage = players.HasPrevPage,
                    CurrentPage = players.CurrentPage
                };
                return View(playersIndexVM);
            }
            catch (Exception ex)
            {
                this.Response.StatusCode = StatusCodes.Status400BadRequest;
                this.ViewData["ErrorMessage"] = ex.Message;
                return this.View("Error");
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Details([FromRoute] int id)
        {
            try
            {
                var player = this.playerService.GetById(id);
                var playerVM = mapper.Map<PlayerDetailsVM>(player);
                return View(playerVM);
            }
            catch (EntityNotFoundException ex)
            {
                this.Response.StatusCode = StatusCodes.Status404NotFound;
                this.ViewData["ErrorMessage"] = ex.Message;
                return this.View("Error");
            }
            catch (Exception ex)
            {
                this.Response.StatusCode = StatusCodes.Status400BadRequest;
                this.ViewData["ErrorMessage"] = ex.Message;
                return this.View("Error");
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            try
            {
                var playerVM = new PlayerCreateVM();
                playerVM.SportsClubs = this.sportsClubsService.GetAll().OrderBy(sc => sc.Name).Select(sc => mapper.Map<SportsClubDetailsVM>(sc)).ToList();
                return this.View(playerVM);
            }
            catch (Exception ex)
            {
                this.Response.StatusCode = StatusCodes.Status400BadRequest;
                this.ViewData["ErrorMessage"] = ex.Message;
                return this.View("Error");
            }

        }

        [HttpPost]
        public IActionResult Create(PlayerCreateVM playerVM)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    playerVM.SportsClubs = this.sportsClubsService.GetAll().OrderBy(sc => sc.Name).Select(sc => mapper.Map<SportsClubDetailsVM>(sc)).ToList();
                    return this.View(playerVM);
                }

                Player player = this.mapper.Map<Player>(playerVM);
                player.SportsClub = this.sportsClubsService.GetById(playerVM.SportsClubId);
                var user = this.usersService.GetByUsername(User.Claims.FirstOrDefault(c => c.Type.Equals("Username")).Value);

                if (playerVM.Photo != null)
                {
                    var ms = new MemoryStream();
                    playerVM.Photo.CopyTo(ms);
                    var bytes = ms.ToArray();
                    player.Photo = bytes;
                }

                var createdPlayer = this.playerService.Create(player, user);
                return this.RedirectToAction("Details", "Players", new { id = createdPlayer.PlayerId });
            }
            catch (UnauthorizedOperationException ex)
            {
                this.Response.StatusCode = StatusCodes.Status401Unauthorized;
                this.ViewData["ErrorMessage"] = ex.Message;
                return this.View("Error");
            }
            catch (DuplicateEntityException ex)
            {
                this.Response.StatusCode = StatusCodes.Status409Conflict;
                this.ViewData["ErrorMessage"] = ex.Message;
                return this.View("Error");
            }
            catch (Exception ex)
            {
                this.Response.StatusCode = StatusCodes.Status400BadRequest;
                this.ViewData["ErrorMessage"] = ex.Message;
                return this.View("Error");
            }
        }

        [HttpGet]
        public IActionResult Edit([FromRoute] int id)
        {
            try
            {
                var player = this.playerService.GetById(id);
                var playerVM = mapper.Map<PlayerEditVM>(player);
                playerVM.SportsClubs = this.sportsClubsService.GetAll().OrderBy(sc => sc.Name).Select(sc => mapper.Map<SportsClubDetailsVM>(sc)).ToList();

                return View(playerVM);
            }
            catch (EntityNotFoundException ex)
            {
                this.Response.StatusCode = StatusCodes.Status404NotFound;
                this.ViewData["ErrorMessage"] = ex.Message;
                return this.View("Error");
            }
            catch (Exception ex)
            {
                this.Response.StatusCode = StatusCodes.Status400BadRequest;
                this.ViewData["ErrorMessage"] = ex.Message;
                return this.View("Error");
            }
        }

        [HttpPost]
        public IActionResult Edit([FromRoute] int id, PlayerEditVM playerVM)
        {
            if (!this.ModelState.IsValid)
            {
                playerVM.SportsClubs = this.sportsClubsService.GetAll().OrderBy(sc => sc.Name).Select(sc => mapper.Map<SportsClubDetailsVM>(sc)).ToList();
                return this.View(playerVM);
            }

            try
            {
                var playerWithUpdates = this.mapper.Map<Player>(playerVM);
                var user = this.usersService.GetByUsername(User.Claims.FirstOrDefault(c => c.Type.Equals("Username")).Value);

                if (playerVM.Photo != null)
                {
                    var ms = new MemoryStream();
                    playerVM.Photo.CopyTo(ms);
                    var bytes = ms.ToArray();
                    playerWithUpdates.Photo = bytes;
                }

                var updatedPlayer = this.playerService.Update(playerWithUpdates, user);
                var updatedPlayerVM = this.mapper.Map<PlayerDetailsVM>(updatedPlayer);

                return this.RedirectToAction("Details", "Players", new { id = updatedPlayerVM.PlayerId });
            }
            catch (EntityNotFoundException ex)
            {
                this.Response.StatusCode = StatusCodes.Status404NotFound;
                this.ViewData["ErrorMessage"] = ex.Message;
                return this.View("Error");
            }
            catch (UnauthorizedOperationException ex)
            {
                this.Response.StatusCode = StatusCodes.Status401Unauthorized;
                this.ViewData["ErrorMessage"] = ex.Message;
                return this.View("Error");
            }
            catch (DuplicateEntityException ex)
            {
                this.Response.StatusCode = StatusCodes.Status409Conflict;
                this.ViewData["ErrorMessage"] = ex.Message;
                return this.View("Error");
            }
            catch (Exception ex)
            {
                this.Response.StatusCode = StatusCodes.Status400BadRequest;
                this.ViewData["ErrorMessage"] = ex.Message;
                return this.View("Error");
            }
        }

        [HttpGet]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                var player = this.playerService.GetById(id);
                var playerVM = mapper.Map<PlayerDeleteVM>(player);
                return View(playerVM);
            }
            catch (EntityNotFoundException ex)
            {
                this.Response.StatusCode = StatusCodes.Status404NotFound;
                this.ViewData["ErrorMessage"] = ex.Message;
                return this.View("Error");
            }
            catch (Exception ex)
            {
                this.Response.StatusCode = StatusCodes.Status400BadRequest;
                this.ViewData["ErrorMessage"] = ex.Message;
                return this.View("Error");
            }
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed([FromRoute] int id)
        {

            try
            {
                var user = this.usersService.GetByUsername(User.Claims.FirstOrDefault(c => c.Type.Equals("Username")).Value);
                this.playerService.Delete(id, user);
                return View(new PlayerDeleteVM() { Deleted = true });
            }
            catch (EntityNotFoundException ex)
            {
                this.Response.StatusCode = StatusCodes.Status404NotFound;
                this.ViewData["ErrorMessage"] = ex.Message;
                return this.View("Error");
            }
            catch (UnauthorizedOperationException ex)
            {
                this.Response.StatusCode = StatusCodes.Status401Unauthorized;
                this.ViewData["ErrorMessage"] = ex.Message;
                return this.View("Error");
            }
            catch (DeleteConnectedEntityException ex)
            {
                this.Response.StatusCode = StatusCodes.Status403Forbidden;
                this.ViewData["ErrorMessage"] = ex.Message;
                return this.View("Error");
            }
            catch (Exception ex)
            {
                this.Response.StatusCode = StatusCodes.Status400BadRequest;
                this.ViewData["ErrorMessage"] = ex.Message;
                return this.View("Error");
            }
        }


        [HttpPost]
        public IActionResult CreateFromEvent(EventEditVM eventVM)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return this.RedirectToAction("Edit", "Events", new { eventId = eventVM.EventId });
                }

                Player player = new Player() { Name = eventVM.NewPlayerName};
                var @event = this.eventsService.GetById(eventVM.EventId);
                player.IsTeam = @event.IsTeamEvent;
                var user = this.usersService.GetByUsername(User.Claims.FirstOrDefault(c => c.Type.Equals("Username")).Value);
                var createdPlayer = this.playerService.Create(player, user);

                //add player to event
                Ranking newRanking = new Ranking()
                {
                    EventId = eventVM.EventId,
                    PlayerId = createdPlayer.PlayerId
                };
                this.rankingsService.Create(newRanking);

                return this.RedirectToAction("Edit", "Events", new { eventId = eventVM.EventId });
            }
            catch (UnauthorizedOperationException ex)
            {
                this.Response.StatusCode = StatusCodes.Status401Unauthorized;
                this.ViewData["ErrorMessage"] = ex.Message;
                return this.View("Error");
            }
            catch (DuplicateEntityException ex)
            {
                this.Response.StatusCode = StatusCodes.Status409Conflict;
                this.ViewData["ErrorMessage"] = ex.Message;
                return this.View("Error");
            }
            catch (Exception ex)
            {
                this.Response.StatusCode = StatusCodes.Status400BadRequest;
                this.ViewData["ErrorMessage"] = ex.Message;
                return this.View("Error");
            }
        }
    }
}

