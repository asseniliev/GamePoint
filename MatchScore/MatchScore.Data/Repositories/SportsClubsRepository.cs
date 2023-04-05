using MatchScore.Data.Constants;
using MatchScore.Data.Data;
using MatchScore.Data.Models;
using MatchScore.Data.Repositories.Contracts;
using MatchScore.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MatchScore.Data.Repositories
{
    public class SportsClubsRepository : ISportsClubsRepository
    {
        private ApplicationContext context;

        public SportsClubsRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public List<SportsClub> GetAll()
        {
            var sportsClubs = this.GetSportsClubs().ToList();
            return sportsClubs;
        }

        public SportsClub GetById(int sportsClubId)
        {
            var sportsClub = this.GetSportsClubs().FirstOrDefault(sc => sc.SportsClubId == sportsClubId);
            return sportsClub ?? throw new EntityNotFoundException(string.Format(Messages.DoesNotExistErrorLong, "Sports Club", "id", sportsClubId));
        }

        public SportsClub GetByName(string sportsClubName)
        {
            var sportsClub = this.GetSportsClubs().FirstOrDefault(sc => sc.Name.ToLower() == sportsClubName.ToLower());
            return sportsClub ?? throw new EntityNotFoundException(string.Format(Messages.DoesNotExistErrorLong, "Sports Club", "name", sportsClubName));
        }

        public SportsClub Create(SportsClub sportsClub)
        {
            this.context.SportsClubs.Add(sportsClub);
            this.context.SaveChanges();
            return GetById(sportsClub.SportsClubId);
        }

        public SportsClub Update(SportsClub sportsClub)
        {
            this.context.SportsClubs.Update(sportsClub);
            this.context.SaveChanges();
            return GetById(sportsClub.SportsClubId);
        }

        public void Delete(SportsClub sportsClub)
        {
            this.context.SportsClubs.Update(sportsClub);
            this.context.SaveChanges();
        }

        #region Private Methods

        private IQueryable<SportsClub> GetSportsClubs()
        {
            return this.context.SportsClubs.Where(sc => !sc.IsDeleted)
                .Include(sc => sc.Players.Where(p => !p.IsDeleted))
                    .ThenInclude(p => p.Scores.Where(s => !s.IsDeleted))
                        .ThenInclude(s => s.Match)
                            .ThenInclude(m => m.Scores.Where(s => !s.IsDeleted));
        }
        #endregion
    }
}

