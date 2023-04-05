using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using AutoMapper;
using MatchScore.Data.Constants;
using MatchScore.Data.Enums;
using MatchScore.Data.Models;
using MatchScore.Data.Models.QueryParameters;
using MatchScore.Exceptions;
using MatchScore.Services.Services.Contracts;
using MatchScore.Web.DTOs.MatchDTOs;
using MatchScore.Web.Helpers;
using MatchScore.Web.ViewModels.EventViewModels;
using MatchScore.Web.ViewModels.MatchViewModels;
using MatchScore.Web.ViewModels.PlayerViewModels;
using MatchScore.Web.ViewModels.WeatherViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MatchScore.Web.Controllers.API
{
    [Route("api/matches")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class MatchesApiController : ControllerBase
    {
        private readonly IMatchesService matchesService;
        private readonly IUsersService usersService;
        private readonly IEventsService eventsService;
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IMapper mapper;

        public MatchesApiController(IMatchesService matchesService,
            IUsersService usersService, IEventsService eventsService,
            IHttpClientFactory httpClientFactory, IMapper mapper)
		{
            this.matchesService = matchesService;
            this.usersService = usersService;
            this.eventsService = eventsService;
            this.httpClientFactory = httpClientFactory;
            this.mapper = mapper;
        }


        [AllowAnonymous]
        [HttpGet("")]
        public IActionResult Get([FromQuery] MatchQueryParameters parameters)
        {
            try
            {
                var matches = this.matchesService.FilterBy(parameters);

                var matchesVM = matches.Select(m => mapper.Map<MatchShortVM>(m)).ToList();
                return this.StatusCode(StatusCodes.Status200OK, matchesVM);
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
                var match = this.matchesService.GetById(id);
                var matchVM = mapper.Map<MatchDetailsVM>(match);

                //get forecast
                var client = this.httpClientFactory.CreateClient();
                var hourlyForecast = new List<HourlyWeatherVM>();
                WeatherHelper.RunAsync(client, matchVM.LocationLatitude, matchVM.LocationLongitude, hourlyForecast).GetAwaiter().GetResult();
                var dailyForecast = WeatherHelper.GenerateDailyForecasts(hourlyForecast);
                matchVM.Forecast.Weather = dailyForecast;
                matchVM.Forecast.CurrentWeather = hourlyForecast.FirstOrDefault();

                return this.StatusCode(StatusCodes.Status200OK, matchVM);
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
        public IActionResult Post([FromBody] MatchPostDto matchDto)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return this.StatusCode(StatusCodes.Status406NotAcceptable, Messages.InvalidInfo);
                }

                User user = this.usersService.GetByUsername(User.Claims.FirstOrDefault(c => c.Type.Equals("username")).Value);
                Event @event = this.eventsService.GetById(matchDto.EventId);

                Match result;
                if (@event.matchType == MatchTypes.TimeLimited)
                {
                    var match = this.mapper.Map<TimeLimitedMatch>(matchDto);
                    match.MatchTimeLimit = @event.MatchLimitValue;
                    result = this.matchesService.APICreate(match, user, @event);
                }
                else
                {
                    var match = this.mapper.Map<ScoreLimitedMatch>(matchDto);
                    match.MatchScoreLimit = @event.MatchLimitValue;
                    result = this.matchesService.APICreate(match, user, @event);
                }

                return this.RedirectToAction("GetById", new { id = result.MatchId });
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

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] MatchEditDto matchDto)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return this.StatusCode(StatusCodes.Status406NotAcceptable, Messages.InvalidInfo);
                }

                User user = this.usersService.GetByUsername(User.Claims.FirstOrDefault(c => c.Type.Equals("username")).Value);

                Match matchToUpdate = this.matchesService.GetById(id);
                matchToUpdate.Date = matchDto.Date;
                matchToUpdate.LocationId = matchDto.LocationId;

                this.matchesService.Update(matchToUpdate, user);

                return this.RedirectToAction("GetById", new { id = id });
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

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var user = this.usersService.GetByUsername(User.Claims.FirstOrDefault(c => c.Type.Equals("username")).Value);
                this.matchesService.Delete(id, user);
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

