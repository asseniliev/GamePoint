using MatchScore.Data.Enums;
using MatchScore.Data.Models;
using System;

namespace MatchScore.Web.DTOs.RequestDTOs
{
    public class RequestGetDto
    {
        public RequestTypes RequestType { get; set; }

        public RequestStatus RequestStatus { get; set; }

        public DateTime CreatedOn { get; set; }

        public int? UserId { get; set; }

        public User User { get; set; }

        public int? PlayerId { get; set; }

        public Player Player { get; set; }

        public bool IsDeleted { get; set; }
    }
}
