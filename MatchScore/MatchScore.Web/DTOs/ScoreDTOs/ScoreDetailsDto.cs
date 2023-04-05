using System;
using MatchScore.Data.Models;
using MatchScore.Web.DTOs.MatchDTOs;
using MatchScore.Web.ViewModels.MatchViewModels;
using MatchScore.Web.ViewModels.PlayerViewModels;

namespace MatchScore.Web.DTOs.ScoreDTOs
{
	public class ScoreDetailsDto
	{
        public MatchShortDto Match { get; set; }

        public PlayerShortVM Player { get; set; }

        public int Round { get; set; }

        public double? PlayerScore { get; set; }

        public int ScoredPoints { get; set; }
    }
}

