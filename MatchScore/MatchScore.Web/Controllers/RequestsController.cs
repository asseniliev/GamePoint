using AutoMapper;
using MatchScore.Data.Enums;
using MatchScore.Data.Helpers;
using MatchScore.Data.Models;
using MatchScore.Data.Models.QueryParameters;
using MatchScore.Services.Services.Contracts;
using MatchScore.Web.Helpers;
using MatchScore.Web.Helpers.Args;
using MatchScore.Web.ViewModels.RequestViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MatchScore.Web.Controllers
{
    [Authorize]
    public class RequestsController : Controller
    {
        private readonly IUsersService usersService;
        private readonly IRequestsService requestsService;
        private readonly IMapper mapper;
        private readonly AuthHelper authHelper;
        private readonly EmailHelper emailHelper;

        public delegate void RequestProcessedEventHandler(object source, RequestProcessArgs args);

        public event RequestProcessedEventHandler RequestProcessed;

        public RequestsController(IUsersService usersService, IRequestsService requestsService, IMapper mapper, AuthHelper authHelper, EmailHelper emailHelper)
        {
            this.usersService = usersService;
            this.requestsService = requestsService;
            this.mapper = mapper;
            this.authHelper = authHelper;
            this.emailHelper = emailHelper;
        }

        [HttpGet]
        public IActionResult Index(RequestQueryParameters requestQueryParameters)
        {
            if (requestQueryParameters.SortBy == null)
            {
                this.ViewData["SortOrder"] = "";
            }
            else if (requestQueryParameters.IsHeader)
            {
                this.ViewData["SortOrder"] = string.IsNullOrEmpty(requestQueryParameters.SortOrder) ? "desc" : "";
            }

            this.ViewData["PaginationSortOrder"] = requestQueryParameters.PaginationSortOrder;

            this.ViewData["SortBy"] = requestQueryParameters.SortBy;

            PaginatedList<Request> requests = this.requestsService.FilterBy(requestQueryParameters);

            List<RequestIndexVM> requestIndexVMs = requests.Select(r => this.mapper.Map<RequestIndexVM>(r)).ToList();

            RequestListVM requestListVM = new RequestListVM
            {
                Requests = requestIndexVMs,
                CurrentPage = requests.CurrentPage,
                HasPrevPage = requests.HasPrevPage,
                HasNextPage = requests.HasNextPage
            };

            return this.View(requestListVM);
        }

        [HttpPost]
        public IActionResult AssociateRequest(int userId, int playerId)
        {
            RequestCreateVM newRequest = new RequestCreateVM
            {
                RequestType = RequestTypes.Associate.ToString(),
                UserId = userId,
                PlayerId = playerId
            };

            Request requestToCreate = this.mapper.Map<Request>(newRequest);

            this.requestsService.Create(requestToCreate);

            return RedirectToAction("Edit", "Users", new { userId });
        }

        [HttpPost]
        public IActionResult PromoteRequest(int userId)
        {
            RequestCreateVM newRequest = new RequestCreateVM
            {
                UserId = userId,
                RequestType = RequestTypes.Promote.ToString()
            };

            Request requestToCreate = this.mapper.Map<Request>(newRequest);

            this.requestsService.Create(requestToCreate);

            return RedirectToAction("Edit", "Users", new { userId });
        }

        [HttpGet]
        public IActionResult ProcessRequest(int requestId, string requestStatus, string sortBy)
        {
            Request requestToProcess = this.requestsService.GetById(requestId);

            if (requestStatus.Equals("approved", StringComparison.CurrentCultureIgnoreCase))
            {
                requestToProcess.RequestStatus = RequestStatus.Approved;

                Request processedRequest = this.requestsService.Update(requestId, requestToProcess);

                if (processedRequest.RequestType.Equals(RequestTypes.Associate))
                {
                    Data.Models.User userUpdates = processedRequest.User;

                    userUpdates.PlayerId = processedRequest.PlayerId;

                    this.usersService.Update(userUpdates.UserId, userUpdates);
                }
                else
                {
                    Data.Models.User userUpdates = processedRequest.User;

                    userUpdates.Role = Roles.Director;

                    this.usersService.Update(userUpdates.UserId, userUpdates);
                }
            }
            else
            {
                requestToProcess.RequestStatus = RequestStatus.Declined;

                this.requestsService.Update(requestId, requestToProcess);

            }

            this.RequestProcessed += this.emailHelper.OnRequestProcessed;

            this.OnRequestProcessed(requestToProcess);

            return RedirectToAction("Index", "Requests", new { sortBy });
        }

        protected virtual void OnRequestProcessed(Request requestToProcess)
        {
            if (RequestProcessed != null)
            {
                RequestProcessed(this, new RequestProcessArgs() { Request = requestToProcess });
            }
        }
    }
}
