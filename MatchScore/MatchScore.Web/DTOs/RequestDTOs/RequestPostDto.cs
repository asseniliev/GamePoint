using MatchScore.Data.Enums;

namespace MatchScore.Web.DTOs.RequestDTOs
{
    public class RequestPostDto
    {
        public RequestTypes RequestType { get; set; }

        public int UserId { get; set; }

        public int? PlayerId { get; set; }
    }
}
