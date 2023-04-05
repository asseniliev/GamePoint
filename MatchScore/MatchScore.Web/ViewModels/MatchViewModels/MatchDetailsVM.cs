using System;
using MatchScore.Data.Models;
using System.Collections.Generic;
using MatchScore.Web.ViewModels.EventViewModels;
using MatchScore.Data.Enums;
using MatchScore.Web.ViewModels.PlayerViewModels;
using MatchScore.Web.ViewModels.WeatherViewModels;

namespace MatchScore.Web.ViewModels.MatchViewModels
{
    public class MatchDetailsVM
    {
        public int MatchId { get; set; }

        public DateTime Date { get; set; }

        public string LocationCity { get; set; }

        public Countries LocationCountry { get; set; }

        public string LocationLatitude { get; set; }

        public string LocationLongitude { get; set; }

        public EventShortVM Event { get; set; }

        public List<double?> Scores { get; set; } = new List<double?>();

        public List<PlayerShortVM> Players { get; set; } = new List<PlayerShortVM>();

        public Forecast Forecast { get; set; } = new Forecast();
    }
}

