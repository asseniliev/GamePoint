using MatchScore.Data.Models;
using System;
using System.Collections.Generic;

namespace MatchScore.Services.Services.Contracts
{
    public interface ILocationsService
    {
        List<Location> GetAll();

        Location GetById(int locationId);

        Location Create(Location location, User user);
    }
}

