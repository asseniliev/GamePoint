using MatchScore.Data.Enums;
using MatchScore.Data.Helpers;
using MatchScore.Data.Models;
using MatchScore.Data.Models.QueryParameters;
using System.Collections.Generic;

namespace MatchScore.Services.Services.Contracts
{
    public interface IEventsService
    {
        // Get Methods
        List<Event> GetAll();

        Event GetById(int eventId);

        Event GetByTitle(string title);

        PaginatedList<Event> FilterBy(EventQueryParameters parameters);

        List<Event> GetLatestEvents();

        List<Event> GetFutureEvents();

        // CUD methods
        Event Create(Event eventToCreate, User user);

        void Update(Event eventUpdates, User user);

        void AddPlayer(int eventId, Player player, User user);

        void RemovePlayer(int eventId, Player player, User user);

        void GenerateMatchScheme(int eventId, User user);

        void SuppressMatchScheme(int eventId, User user);

        Player DetermineChampion(int eventId);

        void Delete(int eventId, User user);
    }
}
