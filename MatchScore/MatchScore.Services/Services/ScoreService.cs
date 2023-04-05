using MatchScore.Data.Helpers;
using MatchScore.Data.Models;
using MatchScore.Data.Models.QueryParameters;
using MatchScore.Data.Repositories.Contracts;
using MatchScore.Services.Services.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace MatchScore.Services.Services
{
    public class ScoreService : IScoreService
    {
        #region Constructors

        private readonly IScoreRepository scoreRepository;
        private readonly IMatchesRepository matchesRepository;

        public ScoreService(IScoreRepository scoreRepository,
                            IMatchesRepository matchesRepository)
        {
            this.scoreRepository = scoreRepository;
            this.matchesRepository = matchesRepository;
        }

        #endregion


        #region Get Methods

        public List<Score> GetByMatchId(int matchId)
        {
            return this.scoreRepository.GetByIDs(matchId);
        }

        public List<Score> GetByEventId(int eventId)
        {
            List<Score> scores = new List<Score>();

            List<Match> matches = this.matchesRepository.GetAll().Where(m => m.EventId == eventId).ToList();

            foreach (var match in matches)
            {
                scores.AddRange(this.scoreRepository.GetByIDs(match.MatchId));
            }

            return scores;
        }

        public Score GetByIDs(int matchId, int playerId, bool removeDeleted)
        {
            return this.scoreRepository.GetByIDs(matchId, playerId, removeDeleted);
        }


        public PaginatedList<Score> FilterBy(ScoreQueryParameters parameters)
        {
            return this.scoreRepository.FilterBy(parameters);
        }

        #endregion


        #region Updates
        public Score Create(Score score)
        {
            return this.scoreRepository.Create(score);
        }

        public Score Update(Score scoreUpdates)
        {
            Score scoreToUpdate = this.GetByIDs(scoreUpdates.MatchId, scoreUpdates.PlayerId, removeDeleted: false);

            scoreToUpdate.PlayerScore = scoreUpdates.PlayerScore;

            scoreToUpdate.PlayerId = scoreUpdates.PlayerId;

            this.scoreRepository.Update(scoreToUpdate);

            this.scoreRepository.SaveDatabase();

            Score updatedScore = this.scoreRepository.GetByIDs(scoreUpdates.MatchId, scoreUpdates.PlayerId, removeDeleted: false);

            return updatedScore;
        }

        public void Delete(List<Score> scoresToDelete)
        {
            scoresToDelete.ForEach(s => s.IsDeleted = true);

            scoresToDelete.ForEach(s => this.scoreRepository.Update(s));

            this.scoreRepository.SaveDatabase();
        }

        #endregion
    }
}
