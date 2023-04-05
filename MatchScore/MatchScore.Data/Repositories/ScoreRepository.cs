using MatchScore.Data.Constants;
using MatchScore.Data.Data;
using MatchScore.Data.Helpers;
using MatchScore.Data.Models;
using MatchScore.Data.Models.QueryParameters;
using MatchScore.Data.Repositories.Contracts;
using MatchScore.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MatchScore.Data.Repositories
{
    public class ScoreRepository : IScoreRepository
    {
        #region Constructors
        private ApplicationContext context;

        public ScoreRepository(ApplicationContext context)
        {
            this.context = context;
        }

        #endregion

        #region Get Methods

        public List<Score> GetByIDs(int matchId)
        {
            var score = this.GetScores().Where(s => s.MatchId == matchId).ToList();
            return score ?? throw new EntityNotFoundException(string.Format(Messages.DoesNotExistErrorShort, "Score for the match id", matchId));
        }

        public Score GetByIDs(int matchId, int playerId, bool removeDeleted)
        {
            Score score = new Score();
            if(removeDeleted)
            {
                score = this.GetScores().FirstOrDefault(s => s.MatchId == matchId && s.PlayerId == playerId);
            }
            else
            {
                score = this.context.Scores.FirstOrDefault(s => s.MatchId == matchId && s.PlayerId == playerId);
            }
            return score ?? throw new EntityNotFoundException(string.Format(Messages.DoesNotExistErrorShort, "Score", "for the match and player"));
        }


        public PaginatedList<Score> FilterBy(ScoreQueryParameters parameters)
        {
            IQueryable<Score> scores = this.GetScores();

            scores = this.FilterByMatchId(scores, parameters.MatchId);
            scores = this.FilterByPlayerId(scores, parameters.PlayerId);
            scores = this.FilterByPlayerName(scores, parameters.PlayerName);
            scores = this.FilterByPlayerHighestScore(scores, parameters.PlayerScoreUpLimit);
            scores = this.FilterByPlayerLowestScore(scores, parameters.PlayerScoreDownLimit);

            scores = this.SortBy(scores, parameters.SortBy);

            return Helper<Score>.Paginate(scores, parameters);
        }

        #endregion

        #region Updates
        public Score Create(Score scoreToCreate)
        {
            this.context.Scores.Add(scoreToCreate);
            this.context.SaveChanges();

            return this.GetByIDs(scoreToCreate.MatchId, scoreToCreate.PlayerId, removeDeleted: false);
        }

        public void Update(Score scoreToUpdate)
        {
            this.context.Update(scoreToUpdate);
        }

        public void SaveDatabase()
        {
            this.context.SaveChanges();
        }
        #endregion

        #region Private Methods
        private IQueryable<Score> GetScores()
        {
            var scores = this.context.Scores.Where(s => !s.IsDeleted)
                .Include(a => a.Match)
                    .ThenInclude(m => m.Location)
                .Include(a => a.Player);

            return scores;
        }

        private IQueryable<Score> FilterByMatchId(IQueryable<Score> score, int? matchId)
        {
            if (matchId != null)
            {
                score = score.Where(s => s.MatchId == matchId);
            }
            return score;
        }

        private IQueryable<Score> FilterByPlayerId(IQueryable<Score> score, int? playerId)
        {
            if (playerId != null)
            {
                score = score.Where(s => s.PlayerId == playerId);
            }
            return score;
        }

        private IQueryable<Score> FilterByPlayerName(IQueryable<Score> score, string playerName)
        {
            if (!string.IsNullOrEmpty(playerName))
            {
                score = score.Where(s => s.Player.Name.ToLower().Contains(playerName.ToLower()));
            }
            return score;
        }

        private IQueryable<Score> FilterByPlayerHighestScore(IQueryable<Score> score, double? playerScoreUpLimit)
        {
            if (playerScoreUpLimit != null)
            {
                score = score.Where(s => s.PlayerScore <= playerScoreUpLimit);
            }
            return score;
        }

        private IQueryable<Score> FilterByPlayerLowestScore(IQueryable<Score> score, double? playerScoreDownLimit)
        {
            if (playerScoreDownLimit != null)
            {
                score = score.Where(s => s.PlayerScore >= playerScoreDownLimit);
            }
            return score;
        }

        private IQueryable<Score> SortBy(IQueryable<Score> score, string sortBy)
        {
            switch (sortBy)
            {
                case "match":
                    return score.OrderBy(s => s.MatchId);
                case "player":
                    return score.OrderBy(s => s.Player.Name);
                case "score":
                    return score.OrderBy(s => s.PlayerScore);
                default:
                    return score;
            }
        }



        #endregion
    }
}
