using System;
using System.Linq;
using AutoMapper;
using MatchScore.Data.Models;
using MatchScore.Exceptions;
using MatchScore.Services.Services.Contracts;
using MatchScore.Web.ViewModels.PlayerViewModels;
using MatchScore.Web.ViewModels.SportsClubViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MatchScore.Web.Controllers
{
    [Authorize]
    public class SportsClubsController : Controller
    {
        private readonly ISportsClubsService clubsService;
        private readonly IUsersService usersService;
        private readonly IMapper mapper;

        public SportsClubsController(ISportsClubsService clubsService,
            IUsersService usersService, IMapper mapper)
        {
            this.clubsService = clubsService;
            this.usersService = usersService;
            this.mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Details([FromRoute] int id)
        {
            try
            {
                SportsClub sportsClub = this.clubsService.GetById(id);
                var sportsClubVM = mapper.Map<SportsClubDetailsVM>(sportsClub);
                return View(sportsClubVM);
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
        public IActionResult Create(PlayerEditVM playerVM)
        {
            try
            {
                var sportsClub = new SportsClub() { Name = playerVM.NewSportsClub};
                var user = this.usersService.GetByUsername(User.Claims.FirstOrDefault(c => c.Type.Equals("Username")).Value);
                this.clubsService.Create(sportsClub, user);

                if (playerVM.View == "edit")
                {
                    return this.RedirectToAction("Edit", "Players", new { id = playerVM.PlayerId});
                }
                return this.RedirectToAction("Create", "Players");
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
    }
}

