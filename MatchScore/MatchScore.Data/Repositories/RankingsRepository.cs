using MatchScore.Data.Data;
using MatchScore.Data.Models;
using MatchScore.Data.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MatchScore.Data.Repositories
{
    public class RankingsRepository : IRankingsRepository
    {
        private readonly ApplicationContext applicationContext;

        public RankingsRepository(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        public Ranking Create(Ranking rankingToCreate)
        {
            this.applicationContext.Rankings.Add(rankingToCreate);

            this.applicationContext.SaveChanges();

            Ranking createdRanking = this.GetByIDs(rankingToCreate.PlayerId, rankingToCreate.EventId);

            return createdRanking;
        }

        public List<Ranking> GetAll()
        {
            List<Ranking> allRankings = this.applicationContext.Rankings
                .Where(r => !r.IsDeleted)
                .ToList();

            return allRankings;
        }

        public List<Ranking> GetByIDs(int eventId)
        {
            return this.GetAll().Where(r => r.EventId == eventId).ToList();
        }

        public Ranking GetByIDs(int? playerId, int? eventId)
        {
            Ranking rankingToGet = this.GetAll()
                .Where(r => (r.PlayerId == playerId && r.EventId == eventId))
                .FirstOrDefault();

            return rankingToGet;
        }

        public Ranking GetByIdWithDeleted(int? playerId, int? eventId)
        {
            Ranking rankingToGet = this.applicationContext.Rankings
                .Where(r => (r.PlayerId == playerId && r.EventId == eventId))
                .FirstOrDefault();

            return rankingToGet;
        }

        public List<Ranking> GetByIdWithDeleted(int? eventId)
        {
            List<Ranking> rankingToGet = this.applicationContext.Rankings
                .Where(r => (r.EventId == eventId))
                .Include(r => r.Player)
                    .ThenInclude(p => p.SportsClub)
                .ToList();

            return rankingToGet;
        }


        public void Update(Ranking rankingToUpdate)
        {
            this.applicationContext.Rankings.Update(rankingToUpdate);
        }

        public void SaveDatabase()
        {
            this.applicationContext.SaveChanges();
        }


    }
}
