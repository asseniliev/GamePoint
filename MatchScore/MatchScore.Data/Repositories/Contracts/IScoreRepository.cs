using MatchScore.Data.Helpers;
using MatchScore.Data.Models;
using MatchScore.Data.Models.QueryParameters;
using System.Collections.Generic;

namespace MatchScore.Data.Repositories.Contracts
{
    public interface IScoreRepository
    {
        Score Create(Score scoreToCreate);

        List<Score> GetByIDs(int matchId);

        Score GetByIDs(int matchId, int playerId, bool removeDeleted);

        PaginatedList<Score> FilterBy(ScoreQueryParameters parameters);

        void Update(Score scoreToUpdate);

        void SaveDatabase();
    }
}
