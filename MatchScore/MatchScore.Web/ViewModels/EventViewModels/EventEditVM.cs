using MatchScore.Data.Constants;
using MatchScore.Data.Enums;
using MatchScore.Data.Helpers;
using MatchScore.Data.Models;
using MatchScore.Web.ViewModels.MatchViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MatchScore.Web.ViewModels.EventViewModels
{
    public class EventEditVM
    {
        public int EventId { get; set; }

        public string Title { get; set; }

        public EventTypes EventType { get; set; }

        public int LocationId { get; set; }

        public List<Location> Locations { get; set; }

        public string City { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public List<Ranking> Ranking { get; set; } = new List<Ranking>();

        public List<Match> Matches { get; set; }

        public List<Player> PlayersSelectionList { get; set; }

        public List<Score> Scores { get; set; } = new List<Score>();       

        public int PlayerId { get; set; }

        public bool HasCorrectNumberOfPlayers { get; set; }

        public string CorrectNumberOfPlayersInfo { get; set; }

        public MatchShortVM Match { get; set; }

        public bool HasMatchesWithScores { get; set; }

        public List<Award> Awards { get; set; }

        public bool IsCompleted { get; set; }

        // For creating player
        [StringLength(40, MinimumLength = 4, ErrorMessage = Messages.StringMinMaxLengthError)]
        public string NewPlayerName { get; set; }
    }
}
