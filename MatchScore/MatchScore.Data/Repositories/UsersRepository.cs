using MatchScore.Data.Data;
using MatchScore.Data.Helpers;
using MatchScore.Data.Models;
using MatchScore.Data.Models.QueryParameters;
using MatchScore.Data.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace MatchScore.Data.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        #region State
        private readonly ApplicationContext applicationContext;

        public UsersRepository(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }
        #endregion

        #region CRUD Methods
        public User Create(User userToCreate)
        {
            this.applicationContext.Users.Add(userToCreate);

            this.applicationContext.SaveChanges();

            User createdUesr = GetById(userToCreate.UserId);

            return createdUesr;
        }

        public IQueryable<User> GetAll()
        {
            IQueryable<User> allUsers = this.applicationContext.Users
                .Where(u => !u.IsDeleted)
                .Include(u => u.Player);
            //.Include(u => u.Events.Where(e => !e.IsDeleted));

            return allUsers;
        }

        public User GetById(int userId)
        {
            User userToGet = this.GetAll()
                .Where(u => u.UserId == userId)
                    .Include(u => u.Player)
                .FirstOrDefault();

            return userToGet;
        }

        public PaginatedList<User> FilterBy(UserQueryParameters userQueryParameters)
        {
            IQueryable<User> usersToFilter = this.GetAll();

            usersToFilter = FilterByUsername(usersToFilter, userQueryParameters.Username);

            usersToFilter = FilterByPlayer(usersToFilter, userQueryParameters.Player);

            usersToFilter = FilterByRole(usersToFilter, userQueryParameters.Role);

            usersToFilter = SortBy(usersToFilter, userQueryParameters.SortBy);

            usersToFilter = SortOrder(usersToFilter, userQueryParameters.SortOrder);

            PaginatedList<User> filteredUsers = new PaginatedList<User>(usersToFilter.ToList(), userQueryParameters.PageSize, userQueryParameters.CurrentPage);

            return filteredUsers;
        }

        public void Update(User userToUpdate)
        {
            this.applicationContext.Users.Update(userToUpdate);
        }

        public void SaveDatabase()
        {
            this.applicationContext.SaveChanges();
        }
        #endregion

        #region Private Methods
        private static IQueryable<User> FilterByUsername(IQueryable<User> usersToFilter, string username)
        {
            if (!string.IsNullOrEmpty(username))
            {
                usersToFilter = usersToFilter
                    .Where(u => u.Username.Contains(username/*, StringComparison.InvariantCultureIgnoreCase*/));
            }

            return usersToFilter;
        }

        private static IQueryable<User> FilterByPlayer(IQueryable<User> usersToFilter, string player)
        {
            if (!string.IsNullOrEmpty(player))
            {
                usersToFilter = usersToFilter
                    .Where(u => u.Player.Name.Contains(player/*, StringComparison.InvariantCultureIgnoreCase*/));
            }

            return usersToFilter;
        }

        private static IQueryable<User> FilterByRole(IQueryable<User> usersToFilter, string role)
        {
            if (!string.IsNullOrEmpty(role))
            {
                usersToFilter = usersToFilter
                    .Where(u => u.Role.ToString().Equals(role/*, StringComparison.InvariantCultureIgnoreCase*/));
            }

            return usersToFilter;
        }

        private static IQueryable<User> SortBy(IQueryable<User> usersToFilter, string sortBy)
        {
            switch (sortBy)
            {
                case "username":
                    return usersToFilter.OrderBy(u => u.Username);
                case "role":
                    return usersToFilter.OrderBy(u => u.Role);
                case "player":
                    return usersToFilter.OrderBy(u => u.Player.Name);
                case "events":
                    return usersToFilter.OrderBy(u => u.Events.Count);
                case "status":
                    return usersToFilter.OrderBy(u => u.IsInactive);
                default:
                    return usersToFilter;
            }
        }

        private static IQueryable<User> SortOrder(IQueryable<User> usersToFilter, string sortOrder)
        {
            switch (sortOrder)
            {
                case "desc":
                    return usersToFilter.Reverse();
                default:
                    return usersToFilter;
            }
        }
        #endregion
    }
}
