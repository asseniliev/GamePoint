using System;
using System.IO;
using System.Linq;
using AutoMapper;
using MatchScore.Data.Constants;
using MatchScore.Data.Models;
using MatchScore.Data.Models.QueryParameters;
using MatchScore.Exceptions;
using MatchScore.Services.Services.Contracts;
using MatchScore.Web.DTOs.ScoreDTOs;
using MatchScore.Web.ViewModels.PlayerViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MatchScore.Web.Controllers.API
{
    [Route("api/scores")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class ScoresApiController : ControllerBase
    {
        private readonly IScoreService scoreService;
        private readonly IUsersService usersService;
        private readonly IMapper mapper;

        public ScoresApiController(IScoreService scoreService,
            IUsersService usersService, IMapper mapper)
		{
            this.scoreService = scoreService;
            this.usersService = usersService;
            this.mapper = mapper;
		}

        [AllowAnonymous]
        [HttpGet("")]
        public IActionResult Get([FromQuery] ScoreQueryParameters parameters)
        {
            try
            {
                var scores = this.scoreService.FilterBy(parameters);

                var scoresVM = scores.Select(mapper.Map<ScoreDetailsDto>).ToList();

                return this.StatusCode(StatusCodes.Status200OK, scoresVM);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult GetById(int id, [FromHeader] int playerId)
        {
            try
            {
                var score = this.scoreService.GetByIDs(id, playerId, true);
                var scoreDto = mapper.Map<ScoreDetailsDto>(score);
                return this.StatusCode(StatusCodes.Status200OK, scoreDto);
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

        //[HttpPost("")]
        //[Authorize(Roles = "Admin, Director")]
        //public IActionResult Post([FromBody] ScoreCreateDto scoreDto)
        //{
        //    try
        //    {
        //        if (!this.ModelState.IsValid)
        //        {
        //            return this.StatusCode(StatusCodes.Status406NotAcceptable, Messages.InvalidInfo);
        //        }

        //        Score score = this.mapper.Map<Score>(scoreDto);
        //        var user = this.usersService.GetByUsername(User.Claims.FirstOrDefault(c => c.Type.Equals("username")).Value);

        //        if (user.IsInactive)
        //        {
        //            throw new UnauthorizedOperationException(Messages.DeactivatedUserError);
        //        }

        //        var createdScore = this.scoreService.Create(score);
        //        var createdScoreDto = mapper.Map<ScoreDetailsDto>(createdScore);
        //        return this.StatusCode(StatusCodes.Status200OK, createdScoreDto);
        //    }
        //    catch (UnauthorizedOperationException ex)
        //    {
        //        return this.StatusCode(StatusCodes.Status401Unauthorized, ex.Message);
        //    }
        //    catch (DuplicateEntityException ex)
        //    {
        //        return this.StatusCode(StatusCodes.Status409Conflict, ex.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        return this.StatusCode(StatusCodes.Status400BadRequest, ex.Message);
        //    }
        //}
    }
}

