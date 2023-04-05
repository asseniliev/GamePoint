using System;
using System.Collections.Generic;
using MatchScore.Data.Enums;
using MatchScore.Web.ViewModels.MatchViewModels;
using MatchScore.Web.ViewModels.PlayerViewModels;
using MatchScore.Web.ViewModels.RankViewModels;
using MatchScore.Web.ViewModels.WeatherViewModels;

namespace MatchScore.Web.ViewModels.EventViewModels
{
    public class EventDetailsVM
    {
        public int EventId { get; set; }

        public string Title { get; set; }

        public EventTypes EventType { get; set; }

        public bool IsTeamEvent { get; set; }

        public int DirectorUserId { get; set; }

        public string DirectorUsername { get; set; }

        public int? ChampionId { get; set; }

        public string ChampionName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string LocationCity { get; set; }

        public Countries LocationCountry { get; set; }

        public string LocationLatitude { get; set; }

        public string LocationLongitude { get; set; }

        public List<MatchShortVM> Matches { get; set; } = new List<MatchShortVM>();

        public List<RankShortVM> Ranking { get; set; } = new List<RankShortVM>();

        public List<decimal> AwardsPrize = new List<decimal>();

        public bool NoMatchesPlayed { get; set; }

        public bool IsComleted { get; set; }
        public Forecast Forecast { get; set; } = new Forecast();

        public MultiRoundEventVM MultiRoundEvent { get; set; }
    }
}

