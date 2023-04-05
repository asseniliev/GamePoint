using MatchScore.Data.Helpers;
using MatchScore.Data.Models;
using MatchScore.Data.Models.QueryParameters;
using System.Collections.Generic;

namespace MatchScore.Services.Services.Contracts
{
    public interface IMatchesService
    {
        // Methods for other services:
        List<Match> GetAll();

        List<Match> GetLatestMatches();

        List<Match> GetFutureMatches();

        Match Create(Match match);

        Match UpdateForKnockout(List<Score> scores);

        void Delete(List<Match> matches);
        //end

        PaginatedList<Match> FilterBy(MatchQueryParameters parameters);

        Match GetById(int matchId);

        Match APICreate(Match match, User user, Event @event);

        Match Update(Match matchWithEditedInfo, User user);

        void Delete(int matchId, User user);
    }
}

