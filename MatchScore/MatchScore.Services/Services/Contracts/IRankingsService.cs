using MatchScore.Data.Models;
using System.Collections.Generic;

namespace MatchScore.Services.Services.Contracts
{
    public interface IRankingsService
    {
        List<Ranking> GetAll();

        Ranking GetByIDs(int playerId, int eventId);

        List<Ranking> GetByIDs(int eventId);

        List<Ranking> GetByIdWithDeleted(int eventId);

        Ranking Create(Ranking rankingToCreate);

        Ranking Update(Ranking rankingUpdate);

        void Delete(int playerId, int eventId);

        void Delete(List<Ranking> rankingToDelete);
    }
}
