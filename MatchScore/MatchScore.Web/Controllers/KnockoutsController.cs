using MatchScore.Services.Services.Contracts;
using MatchScore.Web.ViewModels.EventViewModels;
using MatchScore.Web.ViewModels.MatchViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using MatchScore.Data.Models;
using System.Threading.Tasks;
using AutoMapper;
using MatchScore.Services.Services;
using Microsoft.AspNetCore.Authorization;

namespace MatchScore.Web.Controllers
{
    [Authorize]
    public class KnockoutsController : Controller
    {
        private readonly IMatchesService matchesService;
        private readonly IMapper mapper;
        private readonly IRankingsService rankingsService;
        private readonly IScoreService scoreService;
        private readonly IEventsService eventService;
        #region State
        public KnockoutsController(IMatchesService matchesService,
                                  IMapper mapper,
                                  IRankingsService rankingsService,
                                  IScoreService scoreService, 
                                  IEventsService eventService)
        {
            this.matchesService = matchesService;
            this.mapper = mapper;
            this.rankingsService = rankingsService;
            this.scoreService = scoreService;
            this.eventService = eventService;
        }


        #endregion

        [HttpGet]
        public IActionResult Edit(int eventId)
        {  
            return this.View(this.GetEventVM(eventId));
        }

        [HttpPost]
        public IActionResult Edit(MultiRoundEventVM knockoutVM)
        {
            List<Score> scores = this.scoreService.GetByMatchId(knockoutVM.MatchId);
            scores[0].PlayerScore = knockoutVM.Player1Score;
            scores[1].PlayerScore = knockoutVM.Player2Score;

            // call score update method
            foreach (var score in scores)
            {
                this.scoreService.Update(score);
            }

            // if (this.matchesService.GetAll().Where(m => m.EventId == knockoutVM.EventId).ToList().Any(m => m.MatchId > knockoutVM.MatchId))
            if (this.NextMatchExists(knockoutVM.EventId, knockoutVM.MatchId)) //i.e. there is next match in the tournament, this is not the last match
            {
                this.matchesService.UpdateForKnockout(scores);
            }
            else   //For the last match - determine the first and the second place
            {
                List<Ranking> rankUpdate = this.rankingsService.GetByIdWithDeleted(knockoutVM.EventId);
                
                int winnerId, loserId;

                if (scores[0].PlayerScore > scores[1].PlayerScore)
                {
                    winnerId = scores[0].PlayerId;
                    loserId = scores[1].PlayerId;
                }
                else
                {
                    winnerId = scores[1].PlayerId;
                    loserId = scores[0].PlayerId;
                }

                foreach (var rank in rankUpdate)
                {
                    if(rank.PlayerId == winnerId)
                    {
                        rank.Rank = 1;
                        rank.IsDeleted = false;
                    }
                    else if(rank.PlayerId == loserId)
                    {
                        rank.Rank = 2;
                        rank.IsDeleted = false;
                    }
                    else
                    {
                        rank.Rank = 0;
                        rank.IsDeleted = true;
                    }
                    this.rankingsService.Update(rank);
                }
            }

            return RedirectToAction("Edit", "Knockouts", new { eventId = knockoutVM.EventId });
        }

        public IActionResult ResetScore(MultiRoundEventVM knockoutVM)
        {
            //First: reset the result for the current match
            List<Score> scores = this.scoreService.GetByMatchId(knockoutVM.MatchId);

            int winner = scores.OrderByDescending(s => s.PlayerScore).First().Player.PlayerId;

            scores[0].PlayerScore = null;
            scores[1].PlayerScore = null;

            // call score update method
            foreach (var score in scores)
            {
                this.scoreService.Update(score);
            }

            //Second: delete the participant from the next match

            if (this.NextMatchExists(knockoutVM.EventId, knockoutVM.MatchId)) //i.e. there is next match in the tournament, this is not the last match
            {
                Match match = this.matchesService.GetById(knockoutVM.MatchId);
                List<Match> eventMatches = this.matchesService.GetAll().Where(m => m.EventId == knockoutVM.EventId).ToList();
                int nextMatchId = EventsService.GetNextPlayersMatch(match, eventMatches).MatchId;

                Score scoreUpdates = this.scoreService.GetByIDs(nextMatchId, winner, removeDeleted: false);
                scoreUpdates.IsDeleted = true;
                this.scoreService.Update(scoreUpdates);
            }

            return RedirectToAction("Edit", "Knockouts", new { eventId = knockoutVM.EventId });
        }

        private bool NextMatchExists(int eventId, int matchId)
        {
            return this.matchesService.GetAll().Where(m => m.EventId == eventId).ToList().Any(m => m.MatchId > matchId);
        }

        [HttpGet]
        public IActionResult Display(int eventId)
        {
            return this.View(this.GetEventVM(eventId));
        }

        private MultiRoundEventVM GetEventVM(int eventId)
        {
            MultiRoundEventVM knockoutVM = new MultiRoundEventVM();
            knockoutVM.EventId = eventId;
            Event @event = this.eventService.GetById(eventId);

            knockoutVM.EventEndDate = @event.EndDate;
            knockoutVM.Title = @event.Title;

            List<Match> allMatches = this.matchesService.GetAll().Where(m => m.EventId == eventId).ToList();
            List<MatchDetailsVM> matchesVM = allMatches.Select(m => this.mapper.Map<Match, MatchDetailsVM>(m)).ToList();

            //Remove players from matches that were deleted in scores:
            foreach (var match in matchesVM)
            {

            }

            int numberOfPlayers = this.rankingsService.GetByIdWithDeleted(eventId).Count;

            int roundMatchesCount = numberOfPlayers / 2;  //This is the number of matches in the first round

            int allMatchesIndex = 0; //Index for all the matches generated for the tournament

            int roundIndex = 0;  //Index for the matches within one round

            while (allMatchesIndex < matchesVM.Count)
            {
                List<MatchDetailsVM> roundMatches = new List<MatchDetailsVM>(); //List of the matches for the current round within this iteration

                //Loop over the number of matches within one round ('i' is the iterator for the matches)
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

            return knockoutVM;
        }

    }
}
