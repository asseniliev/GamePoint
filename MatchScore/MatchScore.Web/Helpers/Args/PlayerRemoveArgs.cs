using MatchScore.Data.Models;
using System;

namespace MatchScore.Web.Helpers.Args
{
    public class PlayerRemoveArgs : EventArgs
    {
        public Event @event { get; set; }

        public User User { get; set; }

        public Player Player { get; set; }
    }
}
