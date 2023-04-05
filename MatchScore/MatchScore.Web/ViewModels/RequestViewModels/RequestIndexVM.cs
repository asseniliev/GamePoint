using MatchScore.Data.Enums;
using System;

namespace MatchScore.Web.ViewModels.RequestViewModels
{
    public class RequestIndexVM
    {
        public int RequestId { get; set; }

        public RequestTypes RequestType { get; set; }

        public int UserId { get; set; }

        public string Username { get; set; }
        
        public int PlayerId { get; set; }

        public string PlayerName { get; set; }

        public RequestStatus RequestStatus { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
