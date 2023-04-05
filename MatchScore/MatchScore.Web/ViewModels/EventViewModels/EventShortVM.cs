using System;
using MatchScore.Data.Enums;

namespace MatchScore.Web.ViewModels.EventViewModels
{
    public class EventShortVM
    {
        public int EventId { get; set; }

        public string Title { get; set; }

        public EventTypes EventType { get; set; }

        public int? ChampionId { get; set; }

        public string ChampionName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}

