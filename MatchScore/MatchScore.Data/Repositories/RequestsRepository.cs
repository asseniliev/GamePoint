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
    public class RequestsRepository : IRequestsRepository
    {
        #region State
        private readonly ApplicationContext applicationContext;

        public RequestsRepository(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }
        #endregion

        #region CRUD Methods
        public Request Create(Request requestToCreate)
        {
            this.applicationContext.Requests.Add(requestToCreate);

            this.applicationContext.SaveChanges();

            return requestToCreate;
        }
        public IQueryable<Request> GetAll()
        {
            IQueryable<Request> allRequests = this.applicationContext.Requests
                .Where(r => !r.IsDeleted)
                    .Include(r => r.User)
                    .Include(r => r.Player);

            return allRequests;
        }

        public Request GetById(int requestId)
        {
            Request requestToGet = this.GetAll()
                .Where(r => r.RequestId == requestId)
                .FirstOrDefault();

            return requestToGet;
        }

        public PaginatedList<Request> FilterBy(RequestQueryParameters requestQueryParameters)
        {
            IQueryable<Request> requestsToFilter = this.GetAll();

            requestsToFilter = FilterByUsername(requestsToFilter, requestQueryParameters.Username);

            requestsToFilter = FilterByRequestType(requestsToFilter, requestQueryParameters.RequestType);

            requestsToFilter = FilterByRequestStatus(requestsToFilter, requestQueryParameters.RequestStatus);

            requestsToFilter = SortBy(requestsToFilter, requestQueryParameters.SortBy);

            requestsToFilter = SortOrder(requestsToFilter, requestQueryParameters.SortOrder);

            PaginatedList<Request> filteredRequests = new PaginatedList<Request>(requestsToFilter.ToList(), requestQueryParameters.PageSize, requestQueryParameters.CurrentPage);

            return filteredRequests;
        }

        public void Update(Request requestToUpdate)
        {
            this.applicationContext.Requests.Update(requestToUpdate);
        }

        public void SaveDatabase()
        {
            this.applicationContext.SaveChanges();
        }
        #endregion

        #region Private Methods
        private static IQueryable<Request> FilterByUsername(IQueryable<Request> requestsToFilter, string username)
        {
            if (!string.IsNullOrEmpty(username))
            {
                requestsToFilter = requestsToFilter
                    .Where(r => r.User.Username.Contains(username, StringComparison.InvariantCultureIgnoreCase));
            }

            return requestsToFilter;
        }

        private static IQueryable<Request> FilterByRequestType(IQueryable<Request> requestsToFilter, string requestType)
        {
            if (!string.IsNullOrEmpty(requestType))
            {
                requestsToFilter = requestsToFilter
                    .Where(r => r.RequestType.ToString().Equals(requestType, StringComparison.InvariantCultureIgnoreCase));
            }

            return requestsToFilter;
        }

        private static IQueryable<Request> FilterByRequestStatus(IQueryable<Request> requestsToFilter, string requestStatus)
        {
            if (!string.IsNullOrEmpty(requestStatus))
            {
                requestsToFilter = requestsToFilter
                    .Where(r => r.RequestStatus.ToString().Equals(requestStatus, StringComparison.InvariantCultureIgnoreCase));
            }

            return requestsToFilter;
        }

        private static IQueryable<Request> SortBy(IQueryable<Request> requestsToFilter, string sortBy)
        {
            switch (sortBy)
            {
                case "type":
                    return requestsToFilter.OrderBy(r => r.RequestType);
                case "username":
                    return requestsToFilter.OrderBy(r => r.User.Username);
                case "player":
                    return requestsToFilter.OrderBy(r => r.PlayerId);
                case "status":
                    return requestsToFilter.OrderBy(r => r.RequestStatus);
                default:
                    return requestsToFilter.OrderBy(r => r.CreatedOn);
            }
        }

        private static IQueryable<Request> SortOrder(IQueryable<Request> requestsToFilter, string sortOrder)
        {
            switch (sortOrder)
            {
                case "desc":
                    return requestsToFilter.Reverse();
                default:
                    return requestsToFilter;
            }
        }
        #endregion
    }
}
