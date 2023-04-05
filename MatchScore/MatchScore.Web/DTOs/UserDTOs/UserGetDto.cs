namespace MatchScore.Web.DTOs.UserDTOs
{
    public class UserGetDto
    {
        public int UserId { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }

        public string CreatedOn { get; set; }

        public string PlayerName { get; set; }

        public int RequestsCount { get; set; }

        public int EventsCount { get; set; }

        public bool IsInactive { get; set; }

        public bool IsDeleted { get; set; }
    }
}
