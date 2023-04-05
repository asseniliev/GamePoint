using MatchScore.Data.Constants;
using MatchScore.Data.Data;
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
    public class MatchesRepository : IMatchesRepository
    {
        private ApplicationContext context;

        public MatchesRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public List<Match> GetAll()
        {
            var matches = this.GetMatches().ToList();
            return matches;
        }

        public Match GetById(int matchId)
        {
            var match = this.GetMatches().FirstOrDefault(m => m.MatchId == matchId);
            return match ?? throw new EntityNotFoundException(string.Format(Messages.DoesNotExistErrorLong, "Match", "id", matchId));
        }

        public PaginatedList<Match> FilterBy(MatchQueryParameters parameters)
        {
            IQueryable<Match> matches = this.GetMatches();

            matches = FilterByDate(matches, parameters.Date);
            matches = FilterByPlayer(matches, parameters.Player);
            matches = FilterByLocation(matches, parameters.City);
            matches = FilterByEventTitle(matches, parameters.EventTitle);
            matches = SortBy(matches, parameters.SortBy);
            var result = SortOrder(matches, parameters.SortOrder).ToList();

            return new PaginatedList<Match>(result, parameters.PageSize, parameters.CurrentPage);
        }

        public Match Create(Match match)
        {
            this.context.Matches.Add(match);
            this.context.SaveChanges();
            return GetById(match.MatchId);
        }

        // Methods for group deletion:

        public void Update(Match match)
        {
            this.context.Matches.Update(match);
        }

        public void SaveDatabase()
        {
            this.context.SaveChanges();
        }

        #region Private Methods

        private IQueryable<Match> GetMatches()
        {
            return this.context.Matches.Where(m => !m.IsDeleted)
                .Include(m => m.Event)
                    .ThenInclude(e => e.Ranking)
                .Include(m => m.Event)
                    .ThenInclude(e => e.Matches.Where(m => !m.IsDeleted))
                .Include(m => m.Location)
                .Include(m => m.Scores.Where(s => !s.IsDeleted))
                    .ThenInclude(s => s.Player)
                        .ThenInclude(p => p.SportsClub);
        }

        private static IQueryable<Match> FilterByDate(IQueryable<Match> matches, DateTime date)
        {
            if (date != DateTime.MinValue)
            {
                return matches.Where(m => m.Date.Date == date.Date);
            }
            return matches;
        }

        private static IQueryable<Match> FilterByPlayer(IQueryable<Match> matches, string player)
        {
            if (!string.IsNullOrEmpty(player))
            {
                return matches.Where(m => m.Scores.Where(s => s.Player != null).Any(s => s.Player.Name.ToLower().Contains(player.ToLower())));
            }
            return matches;
        }

        private static IQueryable<Match> FilterByLocation(IQueryable<Match> matches, string city)
        {
            if (!string.IsNullOrEmpty(city))
            {
                return matches.Where(m => m.Location.City.ToLower().Contains(city.ToLower()));
            }
            return matches;
        }

        private static IQueryable<Match> FilterByEventTitle(IQueryable<Match> matches, string eventTitle)
        {
            if (!string.IsNullOrEmpty(eventTitle))
            {
                return matches.Where(m => m.Event.Title.ToLower().Contains(eventTitle.ToLower()));
            }
            return matches;
        }

        private static IQueryable<Match> SortBy(IQueryable<Match> matches, string sortBy)
        {
            switch (sortBy)
            {
                case "date":
                    return matches.OrderBy(m => m.Date);
                default:
                    return matches;
            }
        }

        private static IEnumerable<Match> SortOrder(IQueryable<Match> matches, string sortOrder)
        {
            switch (sortOrder)
            {
                case "desc":
                    return matches.AsEnumerable().Reverse();
                default:
                    return matches;
            }
        }
        #endregion
    }
}

