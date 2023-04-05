using MatchScore.Data.Helpers;
using MatchScore.Data.Models;
using MatchScore.Data.Models.QueryParameters;
using System.Linq;

namespace MatchScore.Data.Repositories.Contracts
{
    public interface IUsersRepository
    {
        User Create(User userToCreate);

        IQueryable<User> GetAll();

        User GetById(int userId);

        PaginatedList<User> FilterBy(UserQueryParameters userQueryParameters);

        void Update(User userToUpdate);

        void SaveDatabase();
    }
}
