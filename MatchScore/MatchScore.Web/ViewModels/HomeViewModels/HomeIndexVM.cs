using System;
using System.Collections.Generic;
using MatchScore.Data.Models;
using MatchScore.Web.ViewModels.EventViewModels;
using MatchScore.Web.ViewModels.MatchViewModels;
using MatchScore.Web.ViewModels.PlayerViewModels;

namespace MatchScore.Web.ViewModels.HomeViewModels
{
    public class HomeIndexVM
    {
        public List<EventShortVM> LatestEvents { get; set; } = new List<EventShortVM>();

        public List<EventShortVM> FutureEvents { get; set; } = new List<EventShortVM>();

        public List<MatchShortVM> LatestMatches { get; set; } = new List<MatchShortVM>();

        public List<MatchShortVM> FutureMatches { get; set; } = new List<MatchShortVM>();

        public List<PlayerShortVM> PlayerRanklist { get; set; } = new List<PlayerShortVM>();
    }
}

