using MatchScore.Web.ViewModels.EventViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatchScore.Services.Services.Contracts;
using MatchScore.Data.Models;
using MatchScore.Web.ViewModels.MatchViewModels;
using AutoMapper;

namespace MatchScore.Web.Controllers
{
    public class SingleMatchesController : Controller
    {
        private readonly IEventsService eventsService;
        private readonly IMapper mapper;
        private readonly IScoreService scoreService;
        private readonly IPlayersService playersService;
        private readonly IRankingsService rankingsService;
        private readonly IMatchesService matchesService;

        #region States
        public SingleMatchesController (IMatchesService matchesService,
                                        IEventsService eventsService,
                                        IMapper mapper,
                                        IScoreService scoreService, 
                                        IPlayersService playersService,
                                        IRankingsService rankingsService)
        {
            this.matchesService = matchesService;
            this.eventsService = eventsService;
            this.mapper = mapper;
            this.scoreService = scoreService;
            this.playersService = playersService;
            this.rankingsService = rankingsService;
        }

        public IMatchesService MatchesService { get; }
        #endregion


        [HttpGet]
        public IActionResult Edit(int eventId)
        {
            return this.View(this.GetEventVM(eventId));
        }


        [HttpPost]
        public IActionResult Edit(SingleRoundEventVM singleMatchVM)
        {
            List<Score> scores = this.scoreService.GetByMatchId(singleMatchVM.MatchId);
            scores[0].PlayerScore = singleMatchVM.Player1Score;
            scores[1].PlayerScore = singleMatchVM.Player2Score;

            // Update the "Scores" table
            foreach (var score in scores)
            {
                this.scoreService.Update(score);
            }

            //Make new ranking
            UpdateRanking(singleMatchVM.EventId);

            return RedirectToAction("Edit", "SingleMatches", new { eventId = singleMatchVM.EventId });
        }

        public IActionResult ResetScore(SingleRoundEventVM singleMatchVM)
        {
            //First: reset the result for the two players
            List<Score> scores = this.scoreService.GetByMatchId(singleMatchVM.MatchId);

            scores[0].PlayerScore = null;
            scores[0].ScoredPoints = 0;
            scores[1].PlayerScore = null;
            scores[1].ScoredPoints = 0;

            // call score update method
            foreach (var score in scores)
            {
                this.scoreService.Update(score);
            }

            //Second: reset the ranking
            List<Ranking> ranking = new List<Ranking>();
            ranking = this.rankingsService.GetByIdWithDeleted(singleMatchVM.EventId);
            ranking[0].Rank = 0;
            ranking[1].Rank = 0;

            this.rankingsService.Update(ranking[0]);
            this.rankingsService.Update(ranking[1]);

            return RedirectToAction("Edit", "SingleMatches", new { eventId = singleMatchVM.EventId });
        }

        private void UpdateRanking(int eventId)
        {
            List<Score> scores = this.scoreService.GetByEventId(eventId);

            int winnerId, loserId;

            if(scores[0].PlayerScore > scores[1].PlayerScore)
            {
                winnerId = scores[0].PlayerId;
                loserId = scores[1].PlayerId;
            }
            else
            {
                winnerId = scores[1].PlayerId;
                loserId = scores[0].PlayerId;
            }

            Ranking rankingUpdate = this.rankingsService.GetByIDs(winnerId, eventId);
            rankingUpdate.Rank = 1;
            this.rankingsService.Update(rankingUpdate);

            rankingUpdate = this.rankingsService.GetByIDs(loserId, eventId);
            rankingUpdate.Rank = 2;
            this.rankingsService.Update(rankingUpdate);
        }

        [HttpGet]
        public IActionResult Display(int eventId)
        {
            return this.View(this.GetEventVM(eventId));
        }

        private SingleRoundEventVM GetEventVM(int eventId)
        {
            SingleRoundEventVM singleMatchVM = new SingleRoundEventVM();
            singleMatchVM.EventId = eventId;
            singleMatchVM.Title = this.eventsService.GetById(eventId).Title;

            //We have only one match and its index in the list is always 0
            Match match = this.matchesService.GetAll().Where(m => m.EventId == eventId).ToList()[0];

            singleMatchVM.MatchId = match.MatchId;
            singleMatchVM.eventDate = match.Date;

            //Add players 
            List<Score> scores = this.scoreService.GetByMatchId(singleMatchVM.MatchId);
            singleMatchVM.Player1 = this.playersService.GetById(scores[0].PlayerId);
            singleMatchVM.Player1Score = scores[0].PlayerScore;

            singleMatchVM.Player2 = this.playersService.GetById(scores[1].PlayerId);
            singleMatchVM.Player2Score = scores[1].PlayerScore;

            return singleMatchVM;
        }
    }
}
