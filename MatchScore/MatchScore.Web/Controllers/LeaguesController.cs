using AutoMapper;
using MatchScore.Data.Models;
using MatchScore.Services.Services.Contracts;
using MatchScore.Web.ViewModels;
using MatchScore.Web.ViewModels.EventViewModels;
using MatchScore.Web.ViewModels.MatchViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchScore.Web.Controllers
{
    [Authorize]
    public class LeaguesController : Controller
    {
        private readonly IMatchesService matchesService;
        private readonly IMapper mapper;
        private readonly IRankingsService rankingsService;
        private readonly IScoreService scoreService;
        private readonly IEventsService eventService;

        public LeaguesController(IMatchesService matchesService,
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


        [HttpGet]
        public IActionResult Edit(int eventId)
        {
            return this.View(this.GetEventVM(eventId));
        }

        
        [HttpPost]
        public IActionResult Edit(MultiRoundEventVM leagueVM)
        {
            int winnerPoints = this.eventService.GetById(leagueVM.EventId).ScoreForWin;
            int drawPoints = this.eventService.GetById(leagueVM.EventId).ScoreForDraw;

            List<Score> scores = this.scoreService.GetByMatchId(leagueVM.MatchId);
            scores[0].PlayerScore = leagueVM.Player1Score;
            scores[1].PlayerScore = leagueVM.Player2Score;

            if (leagueVM.Player1Score == leagueVM.Player2Score)
            {
                scores[0].ScoredPoints = drawPoints;
                scores[1].ScoredPoints = drawPoints;
            }
            else if (leagueVM.Player1Score > leagueVM.Player2Score)
            {
                scores[0].ScoredPoints = winnerPoints;
            }
            else
                scores[1].ScoredPoints = winnerPoints;

            // Update the "Scores" table
            foreach (var score in scores)
            {
                this.scoreService.Update(score);
            }

            //Make new ranking
            UpdateRanking(leagueVM.EventId);

            return RedirectToAction("Edit", "Leagues", new { eventId = leagueVM.EventId });
        }

        public IActionResult ResetScore(MultiRoundEventVM leagueVM)
        {
            //First: reset the result for the current match
            List<Score> scores = this.scoreService.GetByMatchId(leagueVM.MatchId);

            int winner = scores.OrderByDescending(s => s.PlayerScore).First().Player.PlayerId;

            scores[0].PlayerScore = null;
            scores[0].ScoredPoints = 0;
            scores[1].PlayerScore = null;
            scores[1].ScoredPoints = 0;

            // call score update method
            foreach (var score in scores)
            {
                this.scoreService.Update(score);
            }

            //Second: make new ranking
            UpdateRanking(leagueVM.EventId);

            return RedirectToAction("Edit", "Leagues", new { eventId = leagueVM.EventId });
        }

        private void UpdateRanking(int eventId)
        {
            //Update the "Ranking" table based on the new score
            //Dictionary<playerId, player's TotalPoints>
            Dictionary<int, int> playerPoints = new Dictionary<int, int>();
            List<Match> allMatchesInEvent = this.matchesService.GetAll().Where(m => m.EventId == eventId).ToList();

            //1. Fill in each player's points into the dictionary and then sort it by value
            foreach (var match in allMatchesInEvent)
            {
                List<Score> scores = this.scoreService.GetByMatchId(match.MatchId);
                foreach (var score in scores)
                {
                    if (playerPoints.ContainsKey(score.PlayerId))
                        playerPoints[score.PlayerId] += score.ScoredPoints;
                    else
                        playerPoints.Add(score.PlayerId, score.ScoredPoints);
                }
            }

            var sortedDict = from entry in playerPoints orderby entry.Value descending select entry;

            //2. Update "Ranking" table
            int rank = 1;
            foreach (var item in sortedDict)
            {
                Ranking rankingUpdate = this.rankingsService.GetByIDs(item.Key, eventId);
                rankingUpdate.Rank = rank;
                this.rankingsService.Update(rankingUpdate);
                rank++;
            }
        }

        [HttpGet]
        public IActionResult Display(int eventId)
        {
            return this.View(this.GetEventVM(eventId));
        }

        private MultiRoundEventVM GetEventVM(int eventId)
        {
            MultiRoundEventVM leagueVM = new MultiRoundEventVM();
            leagueVM.EventId = eventId;
            Event @event = this.eventService.GetById(eventId);
            leagueVM.EventEndDate = @event.EndDate;
            leagueVM.Title = @event.Title;

            List<Match> allMatchesInEvent = this.matchesService.GetAll().Where(m => m.EventId == eventId).ToList();
            List<MatchDetailsVM> matchesVM = allMatchesInEvent.Select(m => this.mapper.Map<Match, MatchDetailsVM>(m)).ToList();

            int numberOfPlayers = this.rankingsService.GetAll().Where(r => r.EventId == eventId).ToList().Count;
            int roundMatchesCount = numberOfPlayers / 2;  //This is the number of matches per round
            int numberOfRounds = (numberOfPlayers - 1) * 2;

            //Initialize the MatchSchema list in leagueVM
            for (int i = 0; i < numberOfRounds; i++)
            {
                leagueVM.MatchScheme.Add(new List<MatchDetailsVM>());
            }

            foreach (var match in matchesVM)
            {
                int round = this.scoreService.GetByMatchId(match.MatchId)[0].Round;
                leagueVM.MatchScheme[round - 1].Add(match);

                //For the current match -> check if score was already posted and if yes - put it in the list w/ matches with scores
                if (this.scoreService.GetByMatchId(match.MatchId).Exists(s => s.PlayerScore != null))
                {
                    leagueVM.MatchIDsWithScores.Add(match.MatchId);
                }
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
                    leagueVM.MatchScores.Add(match.MatchId, playersScore);
                }
            }

            return leagueVM;
        }
    }
}
