using System;
using MatchScore.Data.Models;
using MatchScore.Web.ViewModels.PlayerViewModels;

namespace MatchScore.Web.ViewModels.RankViewModels
{
    public class RankShortVM
    {
        public PlayerShortVM Player { get; set; }

        public int Rank { get; set; }
    }
}

