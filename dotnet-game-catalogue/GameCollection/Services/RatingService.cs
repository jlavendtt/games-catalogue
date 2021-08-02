using GameCollection.Exceptions;
using GameCollection.Models.Domain;
using GameCollection.Models.ViewModels;
using GameCollection.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCollection.Services
{
    public class RatingService : IRatingService
    {
        IUserRatingRepo _userRatingRepo;

        public RatingService(IUserRatingRepo ratingRepo)
        {
            _userRatingRepo = ratingRepo;
        }
        public List<UserRating> GetNotStartedUserRatings(int userId)
        {
            return _userRatingRepo.GetAllNotStartedRatings(userId);
        }

        public List<UserRating> GetStartedUserRatings(int userId)
        {
            return _userRatingRepo.GetAllStartedRatings(userId);
        }

        public List<UserRating> GetCompletedUserRating(int userId)
        {
            return _userRatingRepo.GetAllCompletedRatings(userId);
        }
        public List<UserRating> GetAllUserRatings()
        {
            return _userRatingRepo.GetAllUserRatings();
        }

        public List<UserRating> GetUserRatingsByUserId(int id)
        {
            return _userRatingRepo.GetUserRatingByUserId(id);
        }
        public List<UserRating> GetUserRatingsByGameId(int id)
        {
            return _userRatingRepo.GetUserRatingByGameId(id);
        }
        public UserRating GetUserRatingByGameIdAndUserId(UserRatingView view)
        {
            return _userRatingRepo.GetUserRatingByGameIdAndUserId(view);
        }

        public void AddUserRating(UserRating userRating)
        {
            if (userRating == null) throw new RatingIsNullException("Can't add null raiting");
            if (userRating.Completed && !userRating.Started) throw new RatingCompletedAndNotStartedException("Can't complete a game without starting it");
            _userRatingRepo.AddUserRating(userRating);
        }
        public void EditUserRating(UserRating edited)
        {
            _userRatingRepo.EditUserRating(edited);
        }
        public void DeleteUserRating(UserRatingView view)
        {
            _userRatingRepo.DeleteUserRating(view);
        }
    }
}
