using MatchScore.Data.Constants;
using MatchScore.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MatchScore.Web.DTOs.EventDTOs
{
    public class EventPostDto
    {
        private const string EarliestDate = "1960-01-01";

        private const string LatestDate = "2099-12-31";

        [Required]
        [StringLength(32, MinimumLength = 4, ErrorMessage = Messages.StringMinLengthError)]
        public string Title { get; set; }

        public EventTypes EventType { get; set; }

        public MatchTypes matchType { get; set; }

        public int ScoreForWin { get; set; }

        public int ScoreForDraw { get; set; }

        [Range(typeof(DateTime), EarliestDate, LatestDate, ErrorMessage = Messages.InvalidDate)]
        public DateTime StartDate { get; set; }

        //[DateLessThan("StartDate", ErrorMessage = Messages.InvalidEndDate)]
        public DateTime EndDate { get; set; }

        public int LocationId { get; set; }

        public bool IsTeamEvent { get; set; }

        public int MatchLimitValue { get; set; }

    }
}
