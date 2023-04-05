using MatchScore.Data.Helpers;
using MatchScore.Data.Models;
using MatchScore.Data.Models.QueryParameters;
using System.Collections.Generic;

namespace MatchScore.Services.Services.Contracts
{
    public interface IScoreService
    {
        Score Create(Score scoreToCreate);

        List<Score> GetByMatchId(int matchId);

        List<Score> GetByEventId(int eventId);

        Score GetByIDs(int matchId, int playerId, bool removeDeleted);

        PaginatedList<Score> FilterBy(ScoreQueryParameters parameters);

        Score Update(Score scoreUpdates);

        void Delete(List<Score> scoresToDelete);
    }
}
