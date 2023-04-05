using MatchScore.Data.Helpers;
using MatchScore.Data.Models;
using MatchScore.Data.Models.QueryParameters;
using System.Collections.Generic;

namespace MatchScore.Services.Services.Contracts
{
    public interface IUsersService
    {
        User Create(User userToCreate);

        IEnumerable<User> GetAll();

        User GetById(int userId);

        User GetByUsername(string username);

        PaginatedList<User> FilterBy(UserQueryParameters userQueryParameters);

        User Update(int userId, User userUpdates);

        void Delete(int userId);

        void Delete(List<User> usersToDelete);
    }
}
