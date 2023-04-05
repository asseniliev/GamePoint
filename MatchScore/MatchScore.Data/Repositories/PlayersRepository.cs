using EnumsNET;
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
    public class PlayersRepository : IPlayersRepository
    {
        private ApplicationContext context;

        public PlayersRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public List<Player> GetAll()
        {
            var players = this.GetPlayers().ToList();
            return players;
        }

        public Player GetById(int playerId)
        {
            var player = this.GetPlayers().FirstOrDefault(p => p.PlayerId == playerId);
            return player ?? throw new EntityNotFoundException(string.Format(Messages.DoesNotExistErrorLong, "Player", "id", playerId));

        }

        public Player GetByName(string playerName)
        {
            var player = this.GetPlayers().FirstOrDefault(p => p.Name.ToLower() == playerName.ToLower());
            return player ?? throw new EntityNotFoundException(string.Format(Messages.DoesNotExistErrorLong, "Player", "name", playerName));

        }

        public PaginatedList<Player> FilterBy(PlayerQueryParameters parameters)
        {
            IQueryable<Player> players = this.GetPlayers();

            players = FilterByName(players, parameters.Name);
            players = FilterByCountry(players, parameters.Country);
            players = FilterBySportsClub(players, parameters.SportsClub);
            players = FilterByActiveStatus(players, parameters.Active);
            players = SortBy(players, parameters.SortBy);
            var result = SortOrder(players, parameters.SortOrder).ToList();

            return new PaginatedList<Player>(result, parameters.PageSize, parameters.CurrentPage);
        }

        public Player Create(Player player)
        {
            this.context.Players.Add(player);
            this.context.SaveChanges();
            return GetById(player.PlayerId);
        }

        public void Update(Player player)
        {
            this.context.Players.Update(player);
        }

        public void SaveDatabase()
        {
            this.context.SaveChanges();
        }

        #region Private Methods

        private IQueryable<Player> GetPlayers()
        {
            return this.context.Players.Where(p => !p.IsDeleted)
                .Include(p => p.SportsClub)
                .Include(p => p.Scores.Where(s => !s.IsDeleted))
                    .ThenInclude(s => s.Match)
                        .ThenInclude(m => m.Scores.Where(s => !s.IsDeleted))
                            .ThenInclude(s => s.Player)
                .Include(p => p.Scores.Where(s => !s.IsDeleted))
                    .ThenInclude(s => s.Match)
                        .ThenInclude(m => m.Event)
                .Include(p => p.Scores.Where(s => !s.IsDeleted))
                    .ThenInclude(s => s.Match)
                        .ThenInclude(m => m.Location)
                .Include(p => p.Rankings.Where(r => !r.IsDeleted))
                    .ThenInclude(r => r.Event)
                        .ThenInclude(e => e.Champion);
        }

        private static IQueryable<Player> FilterByName(IQueryable<Player> players, string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                return players.Where(p => p.Name.ToLower().Contains(name.ToLower()));
            }
            return players;
        }

        private static IQueryable<Player> FilterByCountry(IQueryable<Player> players, Countries country)
        {
            if (country != 0)
            {
                return players.Where(p => p.Country == country);
            }
            return players;
        }

        private static IQueryable<Player> FilterBySportsClub(IQueryable<Player> players, string sportsClub)
        {
            if (!string.IsNullOrEmpty(sportsClub))
            {
                return players.Where(p => p.SportsClub != null && p.SportsClub.Name.ToLower().Contains(sportsClub.ToLower()));
            }
            return players;
        }

        private static IQueryable<Player> FilterByActiveStatus(IQueryable<Player> players, string activeStatus)
        {
            if (!string.IsNullOrEmpty(activeStatus))
            {
                if (activeStatus == "true")
                {
                    return players.Where(p => !p.IsInactive);
                }
                else if (activeStatus == "false")
                {
                    return players.Where(p => p.IsInactive);
                }
            }
            return players;
        }

        private static IQueryable<Player> SortBy(IQueryable<Player> players, string sortBy)
        {
            switch (sortBy)
            {
                case "name":
                    return players.OrderBy(p => p.Name);
                case "matches":
                    return players.OrderBy(p => p.Scores.Count);
                case "wins":
                    return players.OrderBy(p => (p.Scores.Where(s =>
                        s.Match.Scores.Where(s => s.PlayerScore != null).OrderByDescending(s => s.PlayerScore).First().PlayerScore
                        !=
                        s.Match.Scores.Where(s => s.PlayerScore != null).OrderByDescending(s => s.PlayerScore).Skip(1).First().PlayerScore
                        &&
                        s.Match.Scores.Where(s => s.PlayerScore != null).OrderByDescending(s => s.PlayerScore).First().PlayerId
                        == p.PlayerId
                        )).Count());
                default:
                    return players;
            }
        }

        private static IEnumerable<Player> SortOrder(IQueryable<Player> players, string sortOrder)
        {
            switch (sortOrder)
            {
                case "desc":
                    return players.AsEnumerable().Reverse();
                default:
                    return players;
            }
        }
        #endregion
    }
}

