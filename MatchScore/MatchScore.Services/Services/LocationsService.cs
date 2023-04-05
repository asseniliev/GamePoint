using MatchScore.Data.Constants;
using MatchScore.Data.Models;
using MatchScore.Data.Repositories.Contracts;
using MatchScore.Exceptions;
using MatchScore.Services.Helpers;
using MatchScore.Services.Services.Contracts;
using System.Collections.Generic;

namespace MatchScore.Services.Services
{
    public class LocationsService : ILocationsService
    {
        private readonly ILocationsRepository locationsRepo;

        public LocationsService(ILocationsRepository locationsRepo)
        {
            this.locationsRepo = locationsRepo;
        }

        public List<Location> GetAll()
        {
            var locations = this.locationsRepo.GetAll();
            return locations;
        }

        public Location GetById(int locationId)
        {
            var location = this.locationsRepo.GetById(locationId);
            return location;
        }

        public Location Create(Location location, User user)
        {
            //TODO: don't know if we'll need authorizations
            // Authorization: user has to be director or admin
            AuthorizationHelper.AdminOrDirector(user);
            AuthorizationHelper.Active(user);

            // Check if location with the same city and country exists
            try
            {
                var repeatedLocation = this.locationsRepo.GetByCityCountry(location.City, location.Country);
                //TODO: maybe return location here, don't throw exception
                throw new DuplicateEntityException(string.Format(Messages.AlreadyExistsError, "Location", "city and country", $"{location.City} and {location.Country}"));
            }
            catch (EntityNotFoundException)
            {
                //TODO: find location in BingMaps Api, get back latitude and longitude, add them to location info
                //throw exception if location can't be found
                //create location if everything is good:
                var result = this.locationsRepo.Create(location);
                return result;
            }
        }
    }
}

