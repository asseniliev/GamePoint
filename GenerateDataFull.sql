USE [MatchScore]
GO
SET IDENTITY_INSERT [dbo].[Locations] ON 
GO
INSERT [dbo].[Locations] ([LocationId], [City], [Country], [Latitude], [Longitude]) VALUES (1, N'Sofia', 35, N'42.6977', N'23.3219')
GO
INSERT [dbo].[Locations] ([LocationId], [City], [Country], [Latitude], [Longitude]) VALUES (2, N'Chicago', 236, N'41.8781', N'-87.6298')
GO
INSERT [dbo].[Locations] ([LocationId], [City], [Country], [Latitude], [Longitude]) VALUES (3, N'London', 235, N'51.5072', N'-0.1276')
GO
INSERT [dbo].[Locations] ([LocationId], [City], [Country], [Latitude], [Longitude]) VALUES (4, N'Lyon', 76, N'45.7594', N'4.8290')
GO
SET IDENTITY_INSERT [dbo].[Locations] OFF
GO
SET IDENTITY_INSERT [dbo].[SportsClubs] ON 
GO
INSERT [dbo].[SportsClubs] ([SportsClubId], [Name], [IsDeleted]) VALUES (1, N'Badasses', 0)
GO
INSERT [dbo].[SportsClubs] ([SportsClubId], [Name], [IsDeleted]) VALUES (2, N'Flying Monkeys', 0)
GO
INSERT [dbo].[SportsClubs] ([SportsClubId], [Name], [IsDeleted]) VALUES (3, N'MVPs', 0)
GO
INSERT [dbo].[SportsClubs] ([SportsClubId], [Name], [IsDeleted]) VALUES (4, N'Full Effect', 0)
GO
INSERT [dbo].[SportsClubs] ([SportsClubId], [Name], [IsDeleted]) VALUES (5, N'Chosen Ones', 0)
GO
INSERT [dbo].[SportsClubs] ([SportsClubId], [Name], [IsDeleted]) VALUES (6, N'Beasts', 0)
GO
INSERT [dbo].[SportsClubs] ([SportsClubId], [Name], [IsDeleted]) VALUES (7, N'A Team', 0)
GO
INSERT [dbo].[SportsClubs] ([SportsClubId], [Name], [IsDeleted]) VALUES (8, N'Coffee Addicts', 0)
GO
INSERT [dbo].[SportsClubs] ([SportsClubId], [Name], [IsDeleted]) VALUES (9, N'Rampage', 0)
GO
INSERT [dbo].[SportsClubs] ([SportsClubId], [Name], [IsDeleted]) VALUES (10, N'Ninjas', 0)
GO
SET IDENTITY_INSERT [dbo].[SportsClubs] OFF
GO
SET IDENTITY_INSERT [dbo].[Players] ON 
GO
INSERT [dbo].[Players] ([PlayerId], [Name], [Photo], [IsTeam], [Country], [SportsClubId], [IsInactive], [IsDeleted]) VALUES (1, N'Badasses', NULL, 1, 66, 1, 0, 0)
GO
INSERT [dbo].[Players] ([PlayerId], [Name], [Photo], [IsTeam], [Country], [SportsClubId], [IsInactive], [IsDeleted]) VALUES (2, N'Flying Monkeys', NULL, 1, 114, 2, 0, 0)
GO
INSERT [dbo].[Players] ([PlayerId], [Name], [Photo], [IsTeam], [Country], [SportsClubId], [IsInactive], [IsDeleted]) VALUES (3, N'MVPs', NULL, 1, 173, 3, 0, 0)
GO
INSERT [dbo].[Players] ([PlayerId], [Name], [Photo], [IsTeam], [Country], [SportsClubId], [IsInactive], [IsDeleted]) VALUES (4, N'Full Effect', NULL, 1, 202, 4, 0, 0)
GO
INSERT [dbo].[Players] ([PlayerId], [Name], [Photo], [IsTeam], [Country], [SportsClubId], [IsInactive], [IsDeleted]) VALUES (5, N'Chosen Ones', NULL, 1, 35, 5, 0, 0)
GO
INSERT [dbo].[Players] ([PlayerId], [Name], [Photo], [IsTeam], [Country], [SportsClubId], [IsInactive], [IsDeleted]) VALUES (6, N'Beasts', NULL, 1, 188, 6, 0, 0)
GO
INSERT [dbo].[Players] ([PlayerId], [Name], [Photo], [IsTeam], [Country], [SportsClubId], [IsInactive], [IsDeleted]) VALUES (7, N'A Team', NULL, 1, 33, 7, 0, 0)
GO
INSERT [dbo].[Players] ([PlayerId], [Name], [Photo], [IsTeam], [Country], [SportsClubId], [IsInactive], [IsDeleted]) VALUES (8, N'Coffee Addicts', NULL, 1, 225, 8, 0, 0)
GO
INSERT [dbo].[Players] ([PlayerId], [Name], [Photo], [IsTeam], [Country], [SportsClubId], [IsInactive], [IsDeleted]) VALUES (9, N'Rampage', NULL, 1, 59, 9, 0, 0)
GO
INSERT [dbo].[Players] ([PlayerId], [Name], [Photo], [IsTeam], [Country], [SportsClubId], [IsInactive], [IsDeleted]) VALUES (10, N'Ninjas', NULL, 1, 158, 10, 0, 0)
GO
INSERT [dbo].[Players] ([PlayerId], [Name], [Photo], [IsTeam], [Country], [SportsClubId], [IsInactive], [IsDeleted]) VALUES (11, N'Cassandra Donovan', NULL, 0, 59, 9, 0, 0)
GO
INSERT [dbo].[Players] ([PlayerId], [Name], [Photo], [IsTeam], [Country], [SportsClubId], [IsInactive], [IsDeleted]) VALUES (12, N'Robert Pearson', NULL, 0, 202, 4, 0, 0)
GO
INSERT [dbo].[Players] ([PlayerId], [Name], [Photo], [IsTeam], [Country], [SportsClubId], [IsInactive], [IsDeleted]) VALUES (13, N'Herman Johnson', NULL, 0, 188, 6, 0, 0)
GO
INSERT [dbo].[Players] ([PlayerId], [Name], [Photo], [IsTeam], [Country], [SportsClubId], [IsInactive], [IsDeleted]) VALUES (14, N'Baker Ortega', NULL, 0, 8, 9, 0, 0)
GO
INSERT [dbo].[Players] ([PlayerId], [Name], [Photo], [IsTeam], [Country], [SportsClubId], [IsInactive], [IsDeleted]) VALUES (15, N'Anjolie Burks', NULL, 0, 200, 6, 0, 0)
GO
INSERT [dbo].[Players] ([PlayerId], [Name], [Photo], [IsTeam], [Country], [SportsClubId], [IsInactive], [IsDeleted]) VALUES (16, N'Priscilla Kelley', NULL, 0, 173, 3, 0, 0)
GO
INSERT [dbo].[Players] ([PlayerId], [Name], [Photo], [IsTeam], [Country], [SportsClubId], [IsInactive], [IsDeleted]) VALUES (17, N'Clinton Day', NULL, 0, 66, 1, 0, 0)
GO
INSERT [dbo].[Players] ([PlayerId], [Name], [Photo], [IsTeam], [Country], [SportsClubId], [IsInactive], [IsDeleted]) VALUES (18, N'Harding Scott', NULL, 0, 163, 9, 0, 0)
GO
INSERT [dbo].[Players] ([PlayerId], [Name], [Photo], [IsTeam], [Country], [SportsClubId], [IsInactive], [IsDeleted]) VALUES (19, N'Bruce Lawson', NULL, 0, 35, 5, 0, 0)
GO
INSERT [dbo].[Players] ([PlayerId], [Name], [Photo], [IsTeam], [Country], [SportsClubId], [IsInactive], [IsDeleted]) VALUES (20, N'Tanya Boyle', NULL, 0, 115, 1, 0, 0)
GO
INSERT [dbo].[Players] ([PlayerId], [Name], [Photo], [IsTeam], [Country], [SportsClubId], [IsInactive], [IsDeleted]) VALUES (21, N'Urielle Kaufman', NULL, 0, 203, 9, 0, 0)
GO
INSERT [dbo].[Players] ([PlayerId], [Name], [Photo], [IsTeam], [Country], [SportsClubId], [IsInactive], [IsDeleted]) VALUES (22, N'Gavin Hammond', NULL, 0, 91, 4, 0, 0)
GO
INSERT [dbo].[Players] ([PlayerId], [Name], [Photo], [IsTeam], [Country], [SportsClubId], [IsInactive], [IsDeleted]) VALUES (23, N'Paul David', NULL, 0, 192, 5, 0, 0)
GO
INSERT [dbo].[Players] ([PlayerId], [Name], [Photo], [IsTeam], [Country], [SportsClubId], [IsInactive], [IsDeleted]) VALUES (24, N'Gretchen Hobbs', NULL, 0, 7, 6, 0, 0)
GO
INSERT [dbo].[Players] ([PlayerId], [Name], [Photo], [IsTeam], [Country], [SportsClubId], [IsInactive], [IsDeleted]) VALUES (25, N'Winifred Duffy', NULL, 0, 61, 5, 0, 0)
GO
INSERT [dbo].[Players] ([PlayerId], [Name], [Photo], [IsTeam], [Country], [SportsClubId], [IsInactive], [IsDeleted]) VALUES (26, N'Hedy Shaw', NULL, 0, 102, 1, 0, 0)
GO
INSERT [dbo].[Players] ([PlayerId], [Name], [Photo], [IsTeam], [Country], [SportsClubId], [IsInactive], [IsDeleted]) VALUES (27, N'Aladdin Waller', NULL, 0, 72, 9, 0, 0)
GO
INSERT [dbo].[Players] ([PlayerId], [Name], [Photo], [IsTeam], [Country], [SportsClubId], [IsInactive], [IsDeleted]) VALUES (28, N'Teagan Dodson', NULL, 0, 243, 1, 0, 0)
GO
INSERT [dbo].[Players] ([PlayerId], [Name], [Photo], [IsTeam], [Country], [SportsClubId], [IsInactive], [IsDeleted]) VALUES (29, N'Glenna Cohen', NULL, 0, 158, 10, 0, 0)
GO
INSERT [dbo].[Players] ([PlayerId], [Name], [Photo], [IsTeam], [Country], [SportsClubId], [IsInactive], [IsDeleted]) VALUES (30, N'Halee Phelps', NULL, 0, 114, 2, 0, 0)
GO
INSERT [dbo].[Players] ([PlayerId], [Name], [Photo], [IsTeam], [Country], [SportsClubId], [IsInactive], [IsDeleted]) VALUES (31, N'Driscoll Snider', NULL, 0, 79, 9, 0, 0)
GO
INSERT [dbo].[Players] ([PlayerId], [Name], [Photo], [IsTeam], [Country], [SportsClubId], [IsInactive], [IsDeleted]) VALUES (32, N'Kirestin Griffith', NULL, 0, 33, 7, 0, 0)
GO
INSERT [dbo].[Players] ([PlayerId], [Name], [Photo], [IsTeam], [Country], [SportsClubId], [IsInactive], [IsDeleted]) VALUES (33, N'Aline Willis', NULL, 0, 117, 10, 0, 0)
GO
INSERT [dbo].[Players] ([PlayerId], [Name], [Photo], [IsTeam], [Country], [SportsClubId], [IsInactive], [IsDeleted]) VALUES (34, N'Dominique Ashley', NULL, 0, 74, 7, 0, 0)
GO
INSERT [dbo].[Players] ([PlayerId], [Name], [Photo], [IsTeam], [Country], [SportsClubId], [IsInactive], [IsDeleted]) VALUES (35, N'Driscoll Lawrence', NULL, 0, 5, 7, 0, 0)
GO
INSERT [dbo].[Players] ([PlayerId], [Name], [Photo], [IsTeam], [Country], [SportsClubId], [IsInactive], [IsDeleted]) VALUES (36, N'Blake White', NULL, 0, 97, 8, 0, 0)
GO
INSERT [dbo].[Players] ([PlayerId], [Name], [Photo], [IsTeam], [Country], [SportsClubId], [IsInactive], [IsDeleted]) VALUES (37, N'Gannon Deleon', NULL, 0, 50, 8, 0, 0)
GO
INSERT [dbo].[Players] ([PlayerId], [Name], [Photo], [IsTeam], [Country], [SportsClubId], [IsInactive], [IsDeleted]) VALUES (38, N'Zachery Gross', NULL, 0, 139, 1, 0, 0)
GO
INSERT [dbo].[Players] ([PlayerId], [Name], [Photo], [IsTeam], [Country], [SportsClubId], [IsInactive], [IsDeleted]) VALUES (39, N'Cassandra Lawson', NULL, 0, 110, 5, 0, 0)
GO
INSERT [dbo].[Players] ([PlayerId], [Name], [Photo], [IsTeam], [Country], [SportsClubId], [IsInactive], [IsDeleted]) VALUES (40, N'Jerome Glass', NULL, 0, 238, 5, 0, 0)
GO
INSERT [dbo].[Players] ([PlayerId], [Name], [Photo], [IsTeam], [Country], [SportsClubId], [IsInactive], [IsDeleted]) VALUES (41, N'Callum Spears', NULL, 0, 120, 3, 0, 0)
GO
INSERT [dbo].[Players] ([PlayerId], [Name], [Photo], [IsTeam], [Country], [SportsClubId], [IsInactive], [IsDeleted]) VALUES (42, N'Madaline Fernandez', NULL, 0, 212, 10, 0, 0)
GO
INSERT [dbo].[Players] ([PlayerId], [Name], [Photo], [IsTeam], [Country], [SportsClubId], [IsInactive], [IsDeleted]) VALUES (43, N'Gillian Vinson', NULL, 0, 145, 6, 0, 0)
GO
INSERT [dbo].[Players] ([PlayerId], [Name], [Photo], [IsTeam], [Country], [SportsClubId], [IsInactive], [IsDeleted]) VALUES (44, N'Paul Schneider', NULL, 0, 238, 2, 0, 0)
GO
INSERT [dbo].[Players] ([PlayerId], [Name], [Photo], [IsTeam], [Country], [SportsClubId], [IsInactive], [IsDeleted]) VALUES (45, N'Jamalia Travis', NULL, 0, 107, 2, 0, 0)
GO
INSERT [dbo].[Players] ([PlayerId], [Name], [Photo], [IsTeam], [Country], [SportsClubId], [IsInactive], [IsDeleted]) VALUES (46, N'Jerry Vasquez', NULL, 0, 147, 1, 0, 0)
GO
INSERT [dbo].[Players] ([PlayerId], [Name], [Photo], [IsTeam], [Country], [SportsClubId], [IsInactive], [IsDeleted]) VALUES (47, N'Haley Porter', NULL, 0, 49, 4, 0, 0)
GO
INSERT [dbo].[Players] ([PlayerId], [Name], [Photo], [IsTeam], [Country], [SportsClubId], [IsInactive], [IsDeleted]) VALUES (48, N'Jacob Harding', NULL, 0, 239, 1, 0, 0)
GO
INSERT [dbo].[Players] ([PlayerId], [Name], [Photo], [IsTeam], [Country], [SportsClubId], [IsInactive], [IsDeleted]) VALUES (49, N'Hakeem Finley', NULL, 0, 73, 10, 0, 0)
GO
INSERT [dbo].[Players] ([PlayerId], [Name], [Photo], [IsTeam], [Country], [SportsClubId], [IsInactive], [IsDeleted]) VALUES (50, N'Arsenio Wolfe', NULL, 0, 133, 6, 0, 0)
GO
SET IDENTITY_INSERT [dbo].[Players] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([UserId], [Username], [PasswordSalt], [PasswordHash], [Email], [Role], [CreatedOn], [PlayerId], [IsInactive], [IsDeleted]) VALUES (1, N'Admin', 0x2304DC1B898874D4130882D0E9E4A4ACC0B1F03369B21D702D37228C4BD5C4895E16E2F9C2A6FABB8E077DF2F896505317FBA384920A783B398444C0729BAFDAF0CC85E0BBAC5763FC1CEE5DDF747E24E5A29C84E37E3F54B64477DE2174101DA40F984FD8F97FF82CDC730324A8FBB7120F209828ED495D69D617B177BE3199, 0xCBDAD874F15E69E4BC8ADE8C3AC4B286502C74A24594499637D664D5A32ED113B11C041C53040B1A5DCB4FC75A5B7C1EB28A5E08A73551CEA525A4A0374426A4, N'gamepoint@abv.bg', 0, CAST(N'2022-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, 0)
GO
INSERT [dbo].[Users] ([UserId], [Username], [PasswordSalt], [PasswordHash], [Email], [Role], [CreatedOn], [PlayerId], [IsInactive], [IsDeleted]) VALUES (2, N'Antoaneta', 0xF4FFC3528F7233C05620014759A00C8B9069744EFDE638E13EF389F1788947D2D9EA7C43B4BB6691A59617D2A4544A13B6D49D8D912469D4D22FD1912BB699077BC6848C2D6895B183CC5B9C78E552843177EAD410A390DFC2C0B1BC6C35CBD9FD7E1F8E062D88F3B5FB3A9D6F6F34693EA4006DF8ACFC958A1E630CDE30520B, 0x474D8FC7BBABDC6FB99EB3E01132BA97A6443B1724EFBFB94A0A7890EC6D9A3A9D3CABFFFDB9743B80F81F037762FE5118464C322E188137E1DB5CC0B5C40F91, N'antoaneta.stefanova.a41@learn.telerikacademy.com', 1, CAST(N'2022-12-01T02:00:00.0000000' AS DateTime2), NULL, 0, 0)
GO
INSERT [dbo].[Users] ([UserId], [Username], [PasswordSalt], [PasswordHash], [Email], [Role], [CreatedOn], [PlayerId], [IsInactive], [IsDeleted]) VALUES (3, N'Assen', 0xF4FFC3528F7233C05620014759A00C8B9069744EFDE638E13EF389F1788947D2D9EA7C43B4BB6691A59617D2A4544A13B6D49D8D912469D4D22FD1912BB699077BC6848C2D6895B183CC5B9C78E552843177EAD410A390DFC2C0B1BC6C35CBD9FD7E1F8E062D88F3B5FB3A9D6F6F34693EA4006DF8ACFC958A1E630CDE30520B, 0x474D8FC7BBABDC6FB99EB3E01132BA97A6443B1724EFBFB94A0A7890EC6D9A3A9D3CABFFFDB9743B80F81F037762FE5118464C322E188137E1DB5CC0B5C40F91, N'asen.iliev.a41@learn.telerikacademy.com', 1, CAST(N'2022-12-01T03:00:00.0000000' AS DateTime2), NULL, 0, 0)
GO
INSERT [dbo].[Users] ([UserId], [Username], [PasswordSalt], [PasswordHash], [Email], [Role], [CreatedOn], [PlayerId], [IsInactive], [IsDeleted]) VALUES (4, N'Haley', 0xF4FFC3528F7233C05620014759A00C8B9069744EFDE638E13EF389F1788947D2D9EA7C43B4BB6691A59617D2A4544A13B6D49D8D912469D4D22FD1912BB699077BC6848C2D6895B183CC5B9C78E552843177EAD410A390DFC2C0B1BC6C35CBD9FD7E1F8E062D88F3B5FB3A9D6F6F34693EA4006DF8ACFC958A1E630CDE30520B, 0x474D8FC7BBABDC6FB99EB3E01132BA97A6443B1724EFBFB94A0A7890EC6D9A3A9D3CABFFFDB9743B80F81F037762FE5118464C322E188137E1DB5CC0B5C40F91, N'haley@mail.com', 2, CAST(N'2022-12-01T04:00:00.0000000' AS DateTime2), NULL, 0, 0)
GO
INSERT [dbo].[Users] ([UserId], [Username], [PasswordSalt], [PasswordHash], [Email], [Role], [CreatedOn], [PlayerId], [IsInactive], [IsDeleted]) VALUES (5, N'Adelbert', 0xF4FFC3528F7233C05620014759A00C8B9069744EFDE638E13EF389F1788947D2D9EA7C43B4BB6691A59617D2A4544A13B6D49D8D912469D4D22FD1912BB699077BC6848C2D6895B183CC5B9C78E552843177EAD410A390DFC2C0B1BC6C35CBD9FD7E1F8E062D88F3B5FB3A9D6F6F34693EA4006DF8ACFC958A1E630CDE30520B, 0x474D8FC7BBABDC6FB99EB3E01132BA97A6443B1724EFBFB94A0A7890EC6D9A3A9D3CABFFFDB9743B80F81F037762FE5118464C322E188137E1DB5CC0B5C40F91, N'adelbert@mail.com', 2, CAST(N'2022-12-01T05:00:00.0000000' AS DateTime2), NULL, 0, 0)
GO
INSERT [dbo].[Users] ([UserId], [Username], [PasswordSalt], [PasswordHash], [Email], [Role], [CreatedOn], [PlayerId], [IsInactive], [IsDeleted]) VALUES (6, N'Winslow', 0xF4FFC3528F7233C05620014759A00C8B9069744EFDE638E13EF389F1788947D2D9EA7C43B4BB6691A59617D2A4544A13B6D49D8D912469D4D22FD1912BB699077BC6848C2D6895B183CC5B9C78E552843177EAD410A390DFC2C0B1BC6C35CBD9FD7E1F8E062D88F3B5FB3A9D6F6F34693EA4006DF8ACFC958A1E630CDE30520B, 0x474D8FC7BBABDC6FB99EB3E01132BA97A6443B1724EFBFB94A0A7890EC6D9A3A9D3CABFFFDB9743B80F81F037762FE5118464C322E188137E1DB5CC0B5C40F91, N'winslow@mail.com', 2, CAST(N'2022-12-01T06:00:00.0000000' AS DateTime2), NULL, 0, 0)
GO
INSERT [dbo].[Users] ([UserId], [Username], [PasswordSalt], [PasswordHash], [Email], [Role], [CreatedOn], [PlayerId], [IsInactive], [IsDeleted]) VALUES (7, N'Carlos', 0xF4FFC3528F7233C05620014759A00C8B9069744EFDE638E13EF389F1788947D2D9EA7C43B4BB6691A59617D2A4544A13B6D49D8D912469D4D22FD1912BB699077BC6848C2D6895B183CC5B9C78E552843177EAD410A390DFC2C0B1BC6C35CBD9FD7E1F8E062D88F3B5FB3A9D6F6F34693EA4006DF8ACFC958A1E630CDE30520B, 0x474D8FC7BBABDC6FB99EB3E01132BA97A6443B1724EFBFB94A0A7890EC6D9A3A9D3CABFFFDB9743B80F81F037762FE5118464C322E188137E1DB5CC0B5C40F91, N'carlos@mail.com', 2, CAST(N'2022-12-01T07:00:00.0000000' AS DateTime2), NULL, 0, 0)
GO
INSERT [dbo].[Users] ([UserId], [Username], [PasswordSalt], [PasswordHash], [Email], [Role], [CreatedOn], [PlayerId], [IsInactive], [IsDeleted]) VALUES (8, N'Aaren', 0xF4FFC3528F7233C05620014759A00C8B9069744EFDE638E13EF389F1788947D2D9EA7C43B4BB6691A59617D2A4544A13B6D49D8D912469D4D22FD1912BB699077BC6848C2D6895B183CC5B9C78E552843177EAD410A390DFC2C0B1BC6C35CBD9FD7E1F8E062D88F3B5FB3A9D6F6F34693EA4006DF8ACFC958A1E630CDE30520B, 0x474D8FC7BBABDC6FB99EB3E01132BA97A6443B1724EFBFB94A0A7890EC6D9A3A9D3CABFFFDB9743B80F81F037762FE5118464C322E188137E1DB5CC0B5C40F91, N'aaren@mail.com', 2, CAST(N'2022-12-01T08:00:00.0000000' AS DateTime2), NULL, 0, 0)
GO
INSERT [dbo].[Users] ([UserId], [Username], [PasswordSalt], [PasswordHash], [Email], [Role], [CreatedOn], [PlayerId], [IsInactive], [IsDeleted]) VALUES (9, N'Garry', 0xF4FFC3528F7233C05620014759A00C8B9069744EFDE638E13EF389F1788947D2D9EA7C43B4BB6691A59617D2A4544A13B6D49D8D912469D4D22FD1912BB699077BC6848C2D6895B183CC5B9C78E552843177EAD410A390DFC2C0B1BC6C35CBD9FD7E1F8E062D88F3B5FB3A9D6F6F34693EA4006DF8ACFC958A1E630CDE30520B, 0x474D8FC7BBABDC6FB99EB3E01132BA97A6443B1724EFBFB94A0A7890EC6D9A3A9D3CABFFFDB9743B80F81F037762FE5118464C322E188137E1DB5CC0B5C40F91, N'garry@mail.com', 2, CAST(N'2022-12-01T09:00:00.0000000' AS DateTime2), NULL, 0, 0)
GO
INSERT [dbo].[Users] ([UserId], [Username], [PasswordSalt], [PasswordHash], [Email], [Role], [CreatedOn], [PlayerId], [IsInactive], [IsDeleted]) VALUES (10, N'Morna', 0xF4FFC3528F7233C05620014759A00C8B9069744EFDE638E13EF389F1788947D2D9EA7C43B4BB6691A59617D2A4544A13B6D49D8D912469D4D22FD1912BB699077BC6848C2D6895B183CC5B9C78E552843177EAD410A390DFC2C0B1BC6C35CBD9FD7E1F8E062D88F3B5FB3A9D6F6F34693EA4006DF8ACFC958A1E630CDE30520B, 0x474D8FC7BBABDC6FB99EB3E01132BA97A6443B1724EFBFB94A0A7890EC6D9A3A9D3CABFFFDB9743B80F81F037762FE5118464C322E188137E1DB5CC0B5C40F91, N'morna@mail.com', 2, CAST(N'2022-12-01T10:00:00.0000000' AS DateTime2), NULL, 0, 0)
GO
INSERT [dbo].[Users] ([UserId], [Username], [PasswordSalt], [PasswordHash], [Email], [Role], [CreatedOn], [PlayerId], [IsInactive], [IsDeleted]) VALUES (11, N'Sylvester', 0xF4FFC3528F7233C05620014759A00C8B9069744EFDE638E13EF389F1788947D2D9EA7C43B4BB6691A59617D2A4544A13B6D49D8D912469D4D22FD1912BB699077BC6848C2D6895B183CC5B9C78E552843177EAD410A390DFC2C0B1BC6C35CBD9FD7E1F8E062D88F3B5FB3A9D6F6F34693EA4006DF8ACFC958A1E630CDE30520B, 0x474D8FC7BBABDC6FB99EB3E01132BA97A6443B1724EFBFB94A0A7890EC6D9A3A9D3CABFFFDB9743B80F81F037762FE5118464C322E188137E1DB5CC0B5C40F91, N'sylvester@mail.com', 2, CAST(N'2022-12-01T11:00:00.0000000' AS DateTime2), NULL, 0, 0)
GO
INSERT [dbo].[Users] ([UserId], [Username], [PasswordSalt], [PasswordHash], [Email], [Role], [CreatedOn], [PlayerId], [IsInactive], [IsDeleted]) VALUES (12, N'Talia', 0xF4FFC3528F7233C05620014759A00C8B9069744EFDE638E13EF389F1788947D2D9EA7C43B4BB6691A59617D2A4544A13B6D49D8D912469D4D22FD1912BB699077BC6848C2D6895B183CC5B9C78E552843177EAD410A390DFC2C0B1BC6C35CBD9FD7E1F8E062D88F3B5FB3A9D6F6F34693EA4006DF8ACFC958A1E630CDE30520B, 0x474D8FC7BBABDC6FB99EB3E01132BA97A6443B1724EFBFB94A0A7890EC6D9A3A9D3CABFFFDB9743B80F81F037762FE5118464C322E188137E1DB5CC0B5C40F91, N'talia@mail.com', 2, CAST(N'2022-12-01T12:00:00.0000000' AS DateTime2), NULL, 0, 0)
GO
INSERT [dbo].[Users] ([UserId], [Username], [PasswordSalt], [PasswordHash], [Email], [Role], [CreatedOn], [PlayerId], [IsInactive], [IsDeleted]) VALUES (13, N'Putnam', 0xF4FFC3528F7233C05620014759A00C8B9069744EFDE638E13EF389F1788947D2D9EA7C43B4BB6691A59617D2A4544A13B6D49D8D912469D4D22FD1912BB699077BC6848C2D6895B183CC5B9C78E552843177EAD410A390DFC2C0B1BC6C35CBD9FD7E1F8E062D88F3B5FB3A9D6F6F34693EA4006DF8ACFC958A1E630CDE30520B, 0x474D8FC7BBABDC6FB99EB3E01132BA97A6443B1724EFBFB94A0A7890EC6D9A3A9D3CABFFFDB9743B80F81F037762FE5118464C322E188137E1DB5CC0B5C40F91, N'putnam@mail.com', 2, CAST(N'2022-12-01T13:00:00.0000000' AS DateTime2), NULL, 0, 0)
GO
INSERT [dbo].[Users] ([UserId], [Username], [PasswordSalt], [PasswordHash], [Email], [Role], [CreatedOn], [PlayerId], [IsInactive], [IsDeleted]) VALUES (14, N'Benn', 0xF4FFC3528F7233C05620014759A00C8B9069744EFDE638E13EF389F1788947D2D9EA7C43B4BB6691A59617D2A4544A13B6D49D8D912469D4D22FD1912BB699077BC6848C2D6895B183CC5B9C78E552843177EAD410A390DFC2C0B1BC6C35CBD9FD7E1F8E062D88F3B5FB3A9D6F6F34693EA4006DF8ACFC958A1E630CDE30520B, 0x474D8FC7BBABDC6FB99EB3E01132BA97A6443B1724EFBFB94A0A7890EC6D9A3A9D3CABFFFDB9743B80F81F037762FE5118464C322E188137E1DB5CC0B5C40F91, N'benn@mail.com', 2, CAST(N'2022-12-01T14:00:00.0000000' AS DateTime2), NULL, 0, 0)
GO
INSERT [dbo].[Users] ([UserId], [Username], [PasswordSalt], [PasswordHash], [Email], [Role], [CreatedOn], [PlayerId], [IsInactive], [IsDeleted]) VALUES (15, N'Glyn', 0xF4FFC3528F7233C05620014759A00C8B9069744EFDE638E13EF389F1788947D2D9EA7C43B4BB6691A59617D2A4544A13B6D49D8D912469D4D22FD1912BB699077BC6848C2D6895B183CC5B9C78E552843177EAD410A390DFC2C0B1BC6C35CBD9FD7E1F8E062D88F3B5FB3A9D6F6F34693EA4006DF8ACFC958A1E630CDE30520B, 0x474D8FC7BBABDC6FB99EB3E01132BA97A6443B1724EFBFB94A0A7890EC6D9A3A9D3CABFFFDB9743B80F81F037762FE5118464C322E188137E1DB5CC0B5C40F91, N'glyn@mail.com', 2, CAST(N'2022-12-01T15:00:00.0000000' AS DateTime2), NULL, 0, 0)
GO
INSERT [dbo].[Users] ([UserId], [Username], [PasswordSalt], [PasswordHash], [Email], [Role], [CreatedOn], [PlayerId], [IsInactive], [IsDeleted]) VALUES (16, N'Bruce', 0xF4FFC3528F7233C05620014759A00C8B9069744EFDE638E13EF389F1788947D2D9EA7C43B4BB6691A59617D2A4544A13B6D49D8D912469D4D22FD1912BB699077BC6848C2D6895B183CC5B9C78E552843177EAD410A390DFC2C0B1BC6C35CBD9FD7E1F8E062D88F3B5FB3A9D6F6F34693EA4006DF8ACFC958A1E630CDE30520B, 0x474D8FC7BBABDC6FB99EB3E01132BA97A6443B1724EFBFB94A0A7890EC6D9A3A9D3CABFFFDB9743B80F81F037762FE5118464C322E188137E1DB5CC0B5C40F91, N'bruce@mail.com', 2, CAST(N'2022-12-01T16:00:00.0000000' AS DateTime2), NULL, 0, 0)
GO
INSERT [dbo].[Users] ([UserId], [Username], [PasswordSalt], [PasswordHash], [Email], [Role], [CreatedOn], [PlayerId], [IsInactive], [IsDeleted]) VALUES (17, N'George', 0xF4FFC3528F7233C05620014759A00C8B9069744EFDE638E13EF389F1788947D2D9EA7C43B4BB6691A59617D2A4544A13B6D49D8D912469D4D22FD1912BB699077BC6848C2D6895B183CC5B9C78E552843177EAD410A390DFC2C0B1BC6C35CBD9FD7E1F8E062D88F3B5FB3A9D6F6F34693EA4006DF8ACFC958A1E630CDE30520B, 0x474D8FC7BBABDC6FB99EB3E01132BA97A6443B1724EFBFB94A0A7890EC6D9A3A9D3CABFFFDB9743B80F81F037762FE5118464C322E188137E1DB5CC0B5C40F91, N'george@mail.com', 2, CAST(N'2022-12-01T17:00:00.0000000' AS DateTime2), NULL, 0, 0)
GO
INSERT [dbo].[Users] ([UserId], [Username], [PasswordSalt], [PasswordHash], [Email], [Role], [CreatedOn], [PlayerId], [IsInactive], [IsDeleted]) VALUES (18, N'Karel', 0xF4FFC3528F7233C05620014759A00C8B9069744EFDE638E13EF389F1788947D2D9EA7C43B4BB6691A59617D2A4544A13B6D49D8D912469D4D22FD1912BB699077BC6848C2D6895B183CC5B9C78E552843177EAD410A390DFC2C0B1BC6C35CBD9FD7E1F8E062D88F3B5FB3A9D6F6F34693EA4006DF8ACFC958A1E630CDE30520B, 0x474D8FC7BBABDC6FB99EB3E01132BA97A6443B1724EFBFB94A0A7890EC6D9A3A9D3CABFFFDB9743B80F81F037762FE5118464C322E188137E1DB5CC0B5C40F91, N'karel@mail.com', 2, CAST(N'2022-12-01T18:00:00.0000000' AS DateTime2), NULL, 0, 0)
GO
INSERT [dbo].[Users] ([UserId], [Username], [PasswordSalt], [PasswordHash], [Email], [Role], [CreatedOn], [PlayerId], [IsInactive], [IsDeleted]) VALUES (19, N'Michel', 0xF4FFC3528F7233C05620014759A00C8B9069744EFDE638E13EF389F1788947D2D9EA7C43B4BB6691A59617D2A4544A13B6D49D8D912469D4D22FD1912BB699077BC6848C2D6895B183CC5B9C78E552843177EAD410A390DFC2C0B1BC6C35CBD9FD7E1F8E062D88F3B5FB3A9D6F6F34693EA4006DF8ACFC958A1E630CDE30520B, 0x474D8FC7BBABDC6FB99EB3E01132BA97A6443B1724EFBFB94A0A7890EC6D9A3A9D3CABFFFDB9743B80F81F037762FE5118464C322E188137E1DB5CC0B5C40F91, N'michel@mail.com', 2, CAST(N'2022-12-01T19:00:00.0000000' AS DateTime2), NULL, 0, 0)
GO
INSERT [dbo].[Users] ([UserId], [Username], [PasswordSalt], [PasswordHash], [Email], [Role], [CreatedOn], [PlayerId], [IsInactive], [IsDeleted]) VALUES (20, N'Coral', 0xF4FFC3528F7233C05620014759A00C8B9069744EFDE638E13EF389F1788947D2D9EA7C43B4BB6691A59617D2A4544A13B6D49D8D912469D4D22FD1912BB699077BC6848C2D6895B183CC5B9C78E552843177EAD410A390DFC2C0B1BC6C35CBD9FD7E1F8E062D88F3B5FB3A9D6F6F34693EA4006DF8ACFC958A1E630CDE30520B, 0x474D8FC7BBABDC6FB99EB3E01132BA97A6443B1724EFBFB94A0A7890EC6D9A3A9D3CABFFFDB9743B80F81F037762FE5118464C322E188137E1DB5CC0B5C40F91, N'coral@mail.com', 2, CAST(N'2022-12-01T20:00:00.0000000' AS DateTime2), NULL, 0, 0)
GO
INSERT [dbo].[Users] ([UserId], [Username], [PasswordSalt], [PasswordHash], [Email], [Role], [CreatedOn], [PlayerId], [IsInactive], [IsDeleted]) VALUES (21, N'Lauri', 0xF4FFC3528F7233C05620014759A00C8B9069744EFDE638E13EF389F1788947D2D9EA7C43B4BB6691A59617D2A4544A13B6D49D8D912469D4D22FD1912BB699077BC6848C2D6895B183CC5B9C78E552843177EAD410A390DFC2C0B1BC6C35CBD9FD7E1F8E062D88F3B5FB3A9D6F6F34693EA4006DF8ACFC958A1E630CDE30520B, 0x474D8FC7BBABDC6FB99EB3E01132BA97A6443B1724EFBFB94A0A7890EC6D9A3A9D3CABFFFDB9743B80F81F037762FE5118464C322E188137E1DB5CC0B5C40F91, N'lauri@mail.com', 2, CAST(N'2022-12-01T21:00:00.0000000' AS DateTime2), NULL, 0, 0)
GO
INSERT [dbo].[Users] ([UserId], [Username], [PasswordSalt], [PasswordHash], [Email], [Role], [CreatedOn], [PlayerId], [IsInactive], [IsDeleted]) VALUES (22, N'Sarita', 0xF4FFC3528F7233C05620014759A00C8B9069744EFDE638E13EF389F1788947D2D9EA7C43B4BB6691A59617D2A4544A13B6D49D8D912469D4D22FD1912BB699077BC6848C2D6895B183CC5B9C78E552843177EAD410A390DFC2C0B1BC6C35CBD9FD7E1F8E062D88F3B5FB3A9D6F6F34693EA4006DF8ACFC958A1E630CDE30520B, 0x474D8FC7BBABDC6FB99EB3E01132BA97A6443B1724EFBFB94A0A7890EC6D9A3A9D3CABFFFDB9743B80F81F037762FE5118464C322E188137E1DB5CC0B5C40F91, N'sarita@mail.com', 2, CAST(N'2022-12-01T22:00:00.0000000' AS DateTime2), NULL, 0, 0)
GO
INSERT [dbo].[Users] ([UserId], [Username], [PasswordSalt], [PasswordHash], [Email], [Role], [CreatedOn], [PlayerId], [IsInactive], [IsDeleted]) VALUES (23, N'Williams', 0xF4FFC3528F7233C05620014759A00C8B9069744EFDE638E13EF389F1788947D2D9EA7C43B4BB6691A59617D2A4544A13B6D49D8D912469D4D22FD1912BB699077BC6848C2D6895B183CC5B9C78E552843177EAD410A390DFC2C0B1BC6C35CBD9FD7E1F8E062D88F3B5FB3A9D6F6F34693EA4006DF8ACFC958A1E630CDE30520B, 0x474D8FC7BBABDC6FB99EB3E01132BA97A6443B1724EFBFB94A0A7890EC6D9A3A9D3CABFFFDB9743B80F81F037762FE5118464C322E188137E1DB5CC0B5C40F91, N'williams@mail.com', 2, CAST(N'2022-12-01T22:30:00.0000000' AS DateTime2), NULL, 0, 0)
GO
INSERT [dbo].[Users] ([UserId], [Username], [PasswordSalt], [PasswordHash], [Email], [Role], [CreatedOn], [PlayerId], [IsInactive], [IsDeleted]) VALUES (24, N'Jerad', 0xF4FFC3528F7233C05620014759A00C8B9069744EFDE638E13EF389F1788947D2D9EA7C43B4BB6691A59617D2A4544A13B6D49D8D912469D4D22FD1912BB699077BC6848C2D6895B183CC5B9C78E552843177EAD410A390DFC2C0B1BC6C35CBD9FD7E1F8E062D88F3B5FB3A9D6F6F34693EA4006DF8ACFC958A1E630CDE30520B, 0x474D8FC7BBABDC6FB99EB3E01132BA97A6443B1724EFBFB94A0A7890EC6D9A3A9D3CABFFFDB9743B80F81F037762FE5118464C322E188137E1DB5CC0B5C40F91, N'jerad@mail.com', 2, CAST(N'2022-12-01T23:00:00.0000000' AS DateTime2), NULL, 0, 0)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[Events] ON 
GO
INSERT [dbo].[Events] ([EventId], [Title], [EventType], [StartDate], [EndDate], [IsTeamEvent], [LocationId], [matchType], [MatchLimitValue], [ScoreForWin], [ScoreForDraw], [ChampionId], [DirectorId], [IsCompleted], [IsDeleted]) VALUES (1, N'League of Legends Championship S', 2, CAST(N'2022-11-09T00:00:00.0000000' AS DateTime2), CAST(N'2022-11-18T00:00:00.0000000' AS DateTime2), 1, 1, 0, 20, 0, 0, NULL, 3, 0, 1)
GO
INSERT [dbo].[Events] ([EventId], [Title], [EventType], [StartDate], [EndDate], [IsTeamEvent], [LocationId], [matchType], [MatchLimitValue], [ScoreForWin], [ScoreForDraw], [ChampionId], [DirectorId], [IsCompleted], [IsDeleted]) VALUES (2, N'EU League of Legends Championshi', 2, CAST(N'2022-12-10T00:00:00.0000000' AS DateTime2), CAST(N'2022-12-20T00:00:00.0000000' AS DateTime2), 1, 3, 0, 20, 2, 1, 1, 3, 1, 0)
GO
INSERT [dbo].[Events] ([EventId], [Title], [EventType], [StartDate], [EndDate], [IsTeamEvent], [LocationId], [matchType], [MatchLimitValue], [ScoreForWin], [ScoreForDraw], [ChampionId], [DirectorId], [IsCompleted], [IsDeleted]) VALUES (3, N'CSGO Major Championships', 1, CAST(N'2022-12-13T00:00:00.0000000' AS DateTime2), CAST(N'2022-12-16T00:00:00.0000000' AS DateTime2), 0, 2, 0, 30, 0, 0, 18, 3, 1, 0)
GO
INSERT [dbo].[Events] ([EventId], [Title], [EventType], [StartDate], [EndDate], [IsTeamEvent], [LocationId], [matchType], [MatchLimitValue], [ScoreForWin], [ScoreForDraw], [ChampionId], [DirectorId], [IsCompleted], [IsDeleted]) VALUES (4, N'Fortnite World Cup', 2, CAST(N'2022-11-15T00:00:00.0000000' AS DateTime2), CAST(N'2022-12-20T00:00:00.0000000' AS DateTime2), 1, 4, 1, 9, 2, 1, 2, 3, 1, 0)
GO
INSERT [dbo].[Events] ([EventId], [Title], [EventType], [StartDate], [EndDate], [IsTeamEvent], [LocationId], [matchType], [MatchLimitValue], [ScoreForWin], [ScoreForDraw], [ChampionId], [DirectorId], [IsCompleted], [IsDeleted]) VALUES (5, N'Honor of Kings Champion Cup', 1, CAST(N'2022-11-21T00:00:00.0000000' AS DateTime2), CAST(N'2022-11-26T00:00:00.0000000' AS DateTime2), 0, 3, 0, 40, 0, 0, 15, 3, 1, 0)
GO
INSERT [dbo].[Events] ([EventId], [Title], [EventType], [StartDate], [EndDate], [IsTeamEvent], [LocationId], [matchType], [MatchLimitValue], [ScoreForWin], [ScoreForDraw], [ChampionId], [DirectorId], [IsCompleted], [IsDeleted]) VALUES (6, N'Valorant Death Match', 0, CAST(N'2022-11-22T00:00:00.0000000' AS DateTime2), CAST(N'2022-11-22T00:00:00.0000000' AS DateTime2), 1, 1, 0, 50, 0, 0, 4, 3, 1, 0)
GO
INSERT [dbo].[Events] ([EventId], [Title], [EventType], [StartDate], [EndDate], [IsTeamEvent], [LocationId], [matchType], [MatchLimitValue], [ScoreForWin], [ScoreForDraw], [ChampionId], [DirectorId], [IsCompleted], [IsDeleted]) VALUES (7, N'Call of Duty League', 2, CAST(N'2022-12-06T00:00:00.0000000' AS DateTime2), CAST(N'2022-12-11T00:00:00.0000000' AS DateTime2), 1, 4, 0, 40, 2, 1, NULL, 3, 0, 0)
GO
INSERT [dbo].[Events] ([EventId], [Title], [EventType], [StartDate], [EndDate], [IsTeamEvent], [LocationId], [matchType], [MatchLimitValue], [ScoreForWin], [ScoreForDraw], [ChampionId], [DirectorId], [IsCompleted], [IsDeleted]) VALUES (8, N'League of Legends London Knockou', 1, CAST(N'2022-12-07T00:00:00.0000000' AS DateTime2), CAST(N'2022-12-10T00:00:00.0000000' AS DateTime2), 0, 3, 0, 20, 0, 0, NULL, 3, 0, 0)
GO
INSERT [dbo].[Events] ([EventId], [Title], [EventType], [StartDate], [EndDate], [IsTeamEvent], [LocationId], [matchType], [MatchLimitValue], [ScoreForWin], [ScoreForDraw], [ChampionId], [DirectorId], [IsCompleted], [IsDeleted]) VALUES (9, N'GoGames360 2023', 2, CAST(N'2023-01-11T00:00:00.0000000' AS DateTime2), CAST(N'2023-01-18T00:00:00.0000000' AS DateTime2), 0, 1, 1, 18, 2, 1, NULL, 3, 0, 0)
GO
INSERT [dbo].[Events] ([EventId], [Title], [EventType], [StartDate], [EndDate], [IsTeamEvent], [LocationId], [matchType], [MatchLimitValue], [ScoreForWin], [ScoreForDraw], [ChampionId], [DirectorId], [IsCompleted], [IsDeleted]) VALUES (10, N'Tribeca Festival 2023', 1, CAST(N'2023-01-15T00:00:00.0000000' AS DateTime2), CAST(N'2023-01-19T00:00:00.0000000' AS DateTime2), 1, 2, 0, 45, 0, 0, NULL, 3, 0, 0)
GO
INSERT [dbo].[Events] ([EventId], [Title], [EventType], [StartDate], [EndDate], [IsTeamEvent], [LocationId], [matchType], [MatchLimitValue], [ScoreForWin], [ScoreForDraw], [ChampionId], [DirectorId], [IsCompleted], [IsDeleted]) VALUES (11, N'Dune 2000 Vintage', 2, CAST(N'2023-01-20T00:00:00.0000000' AS DateTime2), CAST(N'2023-01-30T00:00:00.0000000' AS DateTime2), 0, 4, 1, 51, 2, 1, NULL, 3, 0, 0)
GO
INSERT [dbo].[Events] ([EventId], [Title], [EventType], [StartDate], [EndDate], [IsTeamEvent], [LocationId], [matchType], [MatchLimitValue], [ScoreForWin], [ScoreForDraw], [ChampionId], [DirectorId], [IsCompleted], [IsDeleted]) VALUES (12, N'Command & Conquer Generals Leagu', 1, CAST(N'2023-02-03T00:00:00.0000000' AS DateTime2), CAST(N'2023-02-07T00:00:00.0000000' AS DateTime2), 0, 3, 0, 50, 0, 0, NULL, 3, 0, 0)
GO
INSERT [dbo].[Events] ([EventId], [Title], [EventType], [StartDate], [EndDate], [IsTeamEvent], [LocationId], [matchType], [MatchLimitValue], [ScoreForWin], [ScoreForDraw], [ChampionId], [DirectorId], [IsCompleted], [IsDeleted]) VALUES (13, N'Poker F2F Context', 0, CAST(N'2023-04-01T00:00:00.0000000' AS DateTime2), CAST(N'2023-04-01T00:00:00.0000000' AS DateTime2), 0, 2, 0, 60, 0, 0, NULL, 3, 0, 0)
GO
INSERT [dbo].[Events] ([EventId], [Title], [EventType], [StartDate], [EndDate], [IsTeamEvent], [LocationId], [matchType], [MatchLimitValue], [ScoreForWin], [ScoreForDraw], [ChampionId], [DirectorId], [IsCompleted], [IsDeleted]) VALUES (14, N'Age of Empire III Conquest', 2, CAST(N'2022-12-16T00:00:00.0000000' AS DateTime2), CAST(N'2022-12-29T00:00:00.0000000' AS DateTime2), 1, 4, 0, 90, 2, 1, NULL, 3, 0, 0)
GO
SET IDENTITY_INSERT [dbo].[Events] OFF
GO
SET IDENTITY_INSERT [dbo].[Awards] ON 
GO
INSERT [dbo].[Awards] ([AwardId], [EventId], [Rank], [Prize], [IsDeleted]) VALUES (1, 1, 1, 0.0000, 1)
GO
INSERT [dbo].[Awards] ([AwardId], [EventId], [Rank], [Prize], [IsDeleted]) VALUES (2, 1, 2, 0.0000, 1)
GO
INSERT [dbo].[Awards] ([AwardId], [EventId], [Rank], [Prize], [IsDeleted]) VALUES (3, 1, 3, 0.0000, 1)
GO
INSERT [dbo].[Awards] ([AwardId], [EventId], [Rank], [Prize], [IsDeleted]) VALUES (4, 2, 1, 10000.0000, 0)
GO
INSERT [dbo].[Awards] ([AwardId], [EventId], [Rank], [Prize], [IsDeleted]) VALUES (5, 2, 2, 6000.0000, 0)
GO
INSERT [dbo].[Awards] ([AwardId], [EventId], [Rank], [Prize], [IsDeleted]) VALUES (6, 2, 3, 1000.0000, 0)
GO
INSERT [dbo].[Awards] ([AwardId], [EventId], [Rank], [Prize], [IsDeleted]) VALUES (7, 3, 1, 5000.0000, 0)
GO
INSERT [dbo].[Awards] ([AwardId], [EventId], [Rank], [Prize], [IsDeleted]) VALUES (8, 3, 2, 2000.0000, 0)
GO
INSERT [dbo].[Awards] ([AwardId], [EventId], [Rank], [Prize], [IsDeleted]) VALUES (9, 4, 1, 5000.0000, 0)
GO
INSERT [dbo].[Awards] ([AwardId], [EventId], [Rank], [Prize], [IsDeleted]) VALUES (10, 4, 2, 1000.0000, 0)
GO
INSERT [dbo].[Awards] ([AwardId], [EventId], [Rank], [Prize], [IsDeleted]) VALUES (11, 4, 3, 600.0000, 0)
GO
INSERT [dbo].[Awards] ([AwardId], [EventId], [Rank], [Prize], [IsDeleted]) VALUES (12, 5, 1, 15000.0000, 0)
GO
INSERT [dbo].[Awards] ([AwardId], [EventId], [Rank], [Prize], [IsDeleted]) VALUES (13, 5, 2, 7500.0000, 0)
GO
INSERT [dbo].[Awards] ([AwardId], [EventId], [Rank], [Prize], [IsDeleted]) VALUES (14, 6, 1, 0.0000, 0)
GO
INSERT [dbo].[Awards] ([AwardId], [EventId], [Rank], [Prize], [IsDeleted]) VALUES (15, 6, 2, 0.0000, 0)
GO
INSERT [dbo].[Awards] ([AwardId], [EventId], [Rank], [Prize], [IsDeleted]) VALUES (16, 7, 1, 2000.0000, 0)
GO
INSERT [dbo].[Awards] ([AwardId], [EventId], [Rank], [Prize], [IsDeleted]) VALUES (17, 7, 2, 900.0000, 0)
GO
INSERT [dbo].[Awards] ([AwardId], [EventId], [Rank], [Prize], [IsDeleted]) VALUES (18, 7, 3, 400.0000, 0)
GO
INSERT [dbo].[Awards] ([AwardId], [EventId], [Rank], [Prize], [IsDeleted]) VALUES (19, 8, 1, 0.0000, 0)
GO
INSERT [dbo].[Awards] ([AwardId], [EventId], [Rank], [Prize], [IsDeleted]) VALUES (20, 8, 2, 0.0000, 0)
GO
INSERT [dbo].[Awards] ([AwardId], [EventId], [Rank], [Prize], [IsDeleted]) VALUES (21, 9, 1, 20000.0000, 0)
GO
INSERT [dbo].[Awards] ([AwardId], [EventId], [Rank], [Prize], [IsDeleted]) VALUES (22, 9, 2, 10000.0000, 0)
GO
INSERT [dbo].[Awards] ([AwardId], [EventId], [Rank], [Prize], [IsDeleted]) VALUES (23, 9, 3, 2000.0000, 0)
GO
INSERT [dbo].[Awards] ([AwardId], [EventId], [Rank], [Prize], [IsDeleted]) VALUES (24, 10, 1, 8000.0000, 0)
GO
INSERT [dbo].[Awards] ([AwardId], [EventId], [Rank], [Prize], [IsDeleted]) VALUES (25, 10, 2, 3000.0000, 0)
GO
INSERT [dbo].[Awards] ([AwardId], [EventId], [Rank], [Prize], [IsDeleted]) VALUES (26, 11, 1, 3000.0000, 0)
GO
INSERT [dbo].[Awards] ([AwardId], [EventId], [Rank], [Prize], [IsDeleted]) VALUES (27, 11, 2, 1500.0000, 0)
GO
INSERT [dbo].[Awards] ([AwardId], [EventId], [Rank], [Prize], [IsDeleted]) VALUES (28, 11, 3, 700.0000, 0)
GO
INSERT [dbo].[Awards] ([AwardId], [EventId], [Rank], [Prize], [IsDeleted]) VALUES (29, 12, 1, 8000.0000, 0)
GO
INSERT [dbo].[Awards] ([AwardId], [EventId], [Rank], [Prize], [IsDeleted]) VALUES (30, 12, 2, 3000.0000, 0)
GO
INSERT [dbo].[Awards] ([AwardId], [EventId], [Rank], [Prize], [IsDeleted]) VALUES (31, 13, 1, 1000000.0000, 0)
GO
INSERT [dbo].[Awards] ([AwardId], [EventId], [Rank], [Prize], [IsDeleted]) VALUES (32, 13, 2, 1.0000, 0)
GO
INSERT [dbo].[Awards] ([AwardId], [EventId], [Rank], [Prize], [IsDeleted]) VALUES (33, 14, 1, 0.0000, 0)
GO
INSERT [dbo].[Awards] ([AwardId], [EventId], [Rank], [Prize], [IsDeleted]) VALUES (34, 14, 2, 0.0000, 0)
GO
INSERT [dbo].[Awards] ([AwardId], [EventId], [Rank], [Prize], [IsDeleted]) VALUES (35, 14, 3, 0.0000, 0)
GO
SET IDENTITY_INSERT [dbo].[Awards] OFF
GO
SET IDENTITY_INSERT [dbo].[Matches] ON 
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (1, CAST(N'2022-11-10T00:00:00.0000000' AS DateTime2), 2, 3, 0, N'TimeLimitedMatch', NULL, 0, 20)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (2, CAST(N'2022-11-10T00:00:00.0000000' AS DateTime2), 2, 3, 0, N'TimeLimitedMatch', NULL, 0, 20)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (3, CAST(N'2022-11-10T00:00:00.0000000' AS DateTime2), 2, 3, 0, N'TimeLimitedMatch', NULL, 0, 20)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (4, CAST(N'2022-11-11T00:00:00.0000000' AS DateTime2), 2, 3, 0, N'TimeLimitedMatch', NULL, 0, 20)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (5, CAST(N'2022-11-11T00:00:00.0000000' AS DateTime2), 2, 3, 0, N'TimeLimitedMatch', NULL, 0, 20)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (6, CAST(N'2022-11-10T00:00:00.0000000' AS DateTime2), 2, 3, 0, N'TimeLimitedMatch', NULL, 0, 20)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (7, CAST(N'2022-11-10T00:00:00.0000000' AS DateTime2), 2, 3, 0, N'TimeLimitedMatch', NULL, 0, 20)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (8, CAST(N'2022-11-10T00:00:00.0000000' AS DateTime2), 2, 3, 0, N'TimeLimitedMatch', NULL, 0, 20)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (9, CAST(N'2022-11-10T00:00:00.0000000' AS DateTime2), 2, 3, 0, N'TimeLimitedMatch', NULL, 0, 20)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (10, CAST(N'2022-11-10T00:00:00.0000000' AS DateTime2), 2, 3, 0, N'TimeLimitedMatch', NULL, 0, 20)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (11, CAST(N'2022-11-10T00:00:00.0000000' AS DateTime2), 2, 3, 0, N'TimeLimitedMatch', NULL, 0, 20)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (12, CAST(N'2022-11-10T00:00:00.0000000' AS DateTime2), 2, 3, 0, N'TimeLimitedMatch', NULL, 0, 20)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (13, CAST(N'2022-11-10T00:00:00.0000000' AS DateTime2), 2, 3, 0, N'TimeLimitedMatch', NULL, 0, 20)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (14, CAST(N'2022-11-10T00:00:00.0000000' AS DateTime2), 2, 3, 0, N'TimeLimitedMatch', NULL, 0, 20)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (15, CAST(N'2022-11-10T00:00:00.0000000' AS DateTime2), 2, 3, 0, N'TimeLimitedMatch', NULL, 0, 20)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (16, CAST(N'2022-11-10T00:00:00.0000000' AS DateTime2), 2, 3, 0, N'TimeLimitedMatch', NULL, 0, 20)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (17, CAST(N'2022-11-10T00:00:00.0000000' AS DateTime2), 2, 3, 0, N'TimeLimitedMatch', NULL, 0, 20)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (18, CAST(N'2022-11-10T00:00:00.0000000' AS DateTime2), 2, 3, 0, N'TimeLimitedMatch', NULL, 0, 20)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (19, CAST(N'2022-11-10T00:00:00.0000000' AS DateTime2), 2, 3, 0, N'TimeLimitedMatch', NULL, 0, 20)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (20, CAST(N'2022-11-10T00:00:00.0000000' AS DateTime2), 2, 3, 0, N'TimeLimitedMatch', NULL, 0, 20)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (21, CAST(N'2022-11-10T00:00:00.0000000' AS DateTime2), 2, 3, 0, N'TimeLimitedMatch', NULL, 0, 20)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (22, CAST(N'2022-11-10T00:00:00.0000000' AS DateTime2), 2, 3, 0, N'TimeLimitedMatch', NULL, 0, 20)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (23, CAST(N'2022-11-10T00:00:00.0000000' AS DateTime2), 2, 3, 0, N'TimeLimitedMatch', NULL, 0, 20)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (24, CAST(N'2022-11-10T00:00:00.0000000' AS DateTime2), 2, 3, 0, N'TimeLimitedMatch', NULL, 0, 20)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (25, CAST(N'2022-11-10T00:00:00.0000000' AS DateTime2), 2, 3, 0, N'TimeLimitedMatch', NULL, 0, 20)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (26, CAST(N'2022-11-10T00:00:00.0000000' AS DateTime2), 2, 3, 0, N'TimeLimitedMatch', NULL, 0, 20)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (27, CAST(N'2022-11-10T00:00:00.0000000' AS DateTime2), 2, 3, 0, N'TimeLimitedMatch', NULL, 0, 20)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (28, CAST(N'2022-11-10T00:00:00.0000000' AS DateTime2), 2, 3, 0, N'TimeLimitedMatch', NULL, 0, 20)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (29, CAST(N'2022-11-10T00:00:00.0000000' AS DateTime2), 2, 3, 0, N'TimeLimitedMatch', NULL, 0, 20)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (30, CAST(N'2022-11-10T00:00:00.0000000' AS DateTime2), 2, 3, 0, N'TimeLimitedMatch', NULL, 0, 20)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (31, CAST(N'2022-12-13T00:00:00.0000000' AS DateTime2), 3, 2, 0, N'TimeLimitedMatch', NULL, 0, 30)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (32, CAST(N'2022-12-13T00:00:00.0000000' AS DateTime2), 3, 2, 0, N'TimeLimitedMatch', NULL, 0, 30)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (33, CAST(N'2022-12-13T00:00:00.0000000' AS DateTime2), 3, 2, 0, N'TimeLimitedMatch', NULL, 0, 30)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (34, CAST(N'2022-12-13T00:00:00.0000000' AS DateTime2), 3, 2, 0, N'TimeLimitedMatch', NULL, 0, 30)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (35, CAST(N'2022-12-13T00:00:00.0000000' AS DateTime2), 3, 2, 0, N'TimeLimitedMatch', NULL, 0, 30)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (36, CAST(N'2022-12-13T00:00:00.0000000' AS DateTime2), 3, 2, 0, N'TimeLimitedMatch', NULL, 0, 30)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (37, CAST(N'2022-12-13T00:00:00.0000000' AS DateTime2), 3, 2, 0, N'TimeLimitedMatch', NULL, 0, 30)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (38, CAST(N'2022-11-15T00:00:00.0000000' AS DateTime2), 4, 4, 0, N'ScoreLimitedMatch', 9, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (39, CAST(N'2022-11-15T00:00:00.0000000' AS DateTime2), 4, 4, 0, N'ScoreLimitedMatch', 9, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (40, CAST(N'2022-11-16T00:00:00.0000000' AS DateTime2), 4, 4, 0, N'ScoreLimitedMatch', 9, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (41, CAST(N'2022-11-16T00:00:00.0000000' AS DateTime2), 4, 4, 0, N'ScoreLimitedMatch', 9, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (42, CAST(N'2022-11-17T00:00:00.0000000' AS DateTime2), 4, 4, 0, N'ScoreLimitedMatch', 9, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (43, CAST(N'2022-11-17T00:00:00.0000000' AS DateTime2), 4, 4, 0, N'ScoreLimitedMatch', 9, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (44, CAST(N'2022-11-18T00:00:00.0000000' AS DateTime2), 4, 4, 0, N'ScoreLimitedMatch', 9, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (45, CAST(N'2022-11-18T00:00:00.0000000' AS DateTime2), 4, 4, 0, N'ScoreLimitedMatch', 9, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (46, CAST(N'2022-11-19T00:00:00.0000000' AS DateTime2), 4, 4, 0, N'ScoreLimitedMatch', 9, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (47, CAST(N'2022-11-19T00:00:00.0000000' AS DateTime2), 4, 4, 0, N'ScoreLimitedMatch', 9, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (48, CAST(N'2022-11-20T00:00:00.0000000' AS DateTime2), 4, 4, 0, N'ScoreLimitedMatch', 9, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (49, CAST(N'2022-11-20T00:00:00.0000000' AS DateTime2), 4, 4, 0, N'ScoreLimitedMatch', 9, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (50, CAST(N'2022-11-21T00:00:00.0000000' AS DateTime2), 5, 3, 0, N'TimeLimitedMatch', NULL, 0, 40)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (51, CAST(N'2022-11-21T00:00:00.0000000' AS DateTime2), 5, 3, 0, N'TimeLimitedMatch', NULL, 0, 40)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (52, CAST(N'2022-11-21T00:00:00.0000000' AS DateTime2), 5, 3, 0, N'TimeLimitedMatch', NULL, 0, 40)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (53, CAST(N'2022-11-21T00:00:00.0000000' AS DateTime2), 5, 3, 0, N'TimeLimitedMatch', NULL, 0, 40)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (54, CAST(N'2022-11-21T00:00:00.0000000' AS DateTime2), 5, 3, 0, N'TimeLimitedMatch', NULL, 0, 40)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (55, CAST(N'2022-11-21T00:00:00.0000000' AS DateTime2), 5, 3, 0, N'TimeLimitedMatch', NULL, 0, 40)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (56, CAST(N'2022-11-21T00:00:00.0000000' AS DateTime2), 5, 3, 0, N'TimeLimitedMatch', NULL, 0, 40)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (57, CAST(N'2022-11-21T00:00:00.0000000' AS DateTime2), 5, 3, 0, N'TimeLimitedMatch', NULL, 0, 40)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (58, CAST(N'2022-11-21T00:00:00.0000000' AS DateTime2), 5, 3, 0, N'TimeLimitedMatch', NULL, 0, 40)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (59, CAST(N'2022-11-21T00:00:00.0000000' AS DateTime2), 5, 3, 0, N'TimeLimitedMatch', NULL, 0, 40)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (60, CAST(N'2022-11-21T00:00:00.0000000' AS DateTime2), 5, 3, 0, N'TimeLimitedMatch', NULL, 0, 40)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (61, CAST(N'2022-11-21T00:00:00.0000000' AS DateTime2), 5, 3, 0, N'TimeLimitedMatch', NULL, 0, 40)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (62, CAST(N'2022-11-21T00:00:00.0000000' AS DateTime2), 5, 3, 0, N'TimeLimitedMatch', NULL, 0, 40)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (63, CAST(N'2022-11-21T00:00:00.0000000' AS DateTime2), 5, 3, 0, N'TimeLimitedMatch', NULL, 0, 40)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (64, CAST(N'2022-11-21T00:00:00.0000000' AS DateTime2), 5, 3, 0, N'TimeLimitedMatch', NULL, 0, 40)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (65, CAST(N'2022-11-22T00:00:00.0000000' AS DateTime2), 6, 1, 0, N'TimeLimitedMatch', NULL, 0, 50)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (66, CAST(N'2022-12-06T00:00:00.0000000' AS DateTime2), 7, 4, 0, N'TimeLimitedMatch', NULL, 0, 40)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (67, CAST(N'2022-12-06T00:00:00.0000000' AS DateTime2), 7, 4, 0, N'TimeLimitedMatch', NULL, 0, 40)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (68, CAST(N'2022-12-07T00:00:00.0000000' AS DateTime2), 7, 4, 0, N'TimeLimitedMatch', NULL, 0, 40)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (69, CAST(N'2022-12-07T00:00:00.0000000' AS DateTime2), 7, 4, 0, N'TimeLimitedMatch', NULL, 0, 40)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (70, CAST(N'2022-12-08T00:00:00.0000000' AS DateTime2), 7, 4, 0, N'TimeLimitedMatch', NULL, 0, 40)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (71, CAST(N'2022-12-08T00:00:00.0000000' AS DateTime2), 7, 4, 0, N'TimeLimitedMatch', NULL, 0, 40)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (72, CAST(N'2022-12-09T00:00:00.0000000' AS DateTime2), 7, 4, 0, N'TimeLimitedMatch', NULL, 0, 40)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (73, CAST(N'2022-12-09T00:00:00.0000000' AS DateTime2), 7, 4, 0, N'TimeLimitedMatch', NULL, 0, 40)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (74, CAST(N'2022-12-10T00:00:00.0000000' AS DateTime2), 7, 4, 0, N'TimeLimitedMatch', NULL, 0, 40)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (75, CAST(N'2022-12-10T00:00:00.0000000' AS DateTime2), 7, 4, 0, N'TimeLimitedMatch', NULL, 0, 40)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (76, CAST(N'2022-12-11T00:00:00.0000000' AS DateTime2), 7, 4, 0, N'TimeLimitedMatch', NULL, 0, 40)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (77, CAST(N'2022-12-11T00:00:00.0000000' AS DateTime2), 7, 4, 0, N'TimeLimitedMatch', NULL, 0, 40)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (78, CAST(N'2022-12-07T00:00:00.0000000' AS DateTime2), 8, 3, 0, N'TimeLimitedMatch', NULL, 0, 20)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (79, CAST(N'2022-12-07T00:00:00.0000000' AS DateTime2), 8, 3, 0, N'TimeLimitedMatch', NULL, 0, 20)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (80, CAST(N'2022-12-07T00:00:00.0000000' AS DateTime2), 8, 3, 0, N'TimeLimitedMatch', NULL, 0, 20)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (81, CAST(N'2022-12-07T00:00:00.0000000' AS DateTime2), 8, 3, 0, N'TimeLimitedMatch', NULL, 0, 20)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (82, CAST(N'2022-12-08T00:00:00.0000000' AS DateTime2), 8, 3, 0, N'TimeLimitedMatch', NULL, 0, 20)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (83, CAST(N'2022-12-08T00:00:00.0000000' AS DateTime2), 8, 3, 0, N'TimeLimitedMatch', NULL, 0, 20)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (84, CAST(N'2022-12-10T00:00:00.0000000' AS DateTime2), 8, 3, 0, N'TimeLimitedMatch', NULL, 0, 20)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (85, CAST(N'2023-01-11T00:00:00.0000000' AS DateTime2), 9, 1, 0, N'ScoreLimitedMatch', 18, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (86, CAST(N'2023-01-11T00:00:00.0000000' AS DateTime2), 9, 1, 0, N'ScoreLimitedMatch', 18, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (87, CAST(N'2023-01-11T00:00:00.0000000' AS DateTime2), 9, 1, 0, N'ScoreLimitedMatch', 18, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (88, CAST(N'2023-01-11T00:00:00.0000000' AS DateTime2), 9, 1, 0, N'ScoreLimitedMatch', 18, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (89, CAST(N'2023-01-11T00:00:00.0000000' AS DateTime2), 9, 1, 0, N'ScoreLimitedMatch', 18, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (90, CAST(N'2023-01-11T00:00:00.0000000' AS DateTime2), 9, 1, 0, N'ScoreLimitedMatch', 18, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (91, CAST(N'2023-01-11T00:00:00.0000000' AS DateTime2), 9, 1, 0, N'ScoreLimitedMatch', 18, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (92, CAST(N'2023-01-11T00:00:00.0000000' AS DateTime2), 9, 1, 0, N'ScoreLimitedMatch', 18, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (93, CAST(N'2023-01-11T00:00:00.0000000' AS DateTime2), 9, 1, 0, N'ScoreLimitedMatch', 18, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (94, CAST(N'2023-01-11T00:00:00.0000000' AS DateTime2), 9, 1, 0, N'ScoreLimitedMatch', 18, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (95, CAST(N'2023-01-11T00:00:00.0000000' AS DateTime2), 9, 1, 0, N'ScoreLimitedMatch', 18, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (96, CAST(N'2023-01-11T00:00:00.0000000' AS DateTime2), 9, 1, 0, N'ScoreLimitedMatch', 18, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (97, CAST(N'2023-01-11T00:00:00.0000000' AS DateTime2), 9, 1, 0, N'ScoreLimitedMatch', 18, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (98, CAST(N'2023-01-11T00:00:00.0000000' AS DateTime2), 9, 1, 0, N'ScoreLimitedMatch', 18, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (99, CAST(N'2023-01-11T00:00:00.0000000' AS DateTime2), 9, 1, 0, N'ScoreLimitedMatch', 18, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (100, CAST(N'2023-01-11T00:00:00.0000000' AS DateTime2), 9, 1, 0, N'ScoreLimitedMatch', 18, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (101, CAST(N'2023-01-11T00:00:00.0000000' AS DateTime2), 9, 1, 0, N'ScoreLimitedMatch', 18, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (102, CAST(N'2023-01-11T00:00:00.0000000' AS DateTime2), 9, 1, 0, N'ScoreLimitedMatch', 18, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (103, CAST(N'2023-01-11T00:00:00.0000000' AS DateTime2), 9, 1, 0, N'ScoreLimitedMatch', 18, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (104, CAST(N'2023-01-11T00:00:00.0000000' AS DateTime2), 9, 1, 0, N'ScoreLimitedMatch', 18, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (105, CAST(N'2023-01-11T00:00:00.0000000' AS DateTime2), 9, 1, 0, N'ScoreLimitedMatch', 18, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (106, CAST(N'2023-01-11T00:00:00.0000000' AS DateTime2), 9, 1, 0, N'ScoreLimitedMatch', 18, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (107, CAST(N'2023-01-11T00:00:00.0000000' AS DateTime2), 9, 1, 0, N'ScoreLimitedMatch', 18, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (108, CAST(N'2023-01-11T00:00:00.0000000' AS DateTime2), 9, 1, 0, N'ScoreLimitedMatch', 18, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (109, CAST(N'2023-01-11T00:00:00.0000000' AS DateTime2), 9, 1, 0, N'ScoreLimitedMatch', 18, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (110, CAST(N'2023-01-11T00:00:00.0000000' AS DateTime2), 9, 1, 0, N'ScoreLimitedMatch', 18, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (111, CAST(N'2023-01-11T00:00:00.0000000' AS DateTime2), 9, 1, 0, N'ScoreLimitedMatch', 18, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (112, CAST(N'2023-01-11T00:00:00.0000000' AS DateTime2), 9, 1, 0, N'ScoreLimitedMatch', 18, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (113, CAST(N'2023-01-11T00:00:00.0000000' AS DateTime2), 9, 1, 0, N'ScoreLimitedMatch', 18, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (114, CAST(N'2023-01-11T00:00:00.0000000' AS DateTime2), 9, 1, 0, N'ScoreLimitedMatch', 18, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (115, CAST(N'2023-01-11T00:00:00.0000000' AS DateTime2), 9, 1, 0, N'ScoreLimitedMatch', 18, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (116, CAST(N'2023-01-11T00:00:00.0000000' AS DateTime2), 9, 1, 0, N'ScoreLimitedMatch', 18, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (117, CAST(N'2023-01-11T00:00:00.0000000' AS DateTime2), 9, 1, 0, N'ScoreLimitedMatch', 18, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (118, CAST(N'2023-01-11T00:00:00.0000000' AS DateTime2), 9, 1, 0, N'ScoreLimitedMatch', 18, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (119, CAST(N'2023-01-11T00:00:00.0000000' AS DateTime2), 9, 1, 0, N'ScoreLimitedMatch', 18, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (120, CAST(N'2023-01-11T00:00:00.0000000' AS DateTime2), 9, 1, 0, N'ScoreLimitedMatch', 18, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (121, CAST(N'2023-01-11T00:00:00.0000000' AS DateTime2), 9, 1, 0, N'ScoreLimitedMatch', 18, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (122, CAST(N'2023-01-11T00:00:00.0000000' AS DateTime2), 9, 1, 0, N'ScoreLimitedMatch', 18, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (123, CAST(N'2023-01-11T00:00:00.0000000' AS DateTime2), 9, 1, 0, N'ScoreLimitedMatch', 18, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (124, CAST(N'2023-01-11T00:00:00.0000000' AS DateTime2), 9, 1, 0, N'ScoreLimitedMatch', 18, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (125, CAST(N'2023-01-11T00:00:00.0000000' AS DateTime2), 9, 1, 0, N'ScoreLimitedMatch', 18, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (126, CAST(N'2023-01-11T00:00:00.0000000' AS DateTime2), 9, 1, 0, N'ScoreLimitedMatch', 18, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (127, CAST(N'2023-01-11T00:00:00.0000000' AS DateTime2), 9, 1, 0, N'ScoreLimitedMatch', 18, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (128, CAST(N'2023-01-11T00:00:00.0000000' AS DateTime2), 9, 1, 0, N'ScoreLimitedMatch', 18, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (129, CAST(N'2023-01-11T00:00:00.0000000' AS DateTime2), 9, 1, 0, N'ScoreLimitedMatch', 18, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (130, CAST(N'2023-01-11T00:00:00.0000000' AS DateTime2), 9, 1, 0, N'ScoreLimitedMatch', 18, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (131, CAST(N'2023-01-11T00:00:00.0000000' AS DateTime2), 9, 1, 0, N'ScoreLimitedMatch', 18, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (132, CAST(N'2023-01-11T00:00:00.0000000' AS DateTime2), 9, 1, 0, N'ScoreLimitedMatch', 18, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (133, CAST(N'2023-01-11T00:00:00.0000000' AS DateTime2), 9, 1, 0, N'ScoreLimitedMatch', 18, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (134, CAST(N'2023-01-11T00:00:00.0000000' AS DateTime2), 9, 1, 0, N'ScoreLimitedMatch', 18, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (135, CAST(N'2023-01-11T00:00:00.0000000' AS DateTime2), 9, 1, 0, N'ScoreLimitedMatch', 18, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (136, CAST(N'2023-01-11T00:00:00.0000000' AS DateTime2), 9, 1, 0, N'ScoreLimitedMatch', 18, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (137, CAST(N'2023-01-11T00:00:00.0000000' AS DateTime2), 9, 1, 0, N'ScoreLimitedMatch', 18, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (138, CAST(N'2023-01-11T00:00:00.0000000' AS DateTime2), 9, 1, 0, N'ScoreLimitedMatch', 18, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (139, CAST(N'2023-01-11T00:00:00.0000000' AS DateTime2), 9, 1, 0, N'ScoreLimitedMatch', 18, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (140, CAST(N'2023-01-11T00:00:00.0000000' AS DateTime2), 9, 1, 0, N'ScoreLimitedMatch', 18, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (141, CAST(N'2023-01-15T00:00:00.0000000' AS DateTime2), 10, 2, 0, N'TimeLimitedMatch', NULL, 0, 45)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (142, CAST(N'2023-01-15T00:00:00.0000000' AS DateTime2), 10, 2, 0, N'TimeLimitedMatch', NULL, 0, 45)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (143, CAST(N'2023-01-15T00:00:00.0000000' AS DateTime2), 10, 2, 0, N'TimeLimitedMatch', NULL, 0, 45)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (144, CAST(N'2023-01-15T00:00:00.0000000' AS DateTime2), 10, 2, 0, N'TimeLimitedMatch', NULL, 0, 45)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (145, CAST(N'2023-01-17T00:00:00.0000000' AS DateTime2), 10, 2, 0, N'TimeLimitedMatch', NULL, 0, 45)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (146, CAST(N'2023-01-17T00:00:00.0000000' AS DateTime2), 10, 2, 0, N'TimeLimitedMatch', NULL, 0, 45)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (147, CAST(N'2023-01-19T00:00:00.0000000' AS DateTime2), 10, 2, 0, N'TimeLimitedMatch', NULL, 0, 45)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (148, CAST(N'2023-01-20T00:00:00.0000000' AS DateTime2), 11, 4, 0, N'ScoreLimitedMatch', 51, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (149, CAST(N'2023-01-20T00:00:00.0000000' AS DateTime2), 11, 4, 0, N'ScoreLimitedMatch', 51, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (150, CAST(N'2023-01-20T00:00:00.0000000' AS DateTime2), 11, 4, 0, N'ScoreLimitedMatch', 51, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (151, CAST(N'2023-01-21T00:00:00.0000000' AS DateTime2), 11, 4, 0, N'ScoreLimitedMatch', 51, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (152, CAST(N'2023-01-21T00:00:00.0000000' AS DateTime2), 11, 4, 0, N'ScoreLimitedMatch', 51, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (153, CAST(N'2023-01-21T00:00:00.0000000' AS DateTime2), 11, 4, 0, N'ScoreLimitedMatch', 51, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (154, CAST(N'2023-01-22T00:00:00.0000000' AS DateTime2), 11, 4, 0, N'ScoreLimitedMatch', 51, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (155, CAST(N'2023-01-22T00:00:00.0000000' AS DateTime2), 11, 4, 0, N'ScoreLimitedMatch', 51, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (156, CAST(N'2023-01-22T00:00:00.0000000' AS DateTime2), 11, 4, 0, N'ScoreLimitedMatch', 51, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (157, CAST(N'2023-01-23T00:00:00.0000000' AS DateTime2), 11, 4, 0, N'ScoreLimitedMatch', 51, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (158, CAST(N'2023-01-23T00:00:00.0000000' AS DateTime2), 11, 4, 0, N'ScoreLimitedMatch', 51, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (159, CAST(N'2023-01-23T00:00:00.0000000' AS DateTime2), 11, 4, 0, N'ScoreLimitedMatch', 51, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (160, CAST(N'2023-01-24T00:00:00.0000000' AS DateTime2), 11, 4, 0, N'ScoreLimitedMatch', 51, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (161, CAST(N'2023-01-24T00:00:00.0000000' AS DateTime2), 11, 4, 0, N'ScoreLimitedMatch', 51, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (162, CAST(N'2023-01-24T00:00:00.0000000' AS DateTime2), 11, 4, 0, N'ScoreLimitedMatch', 51, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (163, CAST(N'2023-01-26T00:00:00.0000000' AS DateTime2), 11, 4, 0, N'ScoreLimitedMatch', 51, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (164, CAST(N'2023-01-26T00:00:00.0000000' AS DateTime2), 11, 4, 0, N'ScoreLimitedMatch', 51, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (165, CAST(N'2023-01-26T00:00:00.0000000' AS DateTime2), 11, 4, 0, N'ScoreLimitedMatch', 51, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (166, CAST(N'2023-01-27T00:00:00.0000000' AS DateTime2), 11, 4, 0, N'ScoreLimitedMatch', 51, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (167, CAST(N'2023-01-27T00:00:00.0000000' AS DateTime2), 11, 4, 0, N'ScoreLimitedMatch', 51, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (168, CAST(N'2023-01-27T00:00:00.0000000' AS DateTime2), 11, 4, 0, N'ScoreLimitedMatch', 51, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (169, CAST(N'2023-01-28T00:00:00.0000000' AS DateTime2), 11, 4, 0, N'ScoreLimitedMatch', 51, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (170, CAST(N'2023-01-28T00:00:00.0000000' AS DateTime2), 11, 4, 0, N'ScoreLimitedMatch', 51, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (171, CAST(N'2023-01-28T00:00:00.0000000' AS DateTime2), 11, 4, 0, N'ScoreLimitedMatch', 51, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (172, CAST(N'2023-01-29T00:00:00.0000000' AS DateTime2), 11, 4, 0, N'ScoreLimitedMatch', 51, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (173, CAST(N'2023-01-29T00:00:00.0000000' AS DateTime2), 11, 4, 0, N'ScoreLimitedMatch', 51, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (174, CAST(N'2023-01-29T00:00:00.0000000' AS DateTime2), 11, 4, 0, N'ScoreLimitedMatch', 51, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (175, CAST(N'2023-01-30T00:00:00.0000000' AS DateTime2), 11, 4, 0, N'ScoreLimitedMatch', 51, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (176, CAST(N'2023-01-30T00:00:00.0000000' AS DateTime2), 11, 4, 0, N'ScoreLimitedMatch', 51, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (177, CAST(N'2023-01-30T00:00:00.0000000' AS DateTime2), 11, 4, 0, N'ScoreLimitedMatch', 51, NULL, NULL)
GO
INSERT [dbo].[Matches] ([MatchId], [Date], [EventId], [LocationId], [IsDeleted], [Discriminator], [MatchScoreLimit], [PlayerTimeLimit], [MatchTimeLimit]) VALUES (178, CAST(N'2023-04-01T00:00:00.0000000' AS DateTime2), 13, 2, 0, N'TimeLimitedMatch', NULL, 0, 60)
GO
SET IDENTITY_INSERT [dbo].[Matches] OFF
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (2, 1, 1, 0)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (2, 2, 5, 0)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (4, 2, 1, 0)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (10, 2, 0, 0)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (2, 3, 3, 0)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (7, 3, 4, 0)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (2, 4, 2, 0)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (6, 4, 1, 0)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (10, 4, 0, 0)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (2, 5, 6, 0)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (4, 5, 2, 0)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (7, 5, 1, 0)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (10, 5, 0, 0)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (2, 6, 4, 0)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (10, 6, 0, 0)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (4, 7, 4, 0)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (7, 7, 3, 0)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (10, 7, 0, 0)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (10, 8, 0, 0)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (4, 9, 3, 0)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (10, 9, 0, 0)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (6, 10, 2, 0)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (7, 10, 2, 0)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (10, 10, 0, 0)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (8, 11, 0, 0)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (9, 11, 0, 0)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (11, 11, 0, 0)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (3, 12, 0, 1)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (8, 12, 0, 0)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (5, 13, 0, 1)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (8, 13, 0, 0)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (8, 14, 0, 0)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (5, 15, 1, 0)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (8, 15, 0, 0)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (5, 16, 0, 1)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (8, 16, 0, 0)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (9, 16, 0, 0)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (11, 16, 0, 0)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (3, 17, 0, 1)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (8, 17, 0, 0)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (3, 18, 1, 0)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (5, 18, 0, 1)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (8, 18, 0, 0)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (5, 19, 0, 1)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (3, 20, 0, 1)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (5, 20, 0, 1)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (9, 21, 0, 0)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (11, 21, 0, 0)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (13, 21, 0, 0)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (3, 22, 0, 1)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (11, 23, 0, 0)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (3, 24, 0, 1)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (5, 24, 0, 1)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (3, 25, 2, 0)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (5, 26, 0, 1)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (9, 26, 0, 0)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (3, 27, 0, 1)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (5, 27, 0, 1)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (11, 28, 0, 0)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (5, 29, 0, 1)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (9, 29, 0, 0)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (5, 31, 0, 1)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (11, 31, 0, 0)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (5, 32, 2, 0)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (13, 32, 0, 0)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (5, 33, 0, 1)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (5, 34, 0, 1)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (5, 39, 0, 1)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (9, 40, 0, 0)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (9, 41, 0, 0)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (5, 44, 0, 1)
GO
INSERT [dbo].[Rankings] ([EventId], [PlayerId], [Rank], [IsDeleted]) VALUES (9, 50, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (1, 1, 1, 3, 2, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (1, 3, 1, 2, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (2, 2, 1, 1, 1, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (2, 5, 1, 1, 1, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (3, 4, 1, 2, 2, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (3, 6, 1, 1, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (4, 1, 2, 3, 2, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (4, 4, 2, 1, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (5, 2, 2, 2, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (5, 6, 2, 3, 2, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (6, 3, 2, 2, 1, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (6, 5, 2, 2, 1, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (7, 1, 3, 6, 2, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (7, 6, 3, 1, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (8, 2, 3, 1, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (8, 3, 3, 3, 2, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (9, 4, 3, 1, 1, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (9, 5, 3, 1, 1, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (10, 1, 4, 3, 2, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (10, 2, 4, 1, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (11, 3, 4, 2, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (11, 4, 4, 3, 2, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (12, 5, 4, 1, 1, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (12, 6, 4, 1, 1, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (13, 1, 5, 3, 2, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (13, 5, 5, 1, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (14, 2, 5, 2, 1, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (14, 4, 5, 2, 1, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (15, 3, 5, 3, 2, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (15, 6, 5, 2, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (16, 3, 6, 1, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (16, 4, 6, 3, 2, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (17, 1, 6, 4, 2, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (17, 5, 6, 3, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (18, 2, 6, 1, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (18, 6, 6, 2, 2, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (19, 1, 7, 1, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (19, 2, 7, 2, 2, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (20, 4, 7, 1, 1, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (20, 5, 7, 1, 1, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (21, 3, 7, 3, 2, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (21, 6, 7, 2, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (22, 2, 8, 1, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (22, 4, 8, 2, 2, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (23, 3, 8, 3, 2, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (23, 5, 8, 2, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (24, 1, 8, 4, 2, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (24, 6, 8, 2, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (25, 2, 9, 1, 1, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (25, 3, 9, 1, 1, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (26, 1, 9, 2, 2, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (26, 4, 9, 1, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (27, 5, 9, 1, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (27, 6, 9, 2, 2, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (28, 1, 10, 6, 2, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (28, 3, 10, 1, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (29, 2, 10, 5, 2, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (29, 5, 10, 2, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (30, 4, 10, 3, 1, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (30, 6, 10, 3, 1, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (31, 18, 0, 2, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (31, 20, 0, 1, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (32, 17, 0, 1, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (32, 24, 0, 3, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (33, 12, 0, 1, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (33, 25, 0, 2, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (34, 22, 0, 4, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (34, 27, 0, 1, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (35, 18, 0, 3, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (35, 24, 0, 1, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (36, 22, 0, 2, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (36, 25, 0, 3, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (37, 18, 0, 3, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (37, 25, 0, 0, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (38, 2, 1, 9, 2, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (38, 9, 1, 1, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (39, 5, 1, 9, 2, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (39, 7, 1, 7, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (40, 2, 2, 9, 2, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (40, 5, 2, 5, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (41, 7, 2, 9, 2, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (41, 9, 2, 6, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (42, 2, 3, 9, 2, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (42, 7, 3, 4, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (43, 5, 3, 6, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (43, 9, 3, 9, 2, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (44, 5, 4, 9, 2, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (44, 7, 4, 2, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (45, 2, 4, 9, 2, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (45, 9, 4, 5, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (46, 2, 5, 9, 2, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (46, 5, 5, 0, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (47, 7, 5, 3, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (47, 9, 5, 9, 2, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (48, 2, 6, 9, 2, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (48, 7, 6, 4, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (49, 5, 6, 9, 2, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (49, 9, 6, 6, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (50, 13, 0, 3, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (50, 31, 0, 2, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (51, 18, 0, 6, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (51, 27, 0, 1, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (52, 20, 0, 2, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (52, 44, 0, 3, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (53, 32, 0, 4, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (53, 33, 0, 2, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (54, 24, 0, 5, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (54, 29, 0, 2, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (55, 16, 0, 1, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (55, 39, 0, 3, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (56, 15, 0, 4, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (56, 26, 0, 2, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (57, 19, 0, 1, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (57, 34, 0, 3, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (58, 13, 0, 1, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (58, 18, 0, 2, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (59, 32, 0, 3, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (59, 44, 0, 1, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (60, 24, 0, 1, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (60, 39, 0, 4, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (61, 15, 0, 3, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (61, 34, 0, 2, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (62, 18, 0, 2, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (62, 32, 0, 3, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (63, 15, 0, 4, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (63, 39, 0, 1, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (64, 15, 0, 2, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (64, 32, 0, 0, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (65, 4, 1, 3, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (65, 10, 1, 1, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (66, 3, 1, 3, 2, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (66, 5, 1, 2, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (67, 7, 1, 2, 1, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (67, 10, 1, 2, 1, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (68, 3, 2, 1, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (68, 7, 2, 4, 2, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (69, 5, 2, 6, 2, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (69, 10, 2, 2, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (70, 3, 3, 1, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (70, 10, 3, 3, 2, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (71, 5, 3, 2, 1, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (71, 7, 3, 2, 1, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (72, 3, 4, 2, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (72, 5, 4, 3, 2, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (73, 7, 4, 1, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (73, 10, 4, 4, 2, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (74, 3, 5, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (74, 7, 5, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (75, 5, 5, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (75, 10, 5, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (76, 5, 6, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (76, 7, 6, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (77, 3, 6, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (77, 10, 6, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (78, 16, 0, 3, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (78, 17, 0, 2, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (79, 11, 0, 1, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (79, 13, 0, 2, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (80, 12, 0, 3, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (80, 15, 0, 2, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (81, 14, 0, 4, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (81, 18, 0, 0, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (82, 13, 0, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (82, 16, 0, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (83, 12, 0, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (83, 14, 0, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (85, 11, 1, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (85, 40, 1, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (86, 16, 1, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (86, 29, 1, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (87, 21, 1, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (87, 50, 1, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (88, 26, 1, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (88, 41, 1, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (89, 11, 2, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (89, 26, 2, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (90, 16, 2, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (90, 50, 2, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (91, 21, 2, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (91, 29, 2, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (92, 40, 2, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (92, 41, 2, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (93, 11, 3, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (93, 29, 3, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (94, 16, 3, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (94, 40, 3, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (95, 21, 3, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (95, 26, 3, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (96, 41, 3, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (96, 50, 3, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (97, 11, 4, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (97, 21, 4, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (98, 16, 4, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (98, 41, 4, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (99, 26, 4, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (99, 50, 4, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (100, 29, 4, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (100, 40, 4, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (101, 11, 5, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (101, 16, 5, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (102, 21, 5, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (102, 41, 5, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (103, 26, 5, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (103, 29, 5, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (104, 40, 5, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (104, 50, 5, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (105, 11, 6, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (105, 41, 6, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (106, 16, 6, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (106, 21, 6, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (107, 26, 6, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (107, 40, 6, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (108, 29, 6, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (108, 50, 6, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (109, 11, 7, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (109, 50, 7, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (110, 16, 7, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (110, 26, 7, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (111, 21, 7, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (111, 40, 7, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (112, 29, 7, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (112, 41, 7, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (113, 16, 8, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (113, 26, 8, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (114, 21, 8, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (114, 29, 8, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (115, 11, 8, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (115, 41, 8, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (116, 40, 8, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (116, 50, 8, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (117, 16, 9, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (117, 21, 9, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (118, 26, 9, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (118, 40, 9, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (119, 29, 9, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (119, 41, 9, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (120, 11, 9, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (120, 50, 9, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (121, 11, 10, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (121, 16, 10, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (122, 21, 10, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (122, 40, 10, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (123, 26, 10, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (123, 41, 10, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (124, 29, 10, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (124, 50, 10, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (125, 11, 11, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (125, 26, 11, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (126, 16, 11, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (126, 29, 11, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (127, 40, 11, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (127, 41, 11, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (128, 21, 11, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (128, 50, 11, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (129, 11, 12, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (129, 21, 12, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (130, 29, 12, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (130, 40, 12, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (131, 16, 12, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (131, 41, 12, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (132, 26, 12, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (132, 50, 12, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (133, 26, 13, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (133, 29, 13, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (134, 11, 13, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (134, 40, 13, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (135, 21, 13, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (135, 41, 13, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (136, 16, 13, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (136, 50, 13, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (137, 21, 14, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (137, 26, 14, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (138, 11, 14, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (138, 29, 14, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (139, 16, 14, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (139, 40, 14, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (140, 41, 14, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (140, 50, 14, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (141, 6, 0, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (141, 8, 0, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (142, 5, 0, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (142, 7, 0, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (143, 2, 0, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (143, 4, 0, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (144, 9, 0, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (144, 10, 0, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (148, 11, 1, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (148, 16, 1, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (149, 21, 1, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (149, 28, 1, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (150, 23, 1, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (150, 31, 1, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (151, 11, 2, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (151, 28, 2, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (152, 16, 2, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (152, 31, 2, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (153, 21, 2, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (153, 23, 2, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (154, 11, 3, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (154, 21, 3, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (155, 16, 3, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (155, 23, 3, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (156, 28, 3, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (156, 31, 3, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (157, 11, 4, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (157, 31, 4, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (158, 16, 4, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (158, 21, 4, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (159, 23, 4, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (159, 28, 4, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (160, 11, 5, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (160, 23, 5, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (161, 16, 5, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (161, 28, 5, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (162, 21, 5, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (162, 31, 5, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (163, 16, 6, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (163, 21, 6, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (164, 11, 6, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (164, 28, 6, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (165, 23, 6, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (165, 31, 6, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (166, 16, 7, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (166, 23, 7, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (167, 21, 7, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (167, 28, 7, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (168, 11, 7, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (168, 31, 7, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (169, 11, 8, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (169, 21, 8, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (170, 23, 8, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (170, 28, 8, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (171, 16, 8, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (171, 31, 8, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (172, 11, 9, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (172, 16, 9, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (173, 21, 9, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (173, 23, 9, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (174, 28, 9, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (174, 31, 9, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (175, 11, 10, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (175, 23, 10, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (176, 16, 10, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (176, 28, 10, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (177, 21, 10, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (177, 31, 10, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (178, 21, 1, NULL, 0, 0)
GO
INSERT [dbo].[Scores] ([MatchId], [PlayerId], [Round], [PlayerScore], [ScoredPoints], [IsDeleted]) VALUES (178, 32, 1, NULL, 0, 0)
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221201112901_Initial', N'5.0.17')
GO
