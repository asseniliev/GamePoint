using MatchScore.Data.Constants;
using MatchScore.Data.Data;
using MatchScore.Data.Enums;
using MatchScore.Data.Helpers;
using MatchScore.Data.Models;
using MatchScore.Data.Models.QueryParameters;
using MatchScore.Data.Repositories.Contracts;
using MatchScore.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MatchScore.Data.Repositories
{
    public class EventsRepository : IEventsRepository
    {
        #region State
        private ApplicationContext context;

        public EventsRepository(ApplicationContext context)
        {
            this.context = context;
        }

        #endregion

        #region Get Methods
        public List<Event> GetAll()
        {
            var events = this.GetEvents().ToList();
            return events;
        }

        public Event GetById(int eventId)
        {
            var @event = this.GetEvents().FirstOrDefault(e => e.EventId == eventId);
            return @event ?? throw new EntityNotFoundException(string.Format(Messages.DoesNotExistErrorShort, "Event", "id", eventId));
        }

        public Event GetByTitle(string title)
        {
            var @event = this.GetEvents().FirstOrDefault(e => e.Title == title);
            return @event ?? throw new EntityNotFoundException(string.Format(Messages.DoesNotExistErrorShort, "Event", "title", title));
        }

        public PaginatedList<Event> FilterBy(EventQueryParameters parameters)
        {
            IQueryable<Event> @event = this.GetEvents();

            var myEvents = @event.ToList();

            @event = this.FilterByTitle(@event, parameters.Title);
            @event = this.FilterByEventType(@event, parameters.EventType);
            @event = this.FilterByStartDate(@event, parameters.IntervalStartDate, parameters.IntervalEndDate);
            @event = this.FilterByEndDate(@event, parameters.IntervalStartDate, parameters.IntervalEndDate);
            @event = this.FilterByIsTeamEvent(@event, parameters.IsTeamEvent);
            @event = this.FilterByChampion(@event, parameters.Champion);
            @event = this.FilterByDirector(@event, parameters.Director);

            @event = this.SortBy(@event, parameters.SortBy);

            myEvents = @event.ToList();

            myEvents = Helper<Event>.Paginate(@event, parameters);

            return Helper<Event>.Paginate(@event, parameters);
        }

        #endregion

        #region CUD Methods

        public Event Create(Event eventToCreate)
        {
            this.context.Events.Add(eventToCreate);
            this.context.SaveChanges();

            return this.GetById(eventToCreate.EventId);
        }

        public void Update(Event eventToUpdate)
        {
            this.context.Update(eventToUpdate);
        }

        public void SaveDatabase()
        {
            this.context.SaveChanges();
        }

        #endregion

        #region Private Methods

        private IQueryable<Event> GetEvents()
        {
            var @event = this.context.Events.Where(e => !e.IsDeleted)
               .Include(e => e.Location)
               .Include(e => e.Ranking.Where(r => !r.IsDeleted))
                   .ThenInclude(r => r.Player)
                      .ThenInclude(p => p.SportsClub)
               .Include(e => e.Matches.Where(m => !m.IsDeleted))
                   .ThenInclude(m => m.Scores)
               .Include(e => e.Awards.Where(a => !a.IsDeleted))
               //.Include(e => e.Champion)
               .Include(e => e.Director);

            var myEvent = @event.ToList();
            return @event;
        }

        private IQueryable<Event> FilterByTitle(IQueryable<Event> @event, string title)
        {
            if (!string.IsNullOrEmpty(title))
            {
                @event = @event.Where(e => e.Title.ToLower().Contains(title.ToLower()));
            }
            return @event;
        }

        private IQueryable<Event> FilterByEventType(IQueryable<Event> @event, int? eventType)
        {
            if (eventType != null)
            {
                if (Enum.IsDefined(typeof(EventTypes), eventType))
                {
                    @event = @event.Where(e => e.EventType == (EventTypes)eventType);
                }
                else
                {
                    throw new EntityNotFoundException(string.Format(Messages.DoesNotExistErrorLong, "Event type", "integer value", eventType.ToString()));
                }
            }
            return @event;
        }

        private IQueryable<Event> FilterByStartDate(IQueryable<Event> @event, DateTime IntervalStartDate, DateTime IntervalEndDate)
        {
            if (IntervalStartDate != DateTime.MinValue) // i.e. start date is filled in
            {
                if (IntervalEndDate == DateTime.MinValue) // i.e. end date year is not filled in
                {
                    @event = @event.Where(e => e.StartDate >= IntervalStartDate);
                }
                else
                {
                    @event = @event.Where(e => e.StartDate >= IntervalStartDate && e.StartDate <= IntervalEndDate);
                }
            }
            else
            {
                if (IntervalEndDate != DateTime.MinValue)  // i.e. start date year is filled in
                {
                    @event = @event.Where(e => e.StartDate <= IntervalEndDate);
                }
            }

            return @event;
        }

        private IQueryable<Event> FilterByEndDate(IQueryable<Event> @event, DateTime IntervalStartDate, DateTime IntervalEndDate)
        {
            if (IntervalStartDate != DateTime.MinValue) // i.e. start date year is filled in
            {
                if (IntervalEndDate == DateTime.MinValue) // i.e. end date year is filled in
                {
                    @event = @event.Where(e => e.EndDate >= IntervalStartDate);
                }
                else
                {
                    @event = @event.Where(e => e.EndDate >= IntervalStartDate && e.EndDate <= IntervalEndDate);
                }
            }
            else
            {
                if (IntervalEndDate != DateTime.MinValue) // i.e. end date year is not filled in
                {
                    @event = @event.Where(e => e.EndDate <= IntervalEndDate);
                }
            }

            return @event;
        }

        private IQueryable<Event> FilterByIsTeamEvent(IQueryable<Event> @event, bool? isTeamEvent)
        {
            if (isTeamEvent != null)
            {
                @event = @event.Where(e => e.IsTeamEvent == isTeamEvent);
            }
            return @event;
        }

        private IQueryable<Event> FilterByChampion(IQueryable<Event> @event, string champion)
        {
            if (champion != null)
            {
                @event = @event.Where(e => e.Champion.Name == champion);
            }
            return @event;
        }

        private IQueryable<Event> FilterByDirector(IQueryable<Event> @event, string director)
        {
            if (director != null)
            {
                @event = @event.Where(e => e.Director.Username == director);
            }
            return @event;
        }

        private IEnumerable<Event> SortOrder(IQueryable<Event> @event, string sortOrder)
        {
            switch (sortOrder)
            {
                case "desc":
                    return @event.AsEnumerable().Reverse();
                default:
                    return @event;
            }
        }

        private IQueryable<Event> SortBy(IQueryable<Event> @event, string sortBy)
        {
            switch (sortBy)
            {
                case "title":
                    return @event.OrderBy(e => e.Title);
                case "eventtype":
                    return @event.OrderBy(e => e.EventType);
                case "startdate":
                    return @event.OrderBy(e => e.StartDate);
                case "enddate":
                    return @event.OrderBy(e => e.EndDate);
                case "isteamevent":
                    return @event.OrderBy(e => e.IsTeamEvent);
                case "city":
                    return @event.OrderBy(e => e.Location.City);
                case "country":
                    return @event.OrderBy(e => e.Location.Country);
                case "champion":
                    return @event.OrderBy(e => e.Champion.Name);
                case "director":
                    return @event.OrderBy(e => e.Director.Username);
                default:
                    return @event;
            }
        }
        #endregion
    }
}
