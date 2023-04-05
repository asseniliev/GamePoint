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
    public class RequestsService : IRequestsService
    {
        private readonly IRequestsRepository requestsRepository;

        public RequestsService(IRequestsRepository requestsRepository)
        {
            this.requestsRepository = requestsRepository;
        }

        public Request Create(Request requestToCreate)
        {
            requestToCreate.CreatedOn = DateTime.Now;

            Request createdRequest = this.requestsRepository.Create(requestToCreate);

            return createdRequest;
        }

        public IEnumerable<Request> GetAll()
        {
            IEnumerable<Request> requests = this.requestsRepository.GetAll().ToList();

            return requests;
        }

        public Request GetById(int requestId)
        {
            Request requestToGet = this.requestsRepository.GetById(requestId);

            return requestToGet;
        }

        public PaginatedList<Request> FilterBy(RequestQueryParameters requestQueryParameters)
        {
            PaginatedList<Request> requests = this.requestsRepository.FilterBy(requestQueryParameters);

            return requests;
        }

        public Request Update(int requestId, Request requestUpdates)
        {
            Request requestToUpdate = this.requestsRepository.GetById(requestId);

            requestToUpdate.RequestStatus = requestUpdates.RequestStatus;

            this.requestsRepository.Update(requestToUpdate);

            this.requestsRepository.SaveDatabase();

            Request updatedRequest = this.requestsRepository.GetById(requestId);

            return updatedRequest;
        }

        public void Delete(int requestId)
        {
            Request requestToDelete = this.requestsRepository.GetById(requestId);

            requestToDelete.IsDeleted = true;

            this.requestsRepository.Update(requestToDelete);

            this.requestsRepository.SaveDatabase();
        }

        public void Delete(List<Request> requestsToDelete)
        {
            foreach (Request request in requestsToDelete)
            {
                request.IsDeleted = true;

                this.requestsRepository.Update(request);
            }

            this.requestsRepository.SaveDatabase();
        }
    }
}
