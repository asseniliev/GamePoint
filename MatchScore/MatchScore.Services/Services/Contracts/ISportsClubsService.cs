using MatchScore.Data.Models;
using System.Collections.Generic;

namespace MatchScore.Services.Services.Contracts
{
    public interface ISportsClubsService
    {
        // Methods for other services:

        List<SportsClub> GetAll();
        // end

        SportsClub GetById(int sportsClubId);

        SportsClub Create(SportsClub sportsClub, User user);

        SportsClub Update(SportsClub sportsClubWithUpdates, User user);

        void Delete(int sportsClubId, User user);
    }
}

