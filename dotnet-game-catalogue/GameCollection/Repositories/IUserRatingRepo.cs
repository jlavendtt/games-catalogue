using GameCollection.Models;
using GameCollection.Models.Domain;
using GameCollection.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCollection.Repositories
{
    public interface IUserRatingRepo
    {
        List<UserRating> GetAllUserRatings();
        List<UserRating> GetUserRatingByUserId(int id);
        List<UserRating> GetUserRatingByGameId(int id);
        void AddUserRating(UserRating userRating);
    
        UserRating GetUserRatingByGameIdAndUserId(UserRatingView view);
        void EditUserRating(UserRating edited);
        void DeleteUserRating(UserRatingView view);
        List<UserRating> GetAllCompletedRatings(int userId);
        List<UserRating> GetAllNotStartedRatings(int userId);
        List<UserRating> GetAllStartedRatings(int userId);
    }
}
