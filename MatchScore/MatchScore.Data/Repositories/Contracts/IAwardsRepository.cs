using MatchScore.Data.Helpers;
using MatchScore.Data.Models;
using MatchScore.Data.Models.QueryParameters;
using System.Collections.Generic;

namespace MatchScore.Data.Repositories.Contracts
{
    public interface IAwardsRepository
    {
        Award Create(Award awardToCreate);

        Award GetByAwardId(int awardId);

        Award GetByEventIdAndRank(int eventId, int rank);

        List<Award> GetByEventId(int eventId);

        PaginatedList<Award> FilterBy(AwardQueryParameters parameters);

        void Update(Award awardToUpdate);

        void SaveDatabase();
    }
}
