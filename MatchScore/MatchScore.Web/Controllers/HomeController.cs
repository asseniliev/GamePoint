using System.Linq;
using AutoMapper;
using MatchScore.Data.Models.QueryParameters;
using MatchScore.Services.Services.Contracts;
using MatchScore.Web.ViewModels.EventViewModels;
using MatchScore.Web.ViewModels.HomeViewModels;
using MatchScore.Web.ViewModels.MatchViewModels;
using MatchScore.Web.ViewModels.PlayerViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MatchScore.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IEventsService eventService;
        private readonly IMatchesService matchesService;
        private readonly IPlayersService playersService;
        private readonly IMapper mapper;

        public HomeController(IEventsService eventService,
            IMatchesService matchesService, IPlayersService playersService,
            IMapper mapper)
        {
            this.eventService = eventService;
            this.matchesService = matchesService;
            this.playersService = playersService;
            this.mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            var homeView = new HomeIndexVM();

            homeView.LatestEvents = eventService.GetLatestEvents()
                .Select(e => mapper.Map<EventShortVM>(e)).ToList();

            homeView.FutureEvents = eventService.GetFutureEvents()
                .Select(e => mapper.Map<EventShortVM>(e)).ToList();

            homeView.LatestMatches = matchesService.GetLatestMatches()
                .Select(m => mapper.Map<MatchShortVM>(m)).ToList();

            homeView.FutureMatches = matchesService.GetFutureMatches()
                .Select(m => mapper.Map<MatchShortVM>(m)).ToList();

            homeView.PlayerRanklist = playersService
                .FilterBy(new PlayerQueryParameters { SortBy = "wins", SortOrder = "desc" })
                .Take(10).Select(p => mapper.Map<PlayerShortVM>(p)).ToList();

            return View(homeView);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult About()
        {
            return View();
        }
    }
}
