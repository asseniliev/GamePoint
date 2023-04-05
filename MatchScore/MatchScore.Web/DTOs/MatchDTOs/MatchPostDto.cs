using System;
using MatchScore.Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MatchScore.Web.DTOs.MatchDTOs
{
    public class MatchPostDto
    {
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int EventId { get; set; }

        [Required]
        public int LocationId { get; set; }
    }
}

