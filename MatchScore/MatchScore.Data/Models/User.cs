using MatchScore.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MatchScore.Data.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string Username { get; set; }

        public byte[] PasswordSalt { get; set; }

        public byte[] PasswordHash { get; set; }

        public string Email { get; set; }

        public Roles Role { get; set; }

        public DateTime CreatedOn { get; set; }

        // Foreign key
        public int? PlayerId { get; set; }

        // Navigation property
        public Player Player { get; set; }

        public List<Request> Requests { get; set; }

        public List<Event> Events { get; set; }

        public bool IsInactive { get; set; }

        public bool IsDeleted { get; set; }
    }
}
