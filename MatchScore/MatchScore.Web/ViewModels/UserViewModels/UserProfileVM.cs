using MatchScore.Web.ViewModels.EventViewModels;
using MatchScore.Web.ViewModels.PlayerViewModels;
using MatchScore.Web.ViewModels.RequestViewModels;
using System.Collections.Generic;

namespace MatchScore.Web.ViewModels.UserViewModels
{
    public class UserProfileVM
    {
        public UserEditVM User { get; set; }

        public List<UserIndexVM> Users { get; set; }

        public List<PlayerShortVM> Players { get; set; }

        public List<RequestIndexVM> Requests { get; set; }

        public List<EventLongVM> Events { get; set; }
    }
}
