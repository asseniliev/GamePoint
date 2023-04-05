using MatchScore.Data.Models;
using System.Collections.Generic;

namespace MatchScore.Data.Repositories.Contracts
{
    public interface ISportsClubsRepository
    {
        List<SportsClub> GetAll();

        SportsClub GetById(int sportsClubId);

        SportsClub GetByName(string sportsClubName);

        SportsClub Create(SportsClub sportsClub);

        SportsClub Update(SportsClub sportsClub);

        void Delete(SportsClub sportsClub);
    }
}

