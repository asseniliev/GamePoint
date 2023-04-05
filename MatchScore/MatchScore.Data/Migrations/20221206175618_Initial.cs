using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MatchScore.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<int>(type: "int", nullable: false),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "SportsClubs",
                columns: table => new
                {
                    SportsClubId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportsClubs", x => x.SportsClubId);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Photo = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    IsTeam = table.Column<bool>(type: "bit", nullable: false),
                    Country = table.Column<int>(type: "int", nullable: true),
                    SportsClubId = table.Column<int>(type: "int", nullable: true),
                    IsInactive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerId);
                    table.ForeignKey(
                        name: "FK_Players_SportsClubs_SportsClubId",
                        column: x => x.SportsClubId,
                        principalTable: "SportsClubs",
                        principalColumn: "SportsClubId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: true),
                    IsInactive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventType = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsTeamEvent = table.Column<bool>(type: "bit", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    matchType = table.Column<int>(type: "int", nullable: false),
                    MatchLimitValue = table.Column<int>(type: "int", nullable: false),
                    ScoreForWin = table.Column<int>(type: "int", nullable: false),
                    ScoreForDraw = table.Column<int>(type: "int", nullable: false),
                    ChampionId = table.Column<int>(type: "int", nullable: true),
                    DirectorId = table.Column<int>(type: "int", nullable: true),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_Events_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Events_Players_ChampionId",
                        column: x => x.ChampionId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Events_Users_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    RequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestType = table.Column<int>(type: "int", nullable: false),
                    RequestStatus = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    PlayerId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.RequestId);
                    table.ForeignKey(
                        name: "FK_Requests_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Awards",
                columns: table => new
                {
                    AwardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(type: "int", nullable: true),
                    Rank = table.Column<int>(type: "int", nullable: false),
                    Prize = table.Column<decimal>(type: "money", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Awards", x => x.AwardId);
                    table.ForeignKey(
                        name: "FK_Awards_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    MatchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatchScoreLimit = table.Column<int>(type: "int", nullable: true),
                    PlayerTimeLimit = table.Column<int>(type: "int", nullable: true),
                    MatchTimeLimit = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.MatchId);
                    table.ForeignKey(
                        name: "FK_Matches_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rankings",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    Rank = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rankings", x => new { x.PlayerId, x.EventId });
                    table.ForeignKey(
                        name: "FK_Rankings_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rankings_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Scores",
                columns: table => new
                {
                    MatchId = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    Round = table.Column<int>(type: "int", nullable: false),
                    PlayerScore = table.Column<double>(type: "float", nullable: true),
                    ScoredPoints = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scores", x => new { x.MatchId, x.PlayerId });
                    table.ForeignKey(
                        name: "FK_Scores_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Scores_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "City", "Country", "Latitude", "Longitude" },
                values: new object[,]
                {
                    { 1, "Sofia", 35, "42.6977", "23.3219" },
                    { 2, "Chicago", 236, "41.8781", "-87.6298" },
                    { 3, "London", 235, "51.5072", "-0.1276" },
                    { 4, "Lyon", 76, "45.7594", "4.8290" }
                });

            migrationBuilder.InsertData(
                table: "SportsClubs",
                columns: new[] { "SportsClubId", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, false, "Cherno more" },
                    { 2, false, "Chicago Bulls" },
                    { 3, false, "Aston Villa" },
                    { 4, false, "Olympique Lionnais" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CreatedOn", "Email", "IsDeleted", "IsInactive", "PasswordHash", "PasswordSalt", "PlayerId", "Role", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 11, 17, 14, 4, 24, 0, DateTimeKind.Unspecified), "ivan@mail.com", false, false, new byte[] { 108, 192, 45, 62, 73, 159, 192, 211, 58, 70, 124, 245, 54, 203, 100, 32, 67, 137, 219, 133, 97, 141, 69, 97, 251, 97, 247, 227, 180, 6, 142, 54, 254, 206, 93, 240, 90, 222, 77, 64, 105, 102, 241, 206, 169, 120, 206, 252, 91, 7, 229, 228, 247, 108, 226, 193, 118, 243, 4, 107, 147, 27, 30, 131 }, new byte[] { 138, 247, 160, 96, 158, 70, 114, 146, 56, 44, 33, 155, 112, 12, 61, 129, 220, 241, 205, 251, 4, 51, 177, 100, 208, 147, 110, 195, 255, 152, 65, 148, 73, 134, 48, 80, 178, 109, 119, 27, 246, 140, 47, 226, 107, 32, 3, 79, 33, 188, 11, 243, 62, 220, 167, 34, 19, 33, 152, 204, 25, 156, 130, 58, 37, 10, 193, 125, 117, 2, 183, 209, 68, 199, 201, 64, 241, 69, 27, 226, 77, 57, 77, 244, 7, 76, 134, 166, 122, 2, 77, 131, 132, 129, 211, 138, 177, 16, 121, 152, 47, 205, 90, 204, 65, 105, 129, 76, 215, 191, 232, 136, 12, 145, 156, 76, 177, 66, 50, 109, 240, 244, 164, 26, 0, 190, 143, 66 }, null, 0, "ivan" },
                    { 2, new DateTime(2022, 11, 17, 14, 4, 24, 0, DateTimeKind.Unspecified), "asen@mail.com", false, false, new byte[] { 58, 13, 140, 63, 107, 184, 87, 97, 28, 47, 135, 106, 16, 187, 90, 154, 83, 241, 61, 26, 14, 176, 35, 181, 99, 126, 224, 37, 110, 220, 149, 0, 222, 88, 226, 10, 60, 205, 26, 235, 252, 237, 54, 73, 2, 91, 63, 81, 232, 134, 119, 64, 33, 1, 107, 185, 84, 172, 187, 78, 73, 23, 114, 26 }, new byte[] { 130, 177, 149, 43, 123, 85, 231, 73, 219, 244, 76, 240, 42, 126, 140, 131, 39, 169, 129, 156, 226, 124, 164, 55, 62, 6, 116, 171, 106, 92, 76, 217, 115, 177, 89, 156, 78, 111, 131, 46, 131, 126, 121, 187, 70, 21, 3, 13, 46, 241, 14, 99, 1, 189, 159, 35, 125, 247, 1, 215, 122, 168, 235, 218, 233, 170, 222, 199, 101, 234, 202, 68, 105, 191, 140, 237, 147, 228, 54, 17, 216, 192, 109, 42, 233, 215, 76, 5, 253, 133, 161, 23, 227, 3, 188, 10, 0, 89, 122, 20, 121, 146, 158, 110, 132, 183, 13, 127, 6, 149, 27, 55, 84, 73, 101, 159, 51, 239, 236, 155, 214, 206, 2, 33, 8, 248, 60, 210 }, null, 1, "asen" },
                    { 3, new DateTime(2022, 11, 17, 14, 4, 24, 0, DateTimeKind.Unspecified), "toto@mail.com", false, false, new byte[] { 98, 89, 218, 235, 156, 95, 129, 229, 49, 100, 33, 169, 230, 126, 106, 88, 223, 213, 249, 118, 102, 75, 158, 192, 27, 15, 105, 47, 66, 137, 196, 46, 54, 134, 126, 73, 46, 96, 125, 35, 212, 148, 19, 87, 29, 3, 237, 180, 151, 27, 105, 150, 52, 40, 39, 101, 161, 4, 180, 33, 108, 215, 187, 189 }, new byte[] { 14, 21, 249, 59, 177, 92, 172, 134, 2, 156, 133, 37, 78, 232, 199, 155, 43, 91, 157, 157, 169, 59, 15, 89, 215, 72, 195, 244, 72, 133, 104, 244, 64, 87, 90, 59, 62, 90, 255, 231, 1, 137, 239, 44, 197, 0, 17, 17, 47, 48, 1, 138, 4, 179, 39, 159, 173, 234, 244, 9, 58, 198, 31, 106, 33, 193, 46, 145, 101, 64, 178, 211, 197, 129, 176, 176, 211, 194, 16, 218, 215, 143, 123, 204, 216, 111, 234, 3, 103, 50, 44, 43, 22, 162, 124, 214, 230, 255, 175, 234, 168, 146, 31, 86, 57, 163, 15, 12, 228, 198, 251, 61, 191, 213, 247, 106, 156, 249, 143, 214, 226, 153, 22, 164, 139, 54, 47, 248 }, null, 1, "toto" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "ChampionId", "DirectorId", "EndDate", "EventType", "IsCompleted", "IsDeleted", "IsTeamEvent", "LocationId", "MatchLimitValue", "ScoreForDraw", "ScoreForWin", "StartDate", "Title", "matchType" },
                values: new object[,]
                {
                    { 1, null, 1, new DateTime(2023, 1, 13, 19, 56, 18, 611, DateTimeKind.Local).AddTicks(3040), 0, false, false, false, 1, 0, 0, 0, new DateTime(2022, 12, 14, 19, 56, 18, 611, DateTimeKind.Local).AddTicks(2890), "Single Match Event", 0 },
                    { 2, null, 2, new DateTime(2023, 3, 14, 19, 56, 18, 611, DateTimeKind.Local).AddTicks(3550), 2, false, false, true, 2, 0, 1, 2, new DateTime(2022, 12, 14, 19, 56, 18, 611, DateTimeKind.Local).AddTicks(3540), "League", 0 },
                    { 3, null, 2, new DateTime(2023, 3, 14, 19, 56, 18, 611, DateTimeKind.Local).AddTicks(3790), 1, false, false, true, 3, 0, 0, 0, new DateTime(2022, 12, 14, 19, 56, 18, 611, DateTimeKind.Local).AddTicks(3790), "Knockout Event", 0 }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "PlayerId", "Country", "IsDeleted", "IsInactive", "IsTeam", "Name", "Photo", "SportsClubId" },
                values: new object[,]
                {
                    { 1, 35, false, false, true, "Cherno more", null, 1 },
                    { 2, 236, false, false, true, "Chicago Bulls", null, 2 },
                    { 3, 235, false, false, true, "Aston Villa", null, 3 },
                    { 5, 35, false, false, false, "Grigor Dimitrov", null, 3 },
                    { 4, 76, false, false, true, "Olympique Lyonnais", null, 4 },
                    { 6, 236, false, false, false, "Andre Agassi", null, 4 }
                });

            migrationBuilder.InsertData(
                table: "Awards",
                columns: new[] { "AwardId", "EventId", "IsDeleted", "Prize", "Rank" },
                values: new object[,]
                {
                    { 1, 1, false, 1000m, 1 },
                    { 5, 3, false, 2000m, 2 },
                    { 4, 3, false, 5000m, 1 },
                    { 2, 2, false, 1000m, 1 },
                    { 3, 2, false, 500m, 2 }
                });

            migrationBuilder.InsertData(
                table: "Matches",
                columns: new[] { "MatchId", "Date", "Discriminator", "EventId", "IsDeleted", "LocationId", "MatchTimeLimit", "PlayerTimeLimit" },
                values: new object[,]
                {
                    { 14, new DateTime(2022, 12, 18, 19, 56, 18, 611, DateTimeKind.Local).AddTicks(60), "TimeLimitedMatch", 3, false, 4, 90, 0 },
                    { 13, new DateTime(2022, 12, 17, 19, 56, 18, 611, DateTimeKind.Local).AddTicks(60), "TimeLimitedMatch", 2, false, 1, 90, 0 },
                    { 12, new DateTime(2022, 12, 17, 19, 56, 18, 611, DateTimeKind.Local).AddTicks(60), "TimeLimitedMatch", 2, false, 1, 90, 0 },
                    { 11, new DateTime(2022, 12, 17, 19, 56, 18, 611, DateTimeKind.Local).AddTicks(60), "TimeLimitedMatch", 2, false, 1, 90, 0 },
                    { 10, new DateTime(2022, 12, 17, 19, 56, 18, 611, DateTimeKind.Local).AddTicks(50), "TimeLimitedMatch", 2, false, 1, 90, 0 },
                    { 9, new DateTime(2022, 12, 17, 19, 56, 18, 611, DateTimeKind.Local).AddTicks(50), "TimeLimitedMatch", 2, false, 1, 90, 0 },
                    { 8, new DateTime(2022, 12, 17, 19, 56, 18, 611, DateTimeKind.Local).AddTicks(50), "TimeLimitedMatch", 2, false, 1, 90, 0 },
                    { 15, new DateTime(2022, 12, 22, 19, 56, 18, 611, DateTimeKind.Local).AddTicks(70), "TimeLimitedMatch", 3, false, 2, 90, 0 },
                    { 6, new DateTime(2022, 12, 16, 19, 56, 18, 611, DateTimeKind.Local).AddTicks(40), "TimeLimitedMatch", 2, false, 2, 90, 0 },
                    { 7, new DateTime(2022, 12, 17, 19, 56, 18, 611, DateTimeKind.Local).AddTicks(50), "TimeLimitedMatch", 2, false, 1, 90, 0 },
                    { 4, new DateTime(2022, 12, 24, 19, 56, 18, 611, DateTimeKind.Local).AddTicks(40), "TimeLimitedMatch", 2, false, 3, 90, 0 },
                    { 3, new DateTime(2022, 12, 22, 19, 56, 18, 611, DateTimeKind.Local).AddTicks(30), "TimeLimitedMatch", 2, false, 2, 90, 0 },
                    { 2, new DateTime(2022, 12, 17, 19, 56, 18, 610, DateTimeKind.Local).AddTicks(9840), "TimeLimitedMatch", 2, false, 1, 90, 0 }
                });

            migrationBuilder.InsertData(
                table: "Matches",
                columns: new[] { "MatchId", "Date", "Discriminator", "EventId", "IsDeleted", "LocationId", "MatchScoreLimit" },
                values: new object[] { 1, new DateTime(2022, 12, 14, 19, 56, 18, 604, DateTimeKind.Local).AddTicks(5020), "ScoreLimitedMatch", 1, false, 1, 6 });

            migrationBuilder.InsertData(
                table: "Matches",
                columns: new[] { "MatchId", "Date", "Discriminator", "EventId", "IsDeleted", "LocationId", "MatchTimeLimit", "PlayerTimeLimit" },
                values: new object[,]
                {
                    { 5, new DateTime(2022, 12, 26, 19, 56, 18, 611, DateTimeKind.Local).AddTicks(40), "TimeLimitedMatch", 2, false, 4, 90, 0 },
                    { 16, new DateTime(2022, 12, 22, 19, 56, 18, 611, DateTimeKind.Local).AddTicks(70), "TimeLimitedMatch", 3, false, 1, 90, 0 }
                });

            migrationBuilder.InsertData(
                table: "Rankings",
                columns: new[] { "EventId", "PlayerId", "IsDeleted", "Rank" },
                values: new object[,]
                {
                    { 2, 4, false, 0 },
                    { 2, 3, false, 0 },
                    { 2, 2, false, 0 },
                    { 2, 1, false, 0 },
                    { 1, 6, false, 0 },
                    { 3, 1, false, 0 },
                    { 3, 2, false, 0 },
                    { 3, 3, false, 0 },
                    { 3, 4, false, 0 },
                    { 1, 5, false, 0 }
                });

            migrationBuilder.InsertData(
                table: "Scores",
                columns: new[] { "MatchId", "PlayerId", "IsDeleted", "PlayerScore", "Round", "ScoredPoints" },
                values: new object[,]
                {
                    { 1, 5, false, null, 1, 0 },
                    { 14, 2, false, null, 0, 0 },
                    { 14, 1, false, null, 0, 0 },
                    { 13, 1, false, null, 6, 0 },
                    { 13, 4, false, null, 6, 0 },
                    { 12, 2, false, null, 6, 0 },
                    { 12, 3, false, null, 6, 0 },
                    { 11, 2, false, null, 5, 0 },
                    { 11, 4, false, null, 5, 0 },
                    { 10, 1, false, null, 5, 0 },
                    { 10, 3, false, null, 5, 0 },
                    { 9, 3, false, null, 4, 0 },
                    { 9, 4, false, null, 4, 0 },
                    { 8, 1, false, null, 4, 0 },
                    { 8, 2, false, null, 4, 0 },
                    { 7, 3, false, null, 3, 0 },
                    { 7, 2, false, null, 3, 0 },
                    { 6, 4, false, null, 3, 0 },
                    { 6, 1, false, null, 3, 0 },
                    { 5, 4, false, null, 2, 0 },
                    { 5, 3, false, null, 2, 0 },
                    { 4, 2, false, null, 2, 0 },
                    { 4, 1, false, null, 2, 0 },
                    { 3, 4, false, null, 1, 0 },
                    { 3, 2, false, null, 1, 0 },
                    { 2, 3, false, null, 1, 0 },
                    { 2, 1, false, null, 1, 0 },
                    { 1, 6, false, null, 1, 0 },
                    { 15, 3, false, null, 0, 0 },
                    { 15, 4, false, null, 0, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Awards_EventId",
                table: "Awards",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_ChampionId",
                table: "Events",
                column: "ChampionId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_DirectorId",
                table: "Events",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_LocationId",
                table: "Events",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_EventId",
                table: "Matches",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_LocationId",
                table: "Matches",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_SportsClubId",
                table: "Players",
                column: "SportsClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Rankings_EventId",
                table: "Rankings",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_PlayerId",
                table: "Requests",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_UserId",
                table: "Requests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Scores_PlayerId",
                table: "Scores",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PlayerId",
                table: "Users",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Awards");

            migrationBuilder.DropTable(
                name: "Rankings");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Scores");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "SportsClubs");
        }
    }
}
