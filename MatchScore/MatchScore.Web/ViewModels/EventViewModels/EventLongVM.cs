using System;
using MatchScore.Data.Enums;

namespace MatchScore.Web.ViewModels.EventViewModels
{
    public class EventLongVM
    {
        public int EventId { get; set; }

        public string Title { get; set; }

        public int DirectorId { get; set; }

        public string Director { get; set; }

        public EventTypes EventType { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsTeamEvent { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public int ChampionId { get; set; }

        public string Champion { get; set; }

        public bool HasMatchesWithScores { get; set; }

        public bool IsCompleted { get; set; }

    }
}

