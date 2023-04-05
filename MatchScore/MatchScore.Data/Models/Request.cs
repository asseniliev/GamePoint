using MatchScore.Data.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace MatchScore.Data.Models
{
    public class Request
    {
        [Key]
        public int RequestId { get; set; }

        public RequestTypes RequestType { get; set; }

        public RequestStatus RequestStatus { get; set; }

        public DateTime CreatedOn { get; set; }

        // Foreign key
        public int? UserId { get; set; }

        // Navigation property
        public User User { get; set; }

        // Foreign key
        public int? PlayerId { get; set; }

        // Navigation property
        public Player Player { get; set; }

        public bool IsDeleted { get; set; }
    }
}
