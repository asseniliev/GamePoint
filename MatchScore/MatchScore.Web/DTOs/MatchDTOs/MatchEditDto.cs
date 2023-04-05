using System;
using System.ComponentModel.DataAnnotations;

namespace MatchScore.Web.DTOs.MatchDTOs
{
    public class MatchEditDto
    {
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int LocationId { get; set; }
    }
}

