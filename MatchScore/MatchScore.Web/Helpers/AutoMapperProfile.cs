using AutoMapper;
using EnumsNET;
using MatchScore.Data.Enums;
using MatchScore.Data.Models;
using MatchScore.Web.DTOs.MatchDTOs;
using MatchScore.Web.DTOs.ScoreDTOs;
using MatchScore.Web.DTOs.EventDTOs;
using MatchScore.Web.DTOs.UserDTOs;
using MatchScore.Web.ViewModels.EventViewModels;
using MatchScore.Web.ViewModels.LocationViewModels;
using MatchScore.Web.ViewModels.MatchViewModels;
using MatchScore.Web.ViewModels.PlayerViewModels;
using MatchScore.Web.ViewModels.RankViewModels;
using MatchScore.Web.ViewModels.RequestViewModels;
using MatchScore.Web.ViewModels.SportsClubViewModels;
using MatchScore.Web.ViewModels.UserViewModels;
using Microsoft.OpenApi.Writers;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using MatchScore.Web.DTOs.RequestDTOs;

namespace MatchScore.Web.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Users
            CreateMap<UserPostDto, User>();
            CreateMap<UserPutDto, User>();
            CreateMap<User, UserGetDto>();

            CreateMap<UserRegisterVM, User>().ReverseMap();
            CreateMap<User, UserIndexVM>()
                .ForMember(dest => dest.PlayerName, opts => opts.MapFrom(src => src.Player.Name));
            CreateMap<User, UserDetailsVM>()
                .ForMember(dest => dest.PlayerName,
                opts => opts.MapFrom(src => src.Player.Name))
                .ForMember(dest => dest.Events,
                opts => opts.MapFrom(src => src.Events));
            CreateMap<User, UserEditVM>()
                .ForMember(dest => dest.PlayerId, opts => opts.MapFrom(src => src.PlayerId))
                .ForMember(dest => dest.PlayerName, opts => opts.MapFrom(src => src.Player.Name))
                .ForMember(dest => dest.IsInactive, opts => opts.MapFrom(src => src.IsInactive))
                .ForMember(dest => dest.IsDeleted, opts => opts.MapFrom(src => src.IsDeleted));
            CreateMap<UserEditVM, User>();

            // Requests
            CreateMap<RequestPostDto, Request>();
            CreateMap<RequestPutDto, Request>();
            CreateMap<Request, RequestGetDto>();

            CreateMap<RequestCreateVM, Request>();
            CreateMap<Request, RequestIndexVM>()
                .ForMember(dest => dest.Username, opts => opts.MapFrom(src => src.User.Username))
                .ForMember(dest => dest.PlayerName, opts => opts.MapFrom(src => src.Player.Name));

            // Players
            CreateMap<Player, PlayerCreateVM>().ReverseMap()
                .ForMember(dest => dest.Photo, opt => opt.Ignore());
            CreateMap<PlayerDeleteVM, Player>().ReverseMap();
            CreateMap<Player, PlayerDetailsVM>()
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country == null ? null : ((Countries)src.Country).AsString(EnumFormat.Description)))
                .ForMember(dest => dest.Events, opt => opt.MapFrom(src => src.Rankings.Select(r => r.Event)))
                .ForMember(dest => dest.Matches, opt => opt.MapFrom(src => src.Scores.Select(s => s.Match)))
                .ForMember(dest => dest.Wins, opt => opt.MapFrom(src => src.Scores.Where(s => IsWin(s, src.PlayerId)).Count()))
                .ForMember(dest => dest.Draws, opt => opt.MapFrom(src => src.Scores.Where(s => IsDraw(s, src.PlayerId)).Count()))
                .ForMember(dest => dest.Losses, opt => opt.MapFrom(src => src.Scores.Where(s => IsLoss(s, src.PlayerId)).Count()))
                .ForMember(dest => dest.MostPlayedOpponent, opt => opt.MapFrom(src => MostPlayedOpponent(src.Scores, src)))
                .ForMember(dest => dest.BestOpponent, opt => opt.MapFrom(src => MostPlayedOpponent((src.Scores.Where(s => IsWin(s, src.PlayerId)).ToList()), src)))
                .ForMember(dest => dest.WorstOpponent, opt => opt.MapFrom(src => MostPlayedOpponent((src.Scores.Where(s => IsLoss(s, src.PlayerId)).ToList()), src)));
            CreateMap<Player, PlayerEditVM>()
            .ForMember(dest => dest.Photo, opt => opt.Ignore());
            CreateMap<PlayerEditVM, Player>()
                .ForMember(dest => dest.Photo, opt => opt.Ignore());
            CreateMap<PlayerShortVM, Player>().ReverseMap()
                .ForMember(dest => dest.MatchesPlayed, opt => opt.MapFrom(src => src.Scores.Count))
                .ForMember(dest => dest.MatchesWon, opt => opt.MapFrom(src => src.Scores.Where(s => IsWin(s, src.PlayerId)).Count()));

            //Matches
            CreateMap<MatchDetailsVM, Match>().ReverseMap()
                .ForMember(dest => dest.Players, opt => opt.MapFrom(src => src.Scores.Where(s => !s.IsDeleted).Select(s => s.Player)))
                .ForMember(dest => dest.Scores, opt => opt.MapFrom(src => src.Scores.Select(s => s.PlayerScore)));
            CreateMap<MatchShortVM, Match>().ReverseMap()
                .ForMember(dest => dest.WinnerId, opt => opt.MapFrom(src => MatchWinnerId(src.Scores)))
                .ForMember(dest => dest.WinnerName, opt => opt.MapFrom(src => MatchWinnerName(src.Scores)))
                .ForMember(dest => dest.Players, opt => opt.MapFrom(src => src.Scores.Select(s => s.Player)))
                .ForMember(dest => dest.Round, opt => opt.MapFrom(src => src.Scores.FirstOrDefault() == null ? 0 : src.Scores.FirstOrDefault().Round));
            CreateMap<MatchPostDto, TimeLimitedMatch>().ReverseMap();
            CreateMap<MatchPostDto, ScoreLimitedMatch>().ReverseMap();
            CreateMap<MatchShortDto, Match>().ReverseMap();

            // Events
            CreateMap<EventPostDto, Event>();

            CreateMap<EventCreateVM, Event>();
            CreateMap<Event, EventEditVM>()
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Location.City));
            CreateMap<EventEditVM, Event>();
            CreateMap<LocationCreateVM, Location>();
            CreateMap<Event, EventShortVM>().ReverseMap();
            CreateMap<Event, EventLongVM>()
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Location.City))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Location.Country))
                .ForMember(dest => dest.Champion, opt => opt.MapFrom(src => src.Champion.Name))
                .ForMember(dest => dest.Director, opt => opt.MapFrom(src => src.Director.Username));
            CreateMap<Event, EventDetailsVM>()
                .ForMember(dest => dest.AwardsPrize, opt => opt.MapFrom(src => src.Awards.Select(a => a.Prize)));

            // Ranking
            CreateMap<Ranking, RankShortVM>();

            // SportsClubs
            CreateMap<SportsClubDetailsVM, SportsClub>().ReverseMap();

            //Scores
            CreateMap<ScoreDetailsDto, Score>().ReverseMap();
            CreateMap<ScoreCreateDto, Score>().ReverseMap();
        }

        #region Private Methods

        private static bool IsWin(Score s, int playerId)
        {
            var matchScores = s.Match.Scores.Where(s => s.PlayerScore != null).OrderByDescending(s => s.PlayerScore).ToList();
            if (matchScores.Count == 0)
            {
                return false;
            }
            var first = matchScores.First();
            var second = matchScores.ElementAt(1);
            return first.PlayerScore != second.PlayerScore && first.PlayerId == playerId;
        }

        private static bool IsDraw(Score s, int playerId)
        {
            var matchScores = s.Match.Scores.Where(s => s.PlayerScore != null).OrderByDescending(s => s.PlayerScore).ToList();
            if (matchScores.Count == 0)
            {
                return false;
            }
            var first = matchScores.First();
            var second = matchScores.ElementAt(1);
            return first.PlayerScore == second.PlayerScore && (first.PlayerId == playerId || second.PlayerId == playerId);
        }


        private static bool IsLoss(Score s, int playerId)
        {
            var matchScores = s.Match.Scores.Where(s => s.PlayerScore != null).OrderByDescending(s => s.PlayerScore).ToList();
            if (matchScores.Count == 0)
            {
                return false;
            }
            var first = matchScores.First();
            var second = matchScores.ElementAt(1);
            return first.PlayerScore != second.PlayerScore && first.PlayerId != playerId;
        }

        private static Player MostPlayedOpponent(List<Score> scores, Player player)
        {
            if (scores.Count == 0)
            {
                return null;
            }

            var opponents = new List<Player>();
            scores.ForEach(s => s.Match.Scores.Where(s => s.PlayerId != player.PlayerId).ToList().ForEach(s => opponents.Add(s.Player)));

            return opponents.GroupBy(i => i).OrderByDescending(grp => grp.Count()).Select(grp => grp.Key).FirstOrDefault();
        }

        private static int? MatchWinnerId(List<Score> scores)
        {
            var matchScores = scores.Where(s => s.PlayerScore != null).OrderByDescending(s => s.PlayerScore).ToList();
            if (matchScores.Count == 0)
            {
                return null;
            }
            var first = matchScores.First();
            var second = matchScores.ElementAt(1);
            if (first.PlayerScore != second.PlayerScore)
            {
                return first.PlayerId;
            }
            return null;
        }

        private static string MatchWinnerName(List<Score> scores)
        {
            var matchScores = scores.Where(s => s.PlayerScore != null).OrderByDescending(s => s.PlayerScore).ToList();
            if (matchScores.Count < 2)
            {
                return "";
            }
            var first = matchScores.First();
            var second = matchScores.ElementAt(1);
            if (first.PlayerScore != second.PlayerScore)
            {
                return first.Player.Name;
            }
            return "tie";
        }
        #endregion Private Methods
    }
}
