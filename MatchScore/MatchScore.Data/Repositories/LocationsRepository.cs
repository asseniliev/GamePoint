using MatchScore.Data.Constants;
using MatchScore.Data.Data;
using MatchScore.Data.Enums;
using MatchScore.Data.Models;
using MatchScore.Data.Repositories.Contracts;
using MatchScore.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace MatchScore.Data.Repositories
{
    public class LocationsRepository : ILocationsRepository
    {
        private ApplicationContext context;

        public LocationsRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public List<Location> GetAll()
        {
            var locations = this.GetLocations().ToList();
            return locations;
        }

        public Location GetById(int locationId)
        {
            var location = this.GetLocations().FirstOrDefault(m => m.LocationId == locationId);
            return location ?? throw new EntityNotFoundException(string.Format(Messages.DoesNotExistErrorLong, "Location", "id", locationId));
        }

        public Location GetByCityCountry(string city, Countries country)
        {
            var location = this.GetLocations().FirstOrDefault(m => m.City.ToLower() == city.ToLower() && m.Country == country);
            return location ?? throw new EntityNotFoundException(string.Format(Messages.DoesNotExistErrorLong, "Location", "city and country", $"{city} {country}"));
        }

        public Location Create(Location location)
        {
            this.context.Locations.Add(location);
            this.context.SaveChanges();
            return GetById(location.LocationId);
        }

        #region Private Methods

        private IQueryable<Location> GetLocations()
        {
            return this.context.Locations;
        }
        #endregion
    }
}

