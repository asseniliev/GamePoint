using System;
using System.ComponentModel.DataAnnotations;
using MatchScore.Data.Models;

namespace MatchScore.Web.DTOs.ScoreDTOs
{
	public class ScoreCreateDto
	{
        [Required]
        public int MatchId { get; set; }

        [Required]
        public int PlayerId { get; set; }

        public int Round { get; set; }

        [Range(0, double.MaxValue)]
        public double? PlayerScore { get; set; }

        [Range(0, int.MaxValue)]
        public int ScoredPoints { get; set; }
    }
}

