using MatchScore.Data.Enums;
using MatchScore.Web.ViewModels.EventViewModels;
using System;
using System.Collections.Generic;

namespace MatchScore.Web.ViewModels.UserViewModels
{
    public class UserDetailsVM
    {
        public int UserId { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public Roles Role { get; set; }

        public DateTime CreatedOn { get; set; }

        public string PlayerName { get; set; }

        public List<EventLongVM> Events { get; set; }

        public bool IsInactive { get; set; }
    }
}
