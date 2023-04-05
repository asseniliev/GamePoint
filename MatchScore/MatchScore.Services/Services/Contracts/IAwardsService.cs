using MatchScore.Data.Helpers;
using MatchScore.Data.Models;
using MatchScore.Data.Models.QueryParameters;
using System.Collections.Generic;

namespace MatchScore.Services.Services.Contracts
{
    public interface IAwardsService
    {
        Award Create(Award awardToCreate);

        Award GetByAwardId(int awardId);

        Award GetByEventIdAndRank(int eventId, int rank);

        List<Award> GetByEventId(int eventId);

        PaginatedList<Award> FilterBy(AwardQueryParameters parameters);

        Award Update(Award awardUpdates);

        void Delete(int awardId);

        void Delete(List<Award> awardsToDelete);
    }
}
