using System;
using MatchScore.Data.Enums;
using MatchScore.Data.Models;

namespace MatchScore.Web.DTOs.MatchDTOs
{
	public class MatchShortDto
	{
        public int MatchId { get; set; }

        public DateTime Date { get; set; }

        public Location Location { get; set; }

        public string LocationCity { get; set; }

        public Countries LocationCountry { get; set; }

        public int Round { get; set; }
    }
}

