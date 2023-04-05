using System.Collections.Generic;

namespace MatchScore.Web.ViewModels.UserViewModels
{
    public class UserListVM
    {
        public List<UserIndexVM> Users;

        public bool HasPrevPage;

        public bool HasNextPage;

        public int CurrentPage;
    }
}
