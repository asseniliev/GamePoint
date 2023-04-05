using MatchScore.Data.Constants;
using MatchScore.Data.Models;
using MatchScore.Data.Repositories.Contracts;
using MatchScore.Exceptions;
using MatchScore.Services.Helpers;
using MatchScore.Services.Services.Contracts;
using System.Collections.Generic;

namespace MatchScore.Services.Services
{
    public class SportsClubsService : ISportsClubsService
    {
        private readonly ISportsClubsRepository sportsClubsRepo;

        public SportsClubsService(ISportsClubsRepository sportsClubsRepo)
        {
            this.sportsClubsRepo = sportsClubsRepo;
        }

        #region MethodsForOtherServices
        //TODO remove method if no other service uses it

        public List<SportsClub> GetAll()
        {
            var sportsClub = this.sportsClubsRepo.GetAll();
            return sportsClub;
        }

        #endregion MethodsForOtherServices

        public SportsClub GetById(int sportsClubId)
        {
            var sportsClub = this.sportsClubsRepo.GetById(sportsClubId);
            return sportsClub;
        }

        public SportsClub Create(SportsClub sportsClub, User user)
        {
            // Authorization: user has to be director or admin
            AuthorizationHelper.AdminOrDirector(user);
            AuthorizationHelper.Active(user);

            // Check if club with the same name exists
            try
            {
                var repeatedSportsClub = this.sportsClubsRepo.GetByName(sportsClub.Name);
                throw new DuplicateEntityException(string.Format(Messages.AlreadyExistsError, "Sports club", "name", sportsClub.Name));
            }
            catch (EntityNotFoundException)
            {
                var result = this.sportsClubsRepo.Create(sportsClub);
                return result;
            }
        }

        public SportsClub Update(SportsClub sportsClubWithUpdates, User user)
        {
            // Authorization: user has to be director or admin
            AuthorizationHelper.AdminOrDirector(user);
            AuthorizationHelper.Active(user);

            // Check if club with the same name exists
            try
            {
                var repeatedSportsClub = this.sportsClubsRepo.GetByName(sportsClubWithUpdates.Name);
                throw new DuplicateEntityException(string.Format(Messages.AlreadyExistsError, "Sports club", "name", sportsClubWithUpdates.Name));
            }
            catch (EntityNotFoundException)
            {
                var sportsClubToUpdate = this.sportsClubsRepo.GetById(sportsClubWithUpdates.SportsClubId);
                sportsClubToUpdate.Name = sportsClubWithUpdates.Name;
                var result = this.sportsClubsRepo.Update(sportsClubToUpdate);
                return result;
            }
        }

        public void Delete(int sportsClubId, User user)
        {
            // Authorization: user has to be director or admin
            AuthorizationHelper.AdminOrDirector(user);
            AuthorizationHelper.Active(user);

            // Delete:
            var sportsClub = this.sportsClubsRepo.GetById(sportsClubId);
            sportsClub.IsDeleted = true;
            this.sportsClubsRepo.Delete(sportsClub);
        }
    }
}

