using MatchScore.Data.Models;
using MatchScore.Web.ViewModels.EventViewModels;
using System;

namespace MatchScore.Web.Helpers.Args
{
    public class MatchUpdatedArgs : EventArgs
    {
        public EventEditVM Event { get; set; }

        public Score Scores { get; set; }

        public User User { get; set; }
    }
}
