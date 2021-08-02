using GameCollection.Models.Domain;
using GameCollection.Models.ViewModels;
using System.Collections.Generic;

namespace GameCollection.Services
{
    public interface IRatingService
    {
        void AddUserRating(UserRating userRating);
        void DeleteUserRating(UserRatingView view);
        void EditUserRating(UserRating edited);
        List<UserRating> GetAllUserRatings();
        List<UserRating> GetCompletedUserRating(int userId);
        UserRating GetUserRatingByGameIdAndUserId(UserRatingView view);
        List<UserRating> GetUserRatingsByGameId(int id);
        List<UserRating> GetUserRatingsByUserId(int id);
        List<UserRating> GetStartedUserRatings(int id);
        List<UserRating> GetNotStartedUserRatings(int id);
    }
}