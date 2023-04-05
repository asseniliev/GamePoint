using System;
using System.Collections.Generic;
using MatchScore.Web.ViewModels.PlayerViewModels;

namespace MatchScore.Web.ViewModels.SportsClubViewModels
{
    public class SportsClubDetailsVM
    {
        public int SportsClubId { get; set; }

        public string Name { get; set; }

        public List<PlayerShortVM> Players { get; set; }
    }
}

