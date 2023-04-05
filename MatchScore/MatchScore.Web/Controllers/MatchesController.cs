using AutoMapper;
using MatchScore.Data.Models;
using MatchScore.Data.Models.QueryParameters;
using MatchScore.Exceptions;
using MatchScore.Services.Services.Contracts;
using MatchScore.Web.Helpers;
using MatchScore.Web.ViewModels.MatchViewModels;
using MatchScore.Web.ViewModels.WeatherViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using MatchScore.Web.ViewModels.EventViewModels;
using MatchScore.Web.Helpers.Args;

namespace MatchScore.Web.Controllers
{
    [Authorize]
    public class MatchesController : Controller
    {
        private readonly IMatchesService matchesService;
        private readonly IEventsService eventsService;
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IMapper mapper;
        private readonly IUsersService usersService;
        private readonly EmailHelper emailHelper;

        public delegate void MatchUpdatedEventHandler(object source, MatchUpdatedArgs args);

        public event MatchUpdatedEventHandler MatchUpdated;

        public MatchesController(IMatchesService matchesService, IEventsService eventsService,
            IHttpClientFactory httpClientFactory, IMapper mapper, IUsersService usersService, EmailHelper emailHelper)
        {
            this.matchesService = matchesService;
            this.eventsService = eventsService;
            this.httpClientFactory = httpClientFactory;
            this.mapper = mapper;
            this.usersService = usersService;
            this.emailHelper = emailHelper;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index(MatchQueryParameters parameters)
        {
            try
            {
                    var matches = this.matchesService.FilterBy(parameters);

                var matchesVM = matches.Select(m => mapper.Map<MatchShortVM>(m)).ToList();
                var matchesIndexVM = new MatchIndexVM()
                {
                    Matches = matchesVM,
                    HasNextPage = matches.HasNextPage,
                    HasPrevPage = matches.HasPrevPage,
                    CurrentPage = matches.CurrentPage
                };
                return View(matchesIndexVM);
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
                var match = this.matchesService.GetById(id);
                var matchVM = mapper.Map<MatchDetailsVM>(match);

                //get forecast
                var client = this.httpClientFactory.CreateClient();
                var hourlyForecast = new List<HourlyWeatherVM>();
                WeatherHelper.RunAsync(client, matchVM.LocationLatitude, matchVM.LocationLongitude, hourlyForecast).GetAwaiter().GetResult();
                var dailyForecast = WeatherHelper.GenerateDailyForecasts(hourlyForecast);
                matchVM.Forecast.Weather = dailyForecast;
                matchVM.Forecast.CurrentWeather = hourlyForecast.FirstOrDefault();

                return View(matchVM);
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
        public IActionResult Edit(EventEditVM eventVM)
        {
            try
            {
                User user = this.usersService.GetByUsername(User.Claims.FirstOrDefault(c => c.Type.Equals("Username")).Value);
                Match matchToUpdate = this.matchesService.GetById(eventVM.Match.MatchId);
                matchToUpdate.Date = eventVM.Match.Date;
                matchToUpdate.LocationId = eventVM.Match.Location.LocationId;
                this.matchesService.Update(matchToUpdate, user);

                foreach (Score score in matchToUpdate.Scores)
                {
                    if (this.usersService.GetAll().FirstOrDefault(u => u.PlayerId == score.PlayerId) != null)
                    {
                        this.MatchUpdated += this.emailHelper.OnMatchUpdated;

                        User userToNotify = this.usersService.GetAll().FirstOrDefault(u => u.PlayerId == score.PlayerId);

                        EventEditVM @event = this.mapper.Map<EventEditVM>(this.eventsService.GetById(eventVM.EventId));

                        this.OnMatchUpdated(@event, matchToUpdate, userToNotify);
                    }
                }

                return RedirectToAction("Edit", "Events", new { eventId = eventVM.EventId });
            }
            catch (Exception ex)
            {
                this.Response.StatusCode = StatusCodes.Status400BadRequest;
                this.ViewData["ErrorMessage"] = ex.Message;
                return this.View("Error");
            }
        }

        #region Private Methods
        private void OnMatchUpdated(EventEditVM @event, Match matchToUpdate, User userToNotify)
        {
            if (MatchUpdated != null)
            {
                MatchUpdated(this, new MatchUpdatedArgs()
                {
                    Event = @event,
                    Scores = matchToUpdate.Scores.First(s => s.PlayerId == userToNotify.PlayerId),
                    User = userToNotify
                });
            }
        }
        #endregion
    }
}

