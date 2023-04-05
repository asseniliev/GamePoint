using MatchScore.Data.Helpers;
using MatchScore.Data.Models;
using MatchScore.Data.Models.QueryParameters;
using System.Collections.Generic;

namespace MatchScore.Data.Repositories.Contracts
{
    public interface IEventsRepository
    {
        Event Create(Event @event);

        List<Event> GetAll();

        Event GetById(int eventId);

        Event GetByTitle(string title);

        PaginatedList<Event> FilterBy(EventQueryParameters parameters);

        void Update(Event @event);

        void SaveDatabase();

    }
}
