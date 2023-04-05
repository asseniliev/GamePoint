using MatchScore.Data.Constants;
using MatchScore.Data.Enums;
using MatchScore.Data.Helpers;
using MatchScore.Data.Models;
using MatchScore.Data.Models.QueryParameters;
using MatchScore.Data.Repositories.Contracts;
using MatchScore.Exceptions;
using MatchScore.Services.Helpers;
using MatchScore.Services.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MatchScore.Services.Services
{
    public class EventsService : IEventsService
    {

        #region State

        private readonly IEventsRepository eventsRepository;
        private readonly IRankingsService rankingService;
        private readonly IScoreService scoreService;
        private readonly IMatchesService matchesService;
        private readonly IPlayersService playersService;
        private readonly IAwardsService awardsService;

        public EventsService(IEventsRepository eventsRepository, 
                            IRankingsService rankingService, 
                            IScoreService scoreService, 
                            IMatchesService matchesService,
                            IPlayersService playersService,
                            IAwardsService awardsService)
        {
            this.eventsRepository = eventsRepository;
            this.rankingService = rankingService;
            this.scoreService = scoreService;
            this.matchesService = matchesService;
            this.playersService = playersService;
            this.awardsService = awardsService;
        }

        #endregion

        #region Get Methods
        public List<Event> GetAll()
        {
            return this.eventsRepository.GetAll();
        }

        public Event GetById(int eventId)
        {
            return this.eventsRepository.GetById(eventId);
        }

        public Event GetByTitle(string title)
        {
            return this.eventsRepository.GetByTitle(title);
        }

        public PaginatedList<Event> FilterBy(EventQueryParameters parameters)
        {
            return this.eventsRepository.FilterBy(parameters);
        }

        public static Match GetNextPlayersMatch(Match match, List<Match> eventMatches)
        {
            Event @event = match.Event;

            @event.Matches = @event.Matches.Where(m => !m.IsDeleted).ToList();

            int numberOfPlayers = @event.Ranking.Where(r => r.EventId == @event.EventId).Count();
            int matchIndex = eventMatches.IndexOf(match);

            int nextMatchIndex = (matchIndex + numberOfPlayers) / 2;

            return eventMatches[nextMatchIndex];
        }

        public List<Event> GetLatestEvents()
        {
            var now = DateTime.Now;
            var events = this.eventsRepository.GetAll()
                .Where(m => m.EndDate < now)
                .OrderByDescending(m => m.EndDate)
                .Take(5)
                .ToList();
            return events;
        }

        public List<Event> GetFutureEvents()
        {
            var now = DateTime.Now;
            var events = this.eventsRepository.GetAll()
                .Where(m => m.StartDate > now)
                .OrderBy(m => m.StartDate)
                .Take(5)
                .ToList();
            return events;
        }

        #endregion

        #region CUD Methods

        public Event Create(Event eventToCreate, User user)
        {
            AuthorizationHelper.AdminOrDirector(user);
            AuthorizationHelper.Active(user);

            return this.eventsRepository.Create(eventToCreate);
        }

        public void Update(Event eventUpdates, User user)
        {
            AuthorizationHelper.AdminOrDirector(user);
            AuthorizationHelper.Active(user);

            Event eventToUpdate = this.eventsRepository.GetById(eventUpdates.EventId);

            eventToUpdate.Title = eventUpdates.Title;
            eventToUpdate.StartDate = eventUpdates.StartDate;
            eventToUpdate.EndDate = eventUpdates.EndDate;
            eventToUpdate.IsCompleted = eventUpdates.IsCompleted; 

            this.eventsRepository.Update(eventUpdates);
            this.eventsRepository.SaveDatabase();

        }

        public void Delete(int eventId, User user)
        {
            AuthorizationHelper.AdminOrDirector(user);
            AuthorizationHelper.Active(user);

            Event eventToDelete = this.eventsRepository.GetById(eventId);

            if (this.DependentScoresExist(eventToDelete.Matches))
            {
                throw new DeleteConnectedEntityException(string.Format(Messages.DeleteConnectedEntityError, "Event"));
            }

            SuppressMatchScheme(eventId, user);

            //Delete Awards
            this.awardsService.Delete(this.awardsService.GetByEventId(eventId));

            //Delete Ranking
            this.rankingService.Delete(this.rankingService.GetByIDs(eventId));

            //Delete Awards
            this.awardsService.Delete(this.awardsService.GetByEventId(eventId));

            eventToDelete.IsDeleted = true;
            this.eventsRepository.Update(eventToDelete);
            this.eventsRepository.SaveDatabase();
        }

        #endregion

        #region Event Management Methods

        public void AddPlayer(int eventId, Player player, User user)
        {
            AuthorizationHelper.AdminOrDirector(user);
            AuthorizationHelper.Active(user);

            Event @event = this.eventsRepository.GetById(eventId);

            Ranking ranking = new Ranking()
            {
                PlayerId = player.PlayerId,
                Player = player,
                EventId = @event.EventId,
                Event = @event
            };

            this.rankingService.Create(ranking);
        }

        public void RemovePlayer(int eventId, Player player, User user)
        {
            AuthorizationHelper.AdminOrDirector(user);
            AuthorizationHelper.Active(user);

            Event @event = this.eventsRepository.GetById(eventId);
            if (!this.rankingService.GetAll().Exists(r => r.EventId == eventId && r.PlayerId == player.PlayerId))
            {
                throw new EntityNotFoundException(string.Format(Messages.ItemNotAssigned, "Player", player.Name, "event with title", @event.Title));
            }

            if (@event.Matches.Count != 0)   //i.e. if matches are generated, then players are assigned and cannot be removed anymore
            {
                throw new DeleteConnectedEntityException(string.Format(Messages.DeleteConnectedEntityError, "Player"));
            }
        }

        public void GenerateMatchScheme(int eventId, User user)
        {
            AuthorizationHelper.AdminOrDirector(user);
            AuthorizationHelper.Active(user);

            Event @event = this.eventsRepository.GetById(eventId);

            switch (@event.EventType)
            {
                case (EventTypes.SingleMatch):
                    this.GenerateSingleMatchScheme(eventId, @event.matchType, @event.MatchLimitValue, user);
                    break;
                case (EventTypes.League):
                    this.GenerateLeagueMatchScheme(eventId, @event.matchType, @event.MatchLimitValue, user);
                    break;
                case (EventTypes.Knockout):
                    this.GenerateKnowckOutMatchScheme(eventId, @event.matchType, @event.MatchLimitValue, user);
                    break;
            }

        }

        public void SuppressMatchScheme(int eventId, User user)
        {
            AuthorizationHelper.AdminOrDirector(user);
            AuthorizationHelper.Active(user);

            Event @event = this.eventsRepository.GetById(eventId);
            List<Match> eventMatches = @event.Matches.Where(m => !m.IsDeleted).ToList();
            List<Score> scoresToDelete = new List<Score>();

            foreach (var match in eventMatches)
            {
                if (this.DependentScoresExist(@event.Matches))
                {
                    throw new DeleteConnectedEntityException(string.Format(Messages.DeleteConnectedEntityError, "Matches in the match scheme"));
                }
                else
                {
                    scoresToDelete.AddRange(this.scoreService.GetByMatchId(match.MatchId));
                }
            }

            this.matchesService.Delete(eventMatches);
            this.scoreService.Delete(scoresToDelete);

            @event.Matches.Clear();
        }

        public Player DetermineChampion(int eventId)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Private Methods

        private bool DependentScoresExist(List<Match> matches)
        {
            foreach (var match in matches)
            {
                if (this.scoreService.GetByMatchId(match.MatchId).Any(s => s.PlayerScore != null))
                {
                    return true;
                }
            }

            return false;
        }

        private bool DependentRankingExists(int eventId)
        {
            if (this.rankingService.GetAll().ToList().Exists(r => r.EventId == eventId))
            {
                return true;
            }

            return false;
        }

        private void GenerateSingleMatchScheme(int eventId, MatchTypes matchType, int matchLimitValue, User user)
        {
            List<Player> players =
                this.rankingService.GetAll().Where(r => r.EventId == eventId).Select(r => this.playersService.GetById(r.PlayerId)).ToList();

            Event @event = this.eventsRepository.GetById(eventId);
            if (players.Count != 2)
            {
                throw new InvalidOperationException(string.Format(Messages.PlayersNotProperlyAssigned, "exactly", 2));
            }

            Match match = this.CreateMatch(@event, matchType, matchLimitValue, user);
            this.AddScoreTable(match, players, 1);
        }

        private void GenerateLeagueMatchScheme(int eventId, MatchTypes matchType, int matchLimitValue, User user)
        {
            List<Player> players =
                this.rankingService.GetAll().Where(r => r.EventId == eventId).Select(r => this.playersService.GetById(r.PlayerId)).ToList();

            Event @event = this.eventsRepository.GetById(eventId);
            if (players.Count < 4)
            {
                throw new InvalidOperationException(string.Format(Messages.PlayersNotProperlyAssigned, "minimum", 4));
            }

            int numberOfMatchesPerRound = players.Count / 2;
            int currentRound = 1;


            List<string> roundScheme = this.GenerateRounds(players.Count());
            //Each line in the 'roundScheme' list represents a separate round.
            //It contains a permutation of the players' indices; each pair represents a match and
            //the numbers in that pair represents the indeces of the payers that participate in that match. 
            //For example 142530:
            //This line represents three matches: the first match is for players with indeces 1 and 4,
            //the second is for players with indeces 2 and 5 and the third - for players 3 and 0.
            //The players' entities are fetched from the 'players' list defined above

            foreach (var round in roundScheme)
            {
                for (int i = 0; i < round.Length; i+=2)
                {
                    Match match = this.CreateMatch(@event, matchType, matchLimitValue, user);
                    int player1Index = (int.Parse(round[i].ToString()) - 1);
                    int player2Index = (int.Parse(round[i+1].ToString()) - 1);
                    List<Player> matchPlayers = this.GetParticipants(players, player1Index, player2Index);
                    this.AddScoreTable(match, matchPlayers, currentRound);
                }
                currentRound++;
            }

            //for (int player1Index = 0; player1Index < (numberOfPlayers - 1); player1Index++)
            //{
            //    for (int player2Index = player1Index + 1; player2Index < numberOfPlayers; player2Index++)
            //    {
            //        //Two matches are created for each pair of players in a league
            //        Match match = this.CreateMatch(@event, matchType, matchLimitValue, user);
            //        List<Player> matchPlayers = this.GetParticipants(players, player1Index, player2Index);
            //        this.AddScoreTable(match, matchPlayers);

            //        match = this.CreateMatch(@event, matchType, matchLimitValue, user);
            //        matchPlayers = this.GetParticipants(players, player2Index, player1Index);
            //        this.AddScoreTable(match, matchPlayers);
            //    }
            //}
        }

        private void GenerateKnowckOutMatchScheme(int eventId, MatchTypes matchType, int matchLimitValue, User user)
        {
            List<Player> players =
                this.rankingService.GetAll().Where(r => r.EventId == eventId).Select(r => this.playersService.GetById(r.PlayerId)).ToList();

            Event @event = this.eventsRepository.GetById(eventId);
            if (Math.Log2(players.Count) % 1 != 0 || players.Count < 4)
            {
                throw new InvalidOperationException(string.Format(Messages.PlayersNotProperlyAssigned, "4 or 8 or 16...", "or any other power of 2 "));
            }

            players = this.RandomizeList(players);

            Player player = new Player();
            Score score = new Score();
            score.Round = 0;

            //Create matches for the first round
            for (int i = 0; i < (players.Count / 2); i++)
            {
                Match match = CreateMatch(@event, matchType, matchLimitValue, user);
                score.MatchId = match.MatchId;

                player = players[2 * i];
                score.PlayerId = player.PlayerId;                
                this.scoreService.Create(score);

                player = players[2 * i + 1];
                score.PlayerId = player.PlayerId;
                this.scoreService.Create(score);
            }

            //Create the rest of the matches
            for (int i = (players.Count / 2); i < (players.Count - 1); i++)
            {
                Match match = CreateMatch(@event, matchType, matchLimitValue, user);
            }
        }

        private void AddScoreTable(Match match, List<Player> players, int round)
        {
            foreach (var player in players)
            {
                Score score = new Score()
                {
                    MatchId = match.MatchId,
                    PlayerId = player.PlayerId,
                    Round = round,
                    PlayerScore = null
                };
                this.scoreService.Create(score);
            }
        }

        private Match CreateMatch(Event @event, MatchTypes matchType, int matchLimitValue, User user)
        {
            Match match;
            switch (matchType)
            {
                case MatchTypes.ScoreLimited:
                    {
                        match = new ScoreLimitedMatch()
                        {
                            MatchScoreLimit = matchLimitValue
                        };
                        break;
                    }
                case MatchTypes.TimeLimited:
                    {
                        match = new TimeLimitedMatch()
                        {
                            MatchTimeLimit = matchLimitValue
                        };
                        break;
                    };
                default:
                    match = null;
                    break;
            }
            match.Date = @event.StartDate;
            match.EventId = @event.EventId;
            match.LocationId = @event.LocationId;
            return this.matchesService.Create(match);
        }

        private List<Player> GetParticipants(List<Player> playersList, int player1Index, int player2Index)
        {
            List<Player> participants = new List<Player>();
            participants.Add(playersList[player1Index]);
            participants.Add(playersList[player2Index]);

            return participants;
        }

        private List<Player> RandomizeList(List<Player> players)
        {
            List<Player> temp = new List<Player>(players);
            List<Player> randomizedList = new List<Player>(players.Count);
            while (temp.Count > 2)
            {
                int randomIndex = new Random().Next(0, temp.Count);
                randomizedList.Add(temp[randomIndex]);
                temp.RemoveAt(randomIndex);
            }
            temp.ForEach(t => randomizedList.Add(t));

            return randomizedList;
        }

        private List<string> GenerateRounds(int numberOfPlayers)
        {
            List<int> playersIndex = new List<int>();
            for (int i = 1; i <= numberOfPlayers; i++)
            {
                playersIndex.Add(i);
            }

            List<string> permutations = new List<string>();
            List<int> uniquePairs = new List<int>();

            //If we have n players then the number of rounds in (n - 1) * 2 as
            //each player must play with (n - 1) players twice


            //Winter season: we want each player to meet each other player once
            while (permutations.Count < (numberOfPlayers - 1))
            {
                string numString = "";
                Random rnd = new Random();
                int num1, num2, randomIndex;
                List<int> wip = new List<int>(playersIndex);
                List<int> pairs = new List<int>();

                bool hasRepetion = false;

                while (wip.Count > 0)
                {
                    randomIndex = rnd.Next(0, wip.Count);
                    num1 = wip[randomIndex];
                    wip.RemoveAt(randomIndex);

                    randomIndex = rnd.Next(0, wip.Count);
                    num2 = wip[randomIndex];
                    wip.RemoveAt(randomIndex);

                    if (num1 > num2)
                    {
                        int temp = num1;
                        num1 = num2;
                        num2 = temp;
                    }

                    pairs.Add(num1 * 10 + num2);
                }

                pairs.Sort();

                foreach (var pair in pairs)
                {
                    if (uniquePairs.Contains(pair))
                    {
                        hasRepetion = true;
                        continue;
                    }
                }

                if (hasRepetion) continue;

                foreach (var pair in pairs)
                {
                    uniquePairs.Add(pair);
                    numString += pair.ToString();
                }

                if (!permutations.Contains(numString))
                    permutations.Add(numString);
            }

            uniquePairs.Clear();

            //Summer season: we want each player to meet each other player once
            while (permutations.Count < (numberOfPlayers - 1) * 2)
            {
                string numString = "";
                Random rnd = new Random();
                int num1, num2, randomIndex;
                List<int> wip = new List<int>(playersIndex);
                List<int> pairs = new List<int>();

                bool hasRepetion = false;

                while (wip.Count > 0)
                {
                    randomIndex = rnd.Next(0, wip.Count);
                    num1 = wip[randomIndex];
                    wip.RemoveAt(randomIndex);

                    randomIndex = rnd.Next(0, wip.Count);
                    num2 = wip[randomIndex];
                    wip.RemoveAt(randomIndex);

                    if (num1 < num2)
                    {
                        int temp = num1;
                        num1 = num2;
                        num2 = temp;
                    }

                    pairs.Add(num1 * 10 + num2);
                }

                pairs.Sort();

                foreach (var pair in pairs)
                {
                    if (uniquePairs.Contains(pair))
                    {
                        hasRepetion = true;
                        continue;
                    }
                }

                if (hasRepetion) continue;

                foreach (var pair in pairs)
                {
                    uniquePairs.Add(pair);
                    numString += pair.ToString();
                }

                if (!permutations.Contains(numString))
                    permutations.Add(numString);
            }

            return permutations;
        }

        #endregion

    }


}
