using MatchScore.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace MatchScore.Data.Models
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }

        public string City { get; set; }

        public Countries Country { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }
    }
}

