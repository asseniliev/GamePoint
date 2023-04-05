using MatchScore.Data.Enums;
using MatchScore.Data.Helpers;
using MatchScore.Data.Models;
using MatchScore.Data.Models.QueryParameters;
using MatchScore.Data.Repositories.Contracts;
using MatchScore.Services.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MatchScore.Services.Services
{
    public class UsersService : IUsersService
    {
        #region State
        private readonly IUsersRepository usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }
        #endregion

        #region CRUD Methods
        public User Create(User userToCreate)
        {
            userToCreate.CreatedOn = DateTime.Now;

            userToCreate.Role = Roles.User;

            User createdUser = this.usersRepository.Create(userToCreate);

            return createdUser;
        }

        public IEnumerable<User> GetAll()
        {
            IEnumerable<User> users = this.usersRepository.GetAll().ToList();

            return users;
        }

        public User GetById(int userId)
        {
            User userToGet = this.usersRepository.GetById(userId);

            return userToGet;
        }

        public User GetByUsername(string username)
        {
            User userToGet = this.usersRepository.GetAll()
                .Where(u => u.Username == username)
                .FirstOrDefault();

            return userToGet;
        }

        public PaginatedList<User> FilterBy(UserQueryParameters userQueryParameters)
        {
            PaginatedList<User> users = this.usersRepository.FilterBy(userQueryParameters);

            return users;
        }

        public User Update(int userId, User userUpdates)
        {
            User userToUpdate = this.usersRepository.GetById(userId);

            userToUpdate.PasswordHash = userUpdates.PasswordHash;

            userToUpdate.Email = userUpdates.Email;

            userToUpdate.PlayerId = userUpdates.PlayerId;

            userToUpdate.Role = userUpdates.Role;

            userToUpdate.IsInactive = userUpdates.IsInactive;

            this.usersRepository.Update(userToUpdate);

            this.usersRepository.SaveDatabase();

            User updatedUser = this.usersRepository.GetById(userId);

            return updatedUser;
        }

        public void Delete(int userId)
        {
            User userToDelete = this.usersRepository.GetById(userId);

            userToDelete.IsDeleted = true;

            this.usersRepository.Update(userToDelete);

            this.usersRepository.SaveDatabase();
        }

        public void Delete(List<User> usersToDelete)
        {
            foreach (User user in usersToDelete)
            {
                user.IsDeleted = true;

                this.usersRepository.Update(user);
            }

            this.usersRepository.SaveDatabase();
        }
        #endregion
    }
}
