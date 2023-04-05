using MatchScore.Data.Constants;
using MatchScore.Data.Helpers;
using MatchScore.Data.Models;
using MatchScore.Data.Models.QueryParameters;
using MatchScore.Data.Repositories.Contracts;
using MatchScore.Exceptions;
using MatchScore.Services.Helpers;
using MatchScore.Services.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MatchScore.Services.Services
{
    public class MatchesService : IMatchesService
    {
        private readonly IMatchesRepository matchesRepo;
        private readonly IScoreService scoreService;

        public MatchesService(IMatchesRepository matchesRepo, IScoreService scoreService)
        {
            this.matchesRepo = matchesRepo;
            this.scoreService = scoreService;
        }

        #region MethodsForOtherServices
        //TODO remove method if no other service uses it

        public List<Match> GetAll()
        {
            var matches = this.matchesRepo.GetAll();
            return matches;
        }

        public List<Match> GetLatestMatches()
        {
            var now = DateTime.Now;
            var matches = this.matchesRepo.GetAll()
                .Where(m => m.Date < now)
                .OrderByDescending(m => m.Date)
                .Take(5)
                .ToList();
            return matches;
        }

        public List<Match> GetFutureMatches()
        {
            var now = DateTime.Now;
            var matches = this.matchesRepo.GetAll()
                .Where(m => m.Date > now)
                .OrderBy(m => m.Date)
                .Take(5)
                .ToList();
            return matches;
        }

        public Match Create(Match match)
        {
            // Create match
            var result = this.matchesRepo.Create(match);
            return result;
        }

        public Match UpdateForKnockout(List<Score> scores)
        {

            // check winner
            var winner = scores.OrderByDescending(s => s.PlayerScore).First().Player;

            // get next match (from event service) -> get match
            var currentMatch = this.matchesRepo.GetById(scores.First().Match.MatchId);
            List<Match> eventMatches = this.matchesRepo.GetAll().Where(m => m.EventId == currentMatch.EventId).ToList();
            var nextMatch = this.matchesRepo.GetById(EventsService.GetNextPlayersMatch(currentMatch, eventMatches).MatchId);

            // sign up player for next match
            //Check if score already exists from previous score updates:

            try
            {
                Score scoreUpdates = this.scoreService.GetByIDs(nextMatch.MatchId, winner.PlayerId, removeDeleted: false);
                scoreUpdates.IsDeleted = false;
                this.scoreService.Update(scoreUpdates);
            }
            catch (System.Exception)
            {
                var newScore = new Score();
                newScore.MatchId = nextMatch.MatchId;
                newScore.Match = nextMatch;
                newScore.PlayerId = winner.PlayerId;
                newScore.Player = winner;
                this.scoreService.Create(newScore);
            }

            //return current match
            return currentMatch;
        }

        public void Delete(List<Match> matches)
        {
            foreach (var match in matches)
            {
                var matchToDelete = this.matchesRepo.GetById(match.MatchId);
                matchToDelete.IsDeleted = true;
                this.matchesRepo.Update(matchToDelete);
            }

            this.matchesRepo.SaveDatabase();
        }
        #endregion MethodsForOtherServices

        public PaginatedList<Match> FilterBy(MatchQueryParameters parameters)
        {
            var matches = this.matchesRepo.FilterBy(parameters);
            return matches;
        }

        public Match GetById(int matchId)
        {
            var match = this.matchesRepo.GetById(matchId);
            return match;
        }

        public Match APICreate(Match match, User user, Event @event)
        {
            // Authorization: user has to be director or admin
            AuthorizationHelper.AdminOrDirector(user);
            AuthorizationHelper.Active(user);

            // Check if event is completed before updating match
            AuthorizationHelper.Completed(@event);

            // Create match
            var result = this.matchesRepo.Create(match);
            return result;
        }

        public Match Update(Match matchWithUpdates, User user)
        {
            // Authorization: user has to be director or admin
            AuthorizationHelper.AdminOrDirector(user);
            AuthorizationHelper.Active(user);

            // Get match
            var matchToUpdate = this.matchesRepo.GetById(matchWithUpdates.MatchId);
            // Check if event is completed before updating match
            AuthorizationHelper.Completed(matchToUpdate.Event);

            //Update match
            matchToUpdate.Date = matchWithUpdates.Date;
            matchToUpdate.LocationId = matchWithUpdates.LocationId;

            if (matchToUpdate.Location != null)
            {
                matchToUpdate.Location = matchWithUpdates.Location;
            }

            if (matchWithUpdates.Scores.Count != 0)
            {
                matchToUpdate.Scores = matchWithUpdates.Scores;
            }

            this.matchesRepo.Update(matchToUpdate);
            this.matchesRepo.SaveDatabase();
            var updatedMatch = this.matchesRepo.GetById(matchToUpdate.MatchId);
            return updatedMatch;
        }

        public void Delete(int matchId, User user)
        {
            // Authorization: user has to be director or admin
            AuthorizationHelper.AdminOrDirector(user);
            AuthorizationHelper.Active(user);

            // Get match
            var match = this.matchesRepo.GetById(matchId);
            // Check if event is completed before deleting match
            AuthorizationHelper.Completed(match.Event);

            //Check if match has scores before deleting match
            if (match.Scores.Count > 0)
            {
                var isPlayed = match.Scores.Any(s => s.PlayerScore != null);
                if (isPlayed)
                {
                    throw new DeleteConnectedEntityException(string.Format(Messages.DeleteConnectedEntityError, "Players"));throw new DeleteConnectedEntityException(string.Format(Messages.DeleteConnectedEntityError, "Match"));
                }

                this.scoreService.Delete(match.Scores);
            }

            match.IsDeleted = true;
            this.matchesRepo.Update(match);
            this.matchesRepo.SaveDatabase();
        }
    }
}

