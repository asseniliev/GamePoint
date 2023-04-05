using System.Collections.Generic;

namespace MatchScore.Web.ViewModels.RequestViewModels
{
    public class RequestListVM
    {
        public List<RequestIndexVM> Requests;

        public bool HasPrevPage;

        public bool HasNextPage;

        public int CurrentPage;
    }
}
