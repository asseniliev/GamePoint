using MatchScore.Data.Enums;
using MatchScore.Data.Models;
using System.Collections.Generic;

namespace MatchScore.Data.Repositories.Contracts
{
    public interface ILocationsRepository
    {
        List<Location> GetAll();

        Location GetById(int locationId);

        Location GetByCityCountry(string city, Countries country);

        Location Create(Location location);
    }
}

