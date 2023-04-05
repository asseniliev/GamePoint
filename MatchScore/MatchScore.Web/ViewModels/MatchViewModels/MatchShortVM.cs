using System;
using MatchScore.Data.Models;
using System.Collections.Generic;
using MatchScore.Data.Enums;
using MatchScore.Web.ViewModels.PlayerViewModels;

namespace MatchScore.Web.ViewModels.MatchViewModels
{
    public class MatchShortVM
    {
        public int MatchId { get; set; }

        public DateTime Date { get; set; }

        public Location Location { get; set; }
        
        public string LocationCity { get; set; }

        public Countries LocationCountry { get; set; }

        public int EventId { get; set; }

        public string EventTitle { get; set; }

        public int? WinnerId { get; set; }

        public string WinnerName { get; set; }

        public List<PlayerShortVM> Players { get; set; }

        public int Round { get; set; }
    }
}

