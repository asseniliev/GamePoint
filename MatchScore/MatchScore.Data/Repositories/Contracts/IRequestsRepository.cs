using MatchScore.Data.Helpers;
using MatchScore.Data.Models;
using MatchScore.Data.Models.QueryParameters;
using System.Linq;

namespace MatchScore.Data.Repositories.Contracts
{
    public interface IRequestsRepository
    {
        Request Create(Request requestToCreate);

        IQueryable<Request> GetAll();

        Request GetById(int requestId);

        PaginatedList<Request> FilterBy(RequestQueryParameters requestQueryParameters);

        void Update(Request requestToUpdate);

        void SaveDatabase();
    }
}
