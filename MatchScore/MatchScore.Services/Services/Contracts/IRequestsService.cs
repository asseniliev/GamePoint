using MatchScore.Data.Helpers;
using MatchScore.Data.Models;
using MatchScore.Data.Models.QueryParameters;
using System.Collections.Generic;

namespace MatchScore.Services.Services.Contracts
{
    public interface IRequestsService
    {
        Request Create(Request requestToCreate);

        IEnumerable<Request> GetAll();

        Request GetById(int requestId);

        PaginatedList<Request> FilterBy(RequestQueryParameters requestQueryParameters);

        Request Update(int requestId, Request requestUpdates);

        void Delete(int requestId);

        void Delete(List<Request> requestsToDelete);
    }
}
