using MatchScore.Data.Models;
using MatchScore.Data.Repositories.Contracts;
using MatchScore.Services.Services.Contracts;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MatchScore.Services.Services
{
    public class RankingsService : IRankingsService
    {
        private readonly IRankingsRepository rankingsRepository;

        public RankingsService(IRankingsRepository rankingsRepository)
        {
            this.rankingsRepository = rankingsRepository;
        }

        public Ranking Create(Ranking rankingToCreate)
        {
            Ranking newRanking = new Ranking();
            try
            {
                newRanking = this.rankingsRepository.Create(rankingToCreate);
                this.rankingsRepository.SaveDatabase();
            }
            catch (DbUpdateException)
            {
                newRanking = this.rankingsRepository.GetByIdWithDeleted(rankingToCreate.PlayerId, rankingToCreate.EventId);
                newRanking.IsDeleted = false;
                this.rankingsRepository.Update(newRanking);
                this.rankingsRepository.SaveDatabase();
            }

            return newRanking;
        }

        public List<Ranking> GetAll()
        {
            List<Ranking> rankings = this.rankingsRepository.GetAll()
                .ToList();

            return rankings;
        }

        public List<Ranking> GetByIDs(int eventId)
        {
            return this.rankingsRepository.GetByIDs(eventId);
        }

        public Ranking Update(Ranking rankingUpdate)
        {
            Ranking rankingToUpdate = this.rankingsRepository.GetByIdWithDeleted(rankingUpdate.PlayerId, rankingUpdate.EventId);
            rankingToUpdate.Rank = rankingUpdate.Rank;
            rankingToUpdate.IsDeleted = rankingUpdate.IsDeleted;
            this.rankingsRepository.Update(rankingUpdate);
            this.rankingsRepository.SaveDatabase();
            return rankingToUpdate;
        }

        public Ranking GetByIDs(int playerId, int eventId)
        {
            Ranking rankingToGet = this.rankingsRepository.GetByIDs(playerId, eventId);

            return rankingToGet;
        }

        public List<Ranking> GetByIdWithDeleted(int eventId)
        {
            return this.rankingsRepository.GetByIdWithDeleted(eventId);
        }

        public void Delete(int playerId, int eventId)
        {
            Ranking rankingToDelete = this.rankingsRepository.GetByIDs(playerId, eventId);

            rankingToDelete.IsDeleted = true;

            this.rankingsRepository.Update(rankingToDelete);

            this.rankingsRepository.SaveDatabase();
        }

        public void Delete(List<Ranking> rankingsToDelete)
        {
            rankingsToDelete.ForEach(r => r.IsDeleted = true);

            rankingsToDelete.ForEach(r => this.rankingsRepository.Update(r));

            this.rankingsRepository.SaveDatabase();
        }
    }
}
