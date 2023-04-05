using MatchScore.Data.Helpers;
using MatchScore.Data.Models;
using MatchScore.Data.Models.QueryParameters;
using System.Collections.Generic;

namespace MatchScore.Data.Repositories.Contracts
{
    public interface IMatchesRepository
    {
        List<Match> GetAll();

        Match GetById(int matchId);

        PaginatedList<Match> FilterBy(MatchQueryParameters parameters);

        Match Create(Match match);

        void Update(Match match);

        void SaveDatabase();
    }
}

