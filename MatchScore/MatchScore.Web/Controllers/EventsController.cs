using AutoMapper;
using MatchScore.Data.Constants;
using MatchScore.Data.Enums;
using MatchScore.Data.Helpers;
using MatchScore.Data.Models;
using MatchScore.Data.Models.QueryParameters;
using MatchScore.Exceptions;
using MatchScore.Services.Services;
using MatchScore.Services.Services.Contracts;
using MatchScore.Web.Helpers;
using MatchScore.Web.Helpers.Args;
using MatchScore.Web.ViewModels.EventViewModels;
using MatchScore.Web.ViewModels.MatchViewModels;
using MatchScore.Web.ViewModels.PlayerViewModels;
using MatchScore.Web.ViewModels.RankViewModels;
using MatchScore.Web.ViewModels.UserViewModels;
using MatchScore.Web.ViewModels.WeatherViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace MatchScore.Web.Controllers
{
    [Authorize]
    public class EventsController : Controller
    {
        #region State
        private readonly IEventsService eventsService;
        private readonly IMapper mapper;
        private readonly IUsersService usersService;
        private readonly ILocationsService locationsService;
        private readonly IPlayersService playersService;
        private readonly IRankingsService rankingsService;
        private readonly IScoreService scoreService;
        private readonly IMatchesService matchesService;
        private readonly IAwardsService awardsService;
        private readonly IHttpClientFactory httpClientFactory;
        private readonly EmailHelper emailHelper;

        public delegate void PlayerAddedEventHandler(object source, PlayerAddArgs args);

        public event PlayerAddedEventHandler PlayerAdded;

        public delegate void PlayerRemovedEventHandler(object source, PlayerRemoveArgs args);

        public event PlayerRemovedEventHandler PlayerRemoved;

        public delegate void PlayerAddedToMatchEventHandler(object source, PlayerAddToMatchArgs args);

        public event PlayerAddedToMatchEventHandler PlayerAddedToMatch;

        public EventsController(IEventsService eventsService,
                                IMapper mapper,
                                IUsersService userService,
                                ILocationsService locationsService,
                                IPlayersService playersService,
                                IRankingsService rankingsService,
                                IScoreService scoreService,
                                IMatchesService matchesService,
                                IAwardsService awardsService,
                                IHttpClientFactory httpClientFactory,
                                EmailHelper emailHelper)
        {
            this.eventsService = eventsService;
            this.mapper = mapper;
            this.usersService = userService;
            this.locationsService = locationsService;
            this.playersService = playersService;
            this.rankingsService = rankingsService;
            this.scoreService = scoreService;
            this.matchesService = matchesService;
            this.awardsService = awardsService;
            this.httpClientFactory = httpClientFactory;
            this.emailHelper = emailHelper;
        }
        #endregion

        #region Read Methods
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index(EventQueryParameters eventQueryParameters)
        {
            if (eventQueryParameters.SortBy == null)
            {
                this.ViewData["SortOrder"] = "";
            }
            else if (eventQueryParameters.IsHeader)
            {
                this.ViewData["SortOrder"] = string.IsNullOrEmpty(eventQueryParameters.SortOrder) ? "desc" : "";
            }

            this.ViewData["SortOrder"] = string.IsNullOrEmpty(eventQueryParameters.SortOrder) ? "desc" : "";

            this.ViewData["SortBy"] = eventQueryParameters.SortBy;

            PaginatedList<Event> events = this.eventsService.FilterBy(eventQueryParameters);

            List<EventLongVM> eventIndexVMs = events.Select(e => this.mapper.Map<EventLongVM>(e)).ToList();

            eventIndexVMs.ForEach(e => e.HasMatchesWithScores = this.scoreService.GetByEventId(e.EventId).Exists(s => s.PlayerScore != null));

            EventIndexVM eventListVM = new EventIndexVM
            {
                Events = eventIndexVMs,
                CurrentPage = events.CurrentPage,
                HasPrevPage = events.HasPrevPage,
                HasNextPage = events.HasNextPage
            };

            return this.View(eventListVM);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Details(int eventId)
        {
            try
            {
                var @event = this.eventsService.GetById(eventId);
                var eventVM = mapper.Map<EventDetailsVM>(@event);

                //players for knockout
                if (@event.EventType == EventTypes.Knockout)
                {
                    var allRanks = this.rankingsService.GetByIdWithDeleted(eventId);
                    eventVM.Ranking = allRanks.Select(r => this.mapper.Map<RankShortVM>(r)).ToList();
                }

                //get forecast
                var client = this.httpClientFactory.CreateClient();
                var hourlyForecast = new List<HourlyWeatherVM>();
                WeatherHelper.RunAsync(client, eventVM.LocationLatitude, eventVM.LocationLongitude, hourlyForecast).GetAwaiter().GetResult();
                var dailyForecast = WeatherHelper.GenerateDailyForecasts(hourlyForecast);
                eventVM.Forecast.Weather = dailyForecast;
                eventVM.Forecast.CurrentWeather = hourlyForecast.FirstOrDefault();

                //get scheme for knockout
                if (@event.EventType != EventTypes.Knockout)
                {
                    return View(eventVM);
                }

                MultiRoundEventVM knockoutVM = new MultiRoundEventVM();
                knockoutVM.EventId = @event.EventId;
                knockoutVM.EventEndDate = @event.EndDate;

                List<Match> allMatches = this.matchesService.GetAll().Where(m => m.EventId == @event.EventId).ToList();
                List<MatchDetailsVM> matchesVM = allMatches.Select(m => this.mapper.Map<Match, MatchDetailsVM>(m)).ToList();

                int numberOfPlayers = this.rankingsService.GetByIdWithDeleted(@event.EventId).Count;

                int roundMatchesCount = numberOfPlayers / 2;  //This is the number of matches in the first round

                int allMatchesIndex = 0; //Index for all the matches generated for the tournament

                int roundIndex = 0;  //Index for the matches within one round

                while (allMatchesIndex < matchesVM.Count)
                {
                    List<MatchDetailsVM> roundMatches = new List<MatchDetailsVM>(); //List of the matches for the current round within this iteration

                    //Loop over the number of matches within one round (i is the iterator for the matches)
                    for (int i = 0; i < roundMatchesCount; i++)
                    {
                        roundMatches.Add(matchesVM[allMatchesIndex]);

                        //For the current match -> check if score was already posted and if yes - put it in the list w/ matches with scores
                        if (this.scoreService.GetByMatchId(allMatches[allMatchesIndex].MatchId).Exists(s => s.PlayerScore != null))
                        {
                            knockoutVM.MatchIDsWithScores.Add(allMatches[allMatchesIndex].MatchId);
                        }

                        //For the current match -> check if subsequent match exists with score already saved and if yes - put it in the list of matches w/ dependencies
                        if (allMatchesIndex < matchesVM.Count - 1)  //We don't want to check the last match, which is with index (matchesVM.Count - 1)
                        {
                            List<Match> eventMatches = this.matchesService.GetAll().Where(m => m.EventId == knockoutVM.EventId).ToList();
                            Match nextMatch = EventsService.GetNextPlayersMatch(allMatches[allMatchesIndex], eventMatches);
                            if (this.scoreService.GetByMatchId(nextMatch.MatchId).Exists(s => s.PlayerScore != null))  //i.e. the next match has already recorded a score
                            {
                                knockoutVM.DependentMatchesIDs.Add(allMatches[allMatchesIndex].MatchId);
                            }
                        }
                        allMatchesIndex++;
                    }
                    knockoutVM.MatchScheme.Add(roundMatches);
                    roundIndex++;
                    roundMatchesCount /= 2;  // cut by two the number of the matches for the next round
                }

                //Add matches scores (if matches have been played)
                foreach (var match in matchesVM)
                {
                    List<Score> scores = this.scoreService.GetByMatchId(match.MatchId);


                    if (scores != null && scores.Count > 0)
                    {
                        List<double?> playersScore = new List<double?>();
                        playersScore.Add(scores[0].PlayerScore);
                        if (scores.Count > 1) playersScore.Add(scores[1].PlayerScore);
                        knockoutVM.MatchScores.Add(match.MatchId, playersScore);
                    }
                }

                eventVM.MultiRoundEvent = knockoutVM;

                return View(eventVM);
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

        #endregion

        #region CUD Methods        
        [HttpGet]
        public IActionResult Create(int locationId)
        {

            this.ViewData["EventTypes"] = this.GetEventTypes();
            this.ViewData["MatchTypes"] = this.GetMatchTypes();

            EventCreateVM eventVM = new EventCreateVM();

            //Seed list of available locations
            List<Location> availableLocations = this.locationsService.GetAll();

            //Seed coordinates
            List<string> coordinates = new List<string>();

            if (locationId != 0)
            {
                Location location = this.locationsService.GetById(locationId);
                coordinates = BingHelper.GetCoordinates(location.Country.ToString(), location.City);
                eventVM.LocationId = locationId;
            }
            else
            {
                coordinates.Add(availableLocations[0].Latitude);
                coordinates.Add(availableLocations[0].Longitude);
                eventVM.LocationId = availableLocations[0].LocationId;
            }

            this.ViewData["Coordinates"] = coordinates;
            return View(eventVM);
        }

        [HttpPost]
        public IActionResult Create(EventCreateVM eventVM)
        {
            if (!this.ModelState.IsValid)
            {
                this.ViewData["EventTypes"] = this.GetEventTypes();
                this.ViewData["MatchTypes"] = this.GetMatchTypes();

                Location location = this.locationsService.GetById(eventVM.LocationId);
                List<string> coordinates = new List<string>();
                coordinates.Add(location.Latitude);
                coordinates.Add(location.Longitude);
                this.ViewData["Coordinates"] = coordinates;
                return this.View(eventVM);
            }

            try
            {
                Event newEvent = this.mapper.Map<Event>(eventVM);
                User user = this.usersService.GetByUsername(User.Claims.FirstOrDefault(c => c.Type.Equals("Username")).Value);
                newEvent.DirectorId = user.UserId;
                Event createdEvent = this.eventsService.Create(newEvent, user);

                Award award = new Award();
                award.EventId = createdEvent.EventId;
                award.Rank = 1;
                this.awardsService.Create(award);

                award = new Award();
                award.EventId = createdEvent.EventId;
                award.Rank = 2;
                this.awardsService.Create(award);

                if (createdEvent.EventType == EventTypes.League)  //For league we maintain third place award as well
                {
                    award = new Award();
                    award.EventId = createdEvent.EventId;
                    award.Rank = 3;
                    this.awardsService.Create(award);
                }

                return RedirectToAction("Edit", "Events", new { eventId = createdEvent.EventId });
            }
            catch (UnauthorizedOperationException ex)
            {
                this.ModelState.AddModelError("Title", ex.Message);
                return RedirectToAction("Create", "Events");
            }
        }

        [HttpGet]
        public IActionResult GetCoordinates(int locationId)
        {
            Location location = this.locationsService.GetById(locationId);
            List<string> coordinates = BingHelper.GetCoordinates(location.Country.ToString(), location.City);
            return RedirectToAction("Create", "Events", new { coordinates = coordinates }); ;
        }

        [HttpGet]
        public IActionResult Edit(int eventId)
        {
            Event @event = this.eventsService.GetById(eventId);

            //eventMatches variable below is needed as this.playersService.GetAll() call below feeds it with matches, for some reason!
            List<Match> eventMatches = new List<Match>(@event.Matches);

            //Seed list to select players
            List<Player> playersSelectionList = this.playersService.GetAll().Where(ev => ev.IsTeam == @event.IsTeamEvent).ToList();
            List<Ranking> ranking = this.rankingsService.GetAll().Where(r => r.EventId == eventId).ToList();

            @event.Matches = eventMatches;

            Player player = new Player();
            //Below, we must remove from the players selection drop-down list
            //the players that are already added to the event (i.e. present in the "ranking")
            foreach (var rank in ranking)
            {
                player = this.playersService.GetById(rank.PlayerId);

                if (playersSelectionList.Contains(player))
                {
                    playersSelectionList.Remove(player);
                }
            }

            EventEditVM eventVM = this.mapper.Map<EventEditVM>(@event);
            eventVM.IsCompleted = @event.IsCompleted;

            //Seed list of scores -> will be used in the Edit view to get the player1 and player 2 for each match
            foreach (var match in eventVM.Matches)
            {
                List<Score> matchScores = new List<Score>();
                matchScores = this.scoreService.GetByMatchId(match.MatchId);
                eventVM.Scores.AddRange(matchScores);
            }

            if (eventVM.Scores.Exists(s => s.PlayerScore != null))
            {
                eventVM.HasMatchesWithScores = true;
            }

            eventVM.PlayersSelectionList = playersSelectionList;

            //Seed list of locations
            eventVM.Locations = this.locationsService.GetAll();

            //Seed list of awards
            eventVM.Awards = this.awardsService.GetByEventId(eventId);

            eventVM.HasCorrectNumberOfPlayers = this.IsNumberOfPlayersCorrect(eventVM.EventId);

            eventVM.CorrectNumberOfPlayersInfo = this.NumberOfPlayersInfo(eventVM.EventId);

            return this.View(eventVM);
        }

        [HttpPost]
        public IActionResult Edit(EventEditVM eventVM)
        {
            Event eventToChange = this.eventsService.GetById(eventVM.EventId);
            eventToChange.Title = eventVM.Title;
            eventToChange.StartDate = eventVM.StartDate;
            eventToChange.EndDate = eventVM.EndDate;

            User user = this.usersService.GetByUsername(User.Claims.FirstOrDefault(c => c.Type.Equals("Username")).Value);
            this.eventsService.Update(eventToChange, user);

            return RedirectToAction("Edit", "Events", new { eventId = eventVM.EventId });
        }

        [HttpGet]
        public IActionResult ManageCompletion(int eventId)
        {
            Event eventUpdates = this.eventsService.GetById(eventId);
            eventUpdates.IsCompleted = !eventUpdates.IsCompleted;

            if(eventUpdates.IsCompleted)
            {
                eventUpdates.ChampionId = this.rankingsService.GetAll().FirstOrDefault(r => r.EventId == eventId && r.Rank == 1).PlayerId;
            }
            else
            {
                eventUpdates.ChampionId = null;
            }

            User user = this.usersService.GetByUsername(User.Claims.FirstOrDefault(c => c.Type.Equals("Username")).Value);
            this.eventsService.Update(eventUpdates, user);

            return RedirectToAction("Edit", "Events", new { eventId });
        }


        [HttpGet]
        public IActionResult Brackets(int eventId)
        {
            Event @event = this.eventsService.GetById(eventId);
            string controller = "";
            string action = "";

            switch ((int)@event.EventType)
            {
                case 0:
                    controller = "SingleMatches";
                    break;
                case 1:
                    controller = "Knockouts";
                    break;
                case 2:
                    controller = "Leagues";
                    break;
            }

            if(@event.IsCompleted)
            {
                action = "Display";
            }
            else
            {
                action = "Edit";
            }


            return RedirectToAction(action, controller, new { eventId = eventId });
        }


        [HttpPost]
        public IActionResult AddPlayer(EventEditVM eventVM)
        {
            List<Ranking> ranking = this.rankingsService.GetAll().Where(r => !r.IsDeleted).ToList();
            List<Player> players = this.playersService.GetAll().Where(p => !p.IsInactive).ToList();
            //Event eventToChange = this.eventService.GetById(eventVM.EventId);

            Ranking newRanking = new Ranking()
            {
                EventId = eventVM.EventId,
                PlayerId = eventVM.PlayerId
            };
            this.rankingsService.Create(newRanking);

            //User user = this.userService.GetById(1);
            //this.eventService.Update(eventToChange, user);

            if (this.usersService.GetAll().FirstOrDefault(u => u.PlayerId == eventVM.PlayerId) != null)
            {
                this.PlayerAdded += this.emailHelper.OnPlayerAdded;

                this.OnPlayerAdded(eventVM);
            }

            return RedirectToAction("Edit", "Events", new { eventId = eventVM.EventId });
        }

        [HttpGet]
        public IActionResult RemovePlayer(int eventId, int playerId)
        {
            this.rankingsService.Delete(playerId, eventId);

            EventEditVM eventVM = this.mapper.Map<EventEditVM>(this.eventsService.GetById(eventId));

            if (this.usersService.GetAll().FirstOrDefault(u => u.PlayerId == eventVM.PlayerId) != null)
            {
                this.PlayerRemoved += this.emailHelper.OnPlayerRemoved;

                this.OnPlayerRemoved(eventVM, playerId);
            }
            return RedirectToAction("Edit", "Events", new { eventId = eventId });
        }

        [HttpPost]
        public IActionResult GenerateMatches(int eventId)
        {
            try
            {
                User user = this.usersService.GetByUsername(User.Claims.FirstOrDefault(c => c.Type.Equals("Username")).Value);
                this.eventsService.GenerateMatchScheme(eventId, user);

                EventEditVM eventVM = this.mapper.Map<EventEditVM>(this.eventsService.GetById(eventId));

                foreach (Match match in eventVM.Matches)
                {
                    foreach (Score score in match.Scores)
                    {
                        if (this.usersService.GetAll().FirstOrDefault(u => u.PlayerId == score.PlayerId) != null)
                        {
                            this.PlayerAddedToMatch += this.emailHelper.OnPlayerAddedToMatch;

                            this.OnPlayerAddedToMatch(eventVM, score);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return RedirectToAction("Edit", "Events", new { eventId = eventId });
        }

        [HttpPost]
        public IActionResult DeleteMatches(int eventId)
        {
            try
            {
                User user = this.usersService.GetByUsername(User.Claims.FirstOrDefault(c => c.Type.Equals("Username")).Value);
                this.eventsService.SuppressMatchScheme(eventId, user);
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction("Edit", "Events", new { eventId = eventId });
        }

        [HttpGet]
        public IActionResult Delete(int eventId)
        {
            try
            {
                User user = this.usersService.GetByUsername(User.Claims.FirstOrDefault(c => c.Type.Equals("Username")).Value);
                //this.eventService.SuppressMatchScheme(eventId, user);

                //List<Ranking> rankings = this.rankingsService.GetByIDs(eventId);
                //this.rankingsService.Delete(rankings);

                //List<Award> awards = this.awardsService.GetByEventId(eventId);
                //this.awardsService.Delete(awards);

                this.eventsService.Delete(eventId, user);
            }
            catch (Exception)
            {

                throw;
            }
            return RedirectToAction("Index", "Events", new { eventId = eventId });
        }
        #endregion

        #region Private Methods
        private SelectList GetEventTypes()
        {
            var eventTypes = from EventTypes types in Enum.GetValues(typeof(EventTypes))
                             select new
                             {
                                 Id = (int)types,
                                 Name = types.ToString()
                             };

            return new SelectList(eventTypes, "Id", "Name");
        }

        private SelectList GetMatchTypes()
        {
            //Seed list of match types
            var matchTypes = from MatchTypes types in Enum.GetValues(typeof(MatchTypes))
                             select new
                             {
                                 Id = (int)types,
                                 Name = types.ToString()
                             };

            return new SelectList(matchTypes, "Id", "Name");
        }

        private bool IsNumberOfPlayersCorrect(int eventId)
        {
            Event @event = this.eventsService.GetById(eventId);
            int numberOfPlayers = this.rankingsService.GetAll().Where(r => !r.IsDeleted && r.EventId == eventId).ToList().Count();

            switch(@event.EventType)
            {
                case EventTypes.SingleMatch:
                    {
                        if (numberOfPlayers != 2)
                            return false;
                        break;
                    }
                case EventTypes.League:
                    {
                        if (numberOfPlayers < 4 || (numberOfPlayers % 2 != 0))
                            return false;
                        break;
                    }
                case EventTypes.Knockout:
                    {
                        if (Math.Log2(numberOfPlayers) % 1 != 0 || numberOfPlayers < 4)
                            return false;
                        break;
                    }
                default:
                    return false;
            }
            return true;
        }

        private string NumberOfPlayersInfo(int eventId)
        {
            Event @event = this.eventsService.GetById(eventId);

            switch (@event.EventType)
            {
                case EventTypes.SingleMatch:
                    {
                        return string.Format(Messages.PlayersNotProperlyAssigned, "exactly", 2);
                    }
                case EventTypes.League:
                    {
                        return string.Format(Messages.PlayersNotProperlyAssigned, "even number of players and minimum", 4);
                    }
                case EventTypes.Knockout:
                    {
                        return string.Format(Messages.PlayersNotProperlyAssigned, "4 or 8 or 16...", "or any other power of 2 ");
                    }
                default:
                    return "";
            }
        }

        private void OnPlayerAdded(EventEditVM eventVM)
        {
            if (PlayerAdded != null)
            {
                PlayerAdded(this, new PlayerAddArgs()
                {
                    @event = this.eventsService.GetById(eventVM.EventId),
                    User = this.usersService.GetAll().FirstOrDefault(u => u.PlayerId == eventVM.PlayerId),
                    Player = this.playersService.GetById(eventVM.PlayerId)
                });
            }
        }

        private void OnPlayerRemoved(EventEditVM eventVM, int playerId)
        {
            if (PlayerRemoved != null)
            {
                PlayerRemoved(this, new PlayerRemoveArgs()
                {
                    @event = this.eventsService.GetById(eventVM.EventId),
                    User = this.usersService.GetAll().FirstOrDefault(u => u.PlayerId == playerId),
                    Player = this.playersService.GetById(playerId)
                });
            }
        }

        private void OnPlayerAddedToMatch(EventEditVM eventVM, Score score)
        {
            if (PlayerAddedToMatch != null)
            {
                PlayerAddedToMatch(this, new PlayerAddToMatchArgs()
                {
                    @event = this.eventsService.GetById(eventVM.EventId),
                    User = this.usersService.GetAll().FirstOrDefault(u => u.PlayerId == score.PlayerId),
                    Player = this.playersService.GetById(score.PlayerId)
                });
            }
        }
        #endregion  
    }
}
