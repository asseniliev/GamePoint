using MatchScore.Data.Enums;
using MatchScore.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace MatchScore.Data.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<SportsClub> SportsClubs { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<ScoreLimitedMatch> ScoreLimitedMatches { get; set; }
        public DbSet<TimeLimitedMatch> TimeLimitedMatches { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Award> Awards { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Ranking> Rankings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Configure many-to-many relationships
            modelBuilder.Entity<Score>()
                .HasKey(pt => new { pt.MatchId, pt.PlayerId });

            modelBuilder.Entity<Ranking>()
                .HasKey(pe => new { pe.PlayerId, pe.EventId });

            modelBuilder.Entity<Award>().Property("Prize").HasColumnType("money");

            //string passwordHash1 = "0x6CC02D3E499FC0D33A467CF536CB64204389DB85618D4561FB61F7E3B4068E36FECE5DF05ADE4D406966F1CEA978CEFC5B07E5E4F76CE2C176F3046B931B1E83";
            //string passwordSalt1 = "0x8AF7A0609E467292382C219B700C3D81DCF1CDFB0433B164D0936EC3FF98419449863050B26D771BF68C2FE26B20034F21BC0BF33EDCA722132198CC199C823A250AC17D7502B7D144C7C940F1451BE24D394DF4074C86A67A024D838481D38AB11079982FCD5ACC4169814CD7BFE8880C919C4CB142326DF0F4A41A00BE8F42";

            //var trimmedPasswordHash1 = passwordHash1.Replace("0x", "").Trim();
            //var trimmedPasswordSalt1 = passwordSalt1.Replace("0x", "").Trim();

            //string passwordHash2 = "0x3A0D8C3F6BB857611C2F876A10BB5A9A53F13D1A0EB023B5637EE0256EDC9500DE58E20A3CCD1AEBFCED3649025B3F51E886774021016BB954ACBB4E4917721A";
            //string passwordSalt2 = "0x82B1952B7B55E749DBF44CF02A7E8C8327A9819CE27CA4373E0674AB6A5C4CD973B1599C4E6F832E837E79BB4615030D2EF10E6301BD9F237DF701D77AA8EBDAE9AADEC765EACA4469BF8CED93E43611D8C06D2AE9D74C05FD85A117E303BC0A00597A1479929E6E84B70D7F06951B375449659F33EFEC9BD6CE022108F83CD2";

            //var trimmedPasswordHash2 = passwordHash2.Replace("0x", "").Trim();
            //var trimmedPasswordSalt2 = passwordSalt2.Replace("0x", "").Trim();

            //string passwordHash3 = "0x6259DAEB9C5F81E5316421A9E67E6A58DFD5F976664B9EC01B0F692F4289C42E36867E492E607D23D49413571D03EDB4971B699634282765A104B4216CD7BBBD";
            //string passwordSalt3 = "0x0E15F93BB15CAC86029C85254EE8C79B2B5B9D9DA93B0F59D748C3F4488568F440575A3B3E5AFFE70189EF2CC50011112F30018A04B3279FADEAF4093AC61F6A21C12E916540B2D3C581B0B0D3C210DAD78F7BCCD86FEA0367322C2B16A27CD6E6FFAFEAA8921F5639A30F0CE4C6FB3DBFD5F76A9CF98FD6E29916A48B362FF8";

            //var trimmedPasswordHash3 = passwordHash3.Replace("0x", "").Trim();
            //var trimmedPasswordSalt3 = passwordSalt3.Replace("0x", "").Trim();

            //List<User> users = new List<User>()
            //{
            //    new User()
            //    {
            //        UserId = 1,
            //        Username = "ivan",
            //        PasswordHash = StrToByteArray(trimmedPasswordHash1),
            //        PasswordSalt = StrToByteArray(trimmedPasswordSalt1),
            //        Email = "ivan@mail.com",
            //        Role = Roles.Admin,
            //        CreatedOn = new System.DateTime(638042906640000000),
            //        PlayerId = null,
            //        IsInactive = false,
            //        IsDeleted = false
            //    },
            //    new User()
            //    {
            //        UserId = 2,
            //        Username = "asen",
            //        PasswordHash = StrToByteArray(trimmedPasswordHash2),
            //        PasswordSalt = StrToByteArray(trimmedPasswordSalt2),
            //        Email = "asen@mail.com",
            //        Role = Roles.Director,
            //        CreatedOn = new System.DateTime(638042906640000000),
            //        PlayerId = null,
            //        IsInactive = false,
            //        IsDeleted = false
            //    },
            //    new User()
            //    {
            //        UserId = 3,
            //        Username = "toto",
            //        PasswordHash = StrToByteArray(trimmedPasswordHash3),
            //        PasswordSalt = StrToByteArray(trimmedPasswordSalt3),
            //        Email = "toto@mail.com",
            //        Role = Roles.Director,
            //        CreatedOn = new System.DateTime(638042906640000000),
            //        PlayerId = null,
            //        IsInactive = false,
            //        IsDeleted = false
            //    }
            //};

            //modelBuilder.Entity<User>().HasData(users);

            //List<Player> players = new List<Player>()
            //{
            //    new Player()
            //    {
            //        PlayerId = 1,
            //        Name = "Cherno more",
            //        IsTeam = true,
            //        Country = Countries.BG,
            //        SportsClubId = 1
            //    },
            //    new Player()
            //    {
            //        PlayerId = 2,
            //        Name = "Chicago Bulls",
            //        IsTeam = true,
            //        Country = Countries.US,
            //        SportsClubId = 2
            //    },
            //    new Player()
            //    {
            //        PlayerId = 3,
            //        Name = "Aston Villa",
            //        IsTeam = true,
            //        Country = Countries.GB,
            //        SportsClubId = 3
            //    },
            //    new Player()
            //    {
            //        PlayerId = 4,
            //        Name = "Olympique Lyonnais",
            //        IsTeam = true,
            //        Country = Countries.FR,
            //        SportsClubId = 4
            //    },
            //    new Player()
            //    {
            //        PlayerId = 5,
            //        Name = "Grigor Dimitrov",
            //        Country = Countries.BG,
            //        SportsClubId = 3
            //    },
            //    new Player()
            //    {
            //        PlayerId = 6,
            //        Name = "Andre Agassi",
            //        Country = Countries.US,
            //        SportsClubId = 4
            //    }

            //};

            //modelBuilder.Entity<Player>().HasData(players);

            //List<SportsClub> sportsClubs = new List<SportsClub>()
            //{
            //    new SportsClub()
            //    {
            //        SportsClubId = 1,
            //        Name = "Cherno more"
            //    },
            //    new SportsClub()
            //    {
            //        SportsClubId = 2,
            //        Name = "Chicago Bulls"
            //    },
            //    new SportsClub()
            //    {
            //        SportsClubId = 3,
            //        Name = "Aston Villa"
            //    },
            //    new SportsClub()
            //    {
            //        SportsClubId = 4,
            //        Name = "Olympique Lionnais"
            //    }
            //};

            //modelBuilder.Entity<SportsClub>().HasData(sportsClubs);

            //List<Location> locations = new List<Location>()
            //{
            //    new Location()
            //    {
            //        LocationId = 1,
            //        City = "Sofia",
            //        Country = Countries.BG,
            //        Latitude = "42.6977",
            //        Longitude = "23.3219"
            //    },
            //    new Location()
            //    {
            //        LocationId = 2,
            //        City = "Chicago",
            //        Country = Countries.US,
            //        Latitude = "41.8781",
            //        Longitude = "-87.6298"
            //    },
            //    new Location()
            //    {
            //        LocationId = 3,
            //        City = "London",
            //        Country = Countries.GB,
            //        Latitude = "51.5072",
            //        Longitude = "-0.1276"
            //    },
            //    new Location()
            //    {
            //        LocationId = 4,
            //        City = "Lyon",
            //        Country = Countries.FR,
            //        Latitude = "45.7594",
            //        Longitude = "4.8290"
            //    }
            //};
            //modelBuilder.Entity<Location>().HasData(locations);

            //List<Match> scoreLimitedMatches = new List<Match>()
            //{
            //    new ScoreLimitedMatch()
            //    {
            //        MatchId = 1,
            //        Date = System.DateTime.Now.AddDays(8),
            //        EventId = 1,
            //        LocationId = 1,
            //        MatchScoreLimit = 6,                    
            //    }
            //};
            //List<Match> timeLimitedMatches = new List<Match>()
            //{
            //    new TimeLimitedMatch()
            //    {
            //        MatchId = 2,
            //        Date = System.DateTime.Now.AddDays(11),
            //        EventId = 2,
            //        LocationId = 1,
            //        MatchTimeLimit = 90
            //    },
            //    new TimeLimitedMatch()
            //    {
            //        MatchId = 3,
            //        Date = System.DateTime.Now.AddDays(16),
            //        EventId = 2,
            //        LocationId = 2,
            //        MatchTimeLimit = 90
            //    },
            //    new TimeLimitedMatch()
            //    {
            //        MatchId = 4,
            //        Date = System.DateTime.Now.AddDays(18),
            //        EventId = 2,
            //        LocationId = 3,
            //        MatchTimeLimit = 90
            //    },
            //    new TimeLimitedMatch()
            //    {
            //        MatchId = 5,
            //        Date = System.DateTime.Now.AddDays(20),
            //        EventId = 2,
            //        LocationId = 4,
            //        MatchTimeLimit = 90
            //    },
            //    new TimeLimitedMatch()
            //    {
            //        MatchId = 6,
            //        Date = System.DateTime.Now.AddDays(10),
            //        EventId = 2,
            //        LocationId = 2,
            //        MatchTimeLimit = 90
            //    },
            //     new TimeLimitedMatch()
            //    {
            //        MatchId = 7,
            //        Date = System.DateTime.Now.AddDays(11),
            //        EventId = 2,
            //        LocationId = 1,
            //        MatchTimeLimit = 90
            //    },
            //      new TimeLimitedMatch()
            //    {
            //        MatchId = 8,
            //        Date = System.DateTime.Now.AddDays(11),
            //        EventId = 2,
            //        LocationId = 1,
            //        MatchTimeLimit = 90
            //    },
            //       new TimeLimitedMatch()
            //    {
            //        MatchId = 9,
            //        Date = System.DateTime.Now.AddDays(11),
            //        EventId = 2,
            //        LocationId = 1,
            //        MatchTimeLimit = 90
            //    },
            //     new TimeLimitedMatch()
            //    {
            //        MatchId = 10,
            //        Date = System.DateTime.Now.AddDays(11),
            //        EventId = 2,
            //        LocationId = 1,
            //        MatchTimeLimit = 90
            //    }, new TimeLimitedMatch()
            //    {
            //        MatchId = 11,
            //        Date = System.DateTime.Now.AddDays(11),
            //        EventId = 2,
            //        LocationId = 1,
            //        MatchTimeLimit = 90
            //    },
            //    new TimeLimitedMatch()
            //    {
            //        MatchId = 12,
            //        Date = System.DateTime.Now.AddDays(11),
            //        EventId = 2,
            //        LocationId = 1,
            //        MatchTimeLimit = 90
            //    },
            //    new TimeLimitedMatch()
            //    {
            //        MatchId = 13,
            //        Date = System.DateTime.Now.AddDays(11),
            //        EventId = 2,
            //        LocationId = 1,
            //        MatchTimeLimit = 90
            //    },
            //    new TimeLimitedMatch()
            //    {
            //        MatchId = 14,
            //        Date = System.DateTime.Now.AddDays(12),
            //        EventId = 3,
            //        LocationId = 4,
            //        MatchTimeLimit = 90
            //    },
            //    new TimeLimitedMatch()
            //    {
            //        MatchId = 15,
            //        Date = System.DateTime.Now.AddDays(16),
            //        EventId = 3,
            //        LocationId = 2,
            //        MatchTimeLimit = 90
            //    },
            //    new TimeLimitedMatch()
            //    {
            //        MatchId = 16,
            //        Date = System.DateTime.Now.AddDays(16),
            //        EventId = 3,
            //        LocationId = 1,
            //        MatchTimeLimit = 90
            //    }
            //};
            //modelBuilder.Entity<TimeLimitedMatch>().HasBaseType<Match>().HasData(timeLimitedMatches);
            //modelBuilder.Entity<ScoreLimitedMatch>().HasBaseType<Match>().HasData(scoreLimitedMatches);

            //List<Event> events = new List<Event>()
            //{
            //    new Event()
            //    {
            //        EventId = 1,
            //        Title = "Single Match Event",
            //        EventType = EventTypes.SingleMatch,
            //        StartDate = System.DateTime.Now.AddDays(8),
            //        EndDate = System.DateTime.Now.AddDays(38),
            //        LocationId = 1,
            //        IsTeamEvent = false,
            //        DirectorId = 1
            //    },
            //    new Event()
            //    {
            //        EventId = 2,
            //        Title = "League",
            //        EventType = EventTypes.League,
            //        StartDate = System.DateTime.Now.AddDays(8),
            //        EndDate = System.DateTime.Now.AddDays(98),
            //        LocationId = 2,
            //        IsTeamEvent = true,
            //        DirectorId = 2,
            //        ScoreForWin = 2,
            //        ScoreForDraw = 1
            //    },
            //    new Event()
            //    {
            //        EventId = 3,
            //        Title = "Knockout Event",
            //        EventType = EventTypes.Knockout,
            //        StartDate = System.DateTime.Now.AddDays(8),
            //        EndDate = System.DateTime.Now.AddDays(98),
            //        LocationId = 3,
            //        IsTeamEvent = true,
            //        DirectorId = 2
            //    },
            //};
            //modelBuilder.Entity<Event>().HasData(events);

            //List<Score> scores = new List<Score>()
            //{
            //    new Score()
            //    {
            //        MatchId = 1,
            //        PlayerId = 5,
            //        Round = 1,
            //    },
            //    new Score()
            //    {
            //        MatchId = 1,
            //        PlayerId = 6,
            //        Round = 1
            //    },
            //    new Score()
            //    {
            //        MatchId = 2,
            //        PlayerId = 1,
            //        Round = 1
            //    },
            //    new Score()
            //    {
            //        MatchId = 2,
            //        PlayerId = 3,
            //        Round = 1

            //    },
            //    new Score()
            //    {
            //        MatchId = 3,
            //        PlayerId = 2,
            //        Round = 1
            //    },
            //    new Score()
            //    {
            //        MatchId = 3,
            //        PlayerId = 4,
            //        Round = 1
            //    },
            //    new Score()
            //    {
            //        MatchId = 4,
            //        PlayerId = 1,
            //        Round = 2
            //    },
            //    new Score()
            //    {
            //        MatchId = 4,
            //        PlayerId = 2,
            //        Round = 2
            //    },
            //    new Score()
            //    {
            //        MatchId = 5,
            //        PlayerId = 3,
            //        Round = 2
            //    },
            //    new Score()
            //    {
            //        MatchId = 5,
            //        PlayerId = 4,
            //        Round = 2
            //    },
            //    new Score()
            //    {
            //        MatchId = 6,
            //        PlayerId = 1,
            //        Round = 3
            //    },
            //    new Score()
            //    {
            //        MatchId = 6,
            //        PlayerId = 4,
            //        Round = 3
            //    },
            //    new Score()
            //    {
            //        MatchId = 7,
            //        PlayerId = 2,
            //        Round = 3
            //    },
            //    new Score()
            //    {
            //        MatchId = 7,
            //        PlayerId = 3,
            //        Round = 3
            //    },
            //    new Score()
            //    {
            //        MatchId = 8,
            //        PlayerId = 2,
            //        Round = 4
            //    },
            //    new Score()
            //    {
            //        MatchId = 8,
            //        PlayerId = 1,
            //        Round = 4
            //    },
            //    new Score()
            //    {
            //        MatchId = 9,
            //        PlayerId = 4,
            //        Round = 4
            //    },
            //    new Score()
            //    {
            //        MatchId = 9,
            //        PlayerId = 3,
            //        Round = 4
            //    },
            //    new Score()
            //    {
            //        MatchId = 10,
            //        PlayerId = 3,
            //        Round = 5
            //    },
            //    new Score()
            //    {
            //        MatchId = 10,
            //        PlayerId = 1,
            //        Round = 5
            //    },
            //    new Score()
            //    {
            //        MatchId = 11,
            //        PlayerId = 4,
            //        Round = 5
            //    },
            //    new Score()
            //    {
            //        MatchId = 11,
            //        PlayerId = 2,
            //        Round = 5
            //    },
            //    new Score()
            //    {
            //        MatchId = 12,
            //        PlayerId = 3,
            //        Round = 6
            //    },
            //    new Score()
            //    {
            //        MatchId = 12,
            //        PlayerId = 2,
            //        Round = 6
            //    },
            //    new Score()
            //    {
            //        MatchId = 13,
            //        PlayerId = 4,
            //        Round = 6
            //    },
            //    new Score()
            //    {
            //        MatchId = 13,
            //        PlayerId = 1,
            //        Round = 6
            //    },
            //    new Score()
            //    {
            //        MatchId = 14,
            //        PlayerId = 1,
            //        Round = 0
            //    },
            //    new Score()
            //    {
            //        MatchId = 14,
            //        PlayerId = 2,
            //        Round = 0
            //    },
            //    new Score()
            //    {
            //        MatchId = 15,
            //        PlayerId = 3,
            //        Round = 0
            //    },
            //    new Score()
            //    {
            //        MatchId = 15,
            //        PlayerId = 4,
            //        Round = 0
            //    },

            //};
            //modelBuilder.Entity<Score>().HasData(scores);

            //List<Ranking> rankings = new List<Ranking>()
            //{
            //    new Ranking()
            //    {
            //        PlayerId = 5,
            //        EventId = 1
            //    },
            //    new Ranking()
            //    {
            //        PlayerId = 6,
            //        EventId = 1
            //    },
            //    new Ranking()
            //    {
            //        PlayerId = 1,
            //        EventId = 2
            //    },
            //    new Ranking()
            //    {
            //        PlayerId = 2,
            //        EventId = 2
            //    },
            //    new Ranking()
            //    {
            //        PlayerId = 3,
            //        EventId = 2
            //    },
            //    new Ranking()
            //    {
            //        PlayerId = 4,
            //        EventId = 2
            //    },
            //    new Ranking()
            //    {
            //        PlayerId = 1,
            //        EventId = 3
            //    },
            //    new Ranking()
            //    {
            //        PlayerId = 2,
            //        EventId = 3
            //    },
            //    new Ranking()
            //    {
            //        PlayerId = 3,
            //        EventId = 3
            //    },
            //    new Ranking()
            //    {
            //        PlayerId = 4,
            //        EventId = 3
            //    },
            //};
            //modelBuilder.Entity<Ranking>().HasData(rankings);

            //List<Award> awards = new List<Award>()
            //{
            //    new Award()
            //    {
            //        AwardId = 1,
            //        EventId = 1,
            //        Rank = 1,
            //        Prize = 1000
            //    },
            //    new Award()
            //    {
            //        AwardId = 2,
            //        EventId = 2,
            //        Rank = 1,
            //        Prize = 1000
            //    },
            //    new Award()
            //    {
            //        AwardId = 3,
            //        EventId = 2,
            //        Rank = 2,
            //        Prize = 500
            //    },
            //    new Award()
            //    {
            //        AwardId = 4,
            //        EventId = 3,
            //        Rank = 1,
            //        Prize = 5000
            //    },
            //    new Award()
            //    {
            //        AwardId = 5,
            //        EventId = 3,
            //        Rank = 2,
            //        Prize = 2000
            //    }
            //};

            //modelBuilder.Entity<Award>().HasData(awards);

            static byte[] StrToByteArray(string str)
            {
                Dictionary<string, byte> hexindex = new Dictionary<string, byte>();

                for (int i = 0; i <= 255; i++)
                {
                    hexindex.Add(i.ToString("X2"), (byte)i);
                }

                List<byte> hexres = new List<byte>();

                for (int i = 0; i < str.Length; i += 2)
                {
                    hexres.Add(hexindex[str.Substring(i, 2)]);
                }

                return hexres.ToArray();
            }
        }
    }
}
