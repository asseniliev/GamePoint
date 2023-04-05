using MatchScore.Web.ViewModels.EventViewModels;
using MatchScore.Web.ViewModels.PlayerViewModels;
using System.Collections.Generic;

namespace MatchScore.Web.ViewModels.UserViewModels
{
    public class EventIndexVM
    {
        public List<EventLongVM> Events;

        public bool HasPrevPage;

        public bool HasNextPage;

        public int CurrentPage;
    }
}
