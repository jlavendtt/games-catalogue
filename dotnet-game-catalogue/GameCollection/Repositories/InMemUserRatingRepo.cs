using GameCollection.Models.Domain;
using GameCollection.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCollection.Repositories
{
    public class InMemUserRatingRepo : IUserRatingRepo
    {
        List<UserRating> allRatings = new List<UserRating>();
        public void AddUserRating(UserRating userRating)
        {
            allRatings.Add(userRating);
        }

        public void DeleteUserRating(UserRatingView view)
        {
            for (int i = 0; i < allRatings.Count; i++)
            {
                UserRating temp = allRatings[i];
                if (temp.GameId == view.GameId && temp.UserId == view.UserId) allRatings.RemoveAt(i);
            }
        }

        public void EditUserRating(UserRating edited)
        {
            for (int i = 0; i < allRatings.Count; i++)
            {
                UserRating temp = allRatings[i];
                if (temp.GameId == edited.GameId && temp.UserId == edited.UserId) allRatings[i] = edited;
            }
        }

        public List<UserRating> GetAllCompletedRatings(int userId)
        {
            List<UserRating> toReturn = new List<UserRating>();
            for (int i = 0; i < allRatings.Count; i++)
            {
                UserRating temp = allRatings[i];
                if (temp.UserId == userId && temp.Completed) toReturn.Add(allRatings[i]); 
            }
            return toReturn;
        }

        public List<UserRating> GetAllNotStartedRatings(int userId)
        {
            List<UserRating> toReturn = new List<UserRating>();
            for (int i = 0; i < allRatings.Count; i++)
            {
                UserRating temp = allRatings[i];
                if (temp.UserId == userId && !temp.Started) toReturn.Add(allRatings[i]);
            }
            return toReturn;
        }

        public List<UserRating> GetAllStartedRatings(int userId)
        {
            List<UserRating> toReturn = new List<UserRating>();
            for (int i = 0; i < allRatings.Count; i++)
            {
                UserRating temp = allRatings[i];
                if (temp.UserId == userId && temp.Started) toReturn.Add(allRatings[i]);
            }
            return toReturn;
        }

        public List<UserRating> GetAllUserRatings()
        {
            return allRatings;
        }

        public List<UserRating> GetUserRatingByGameId(int id)
        {
            List<UserRating> toReturn = new List<UserRating>();
            for (int i = 0; i < allRatings.Count; i++)
            {
                UserRating temp = allRatings[i];
                if (temp.GameId == id ) toReturn.Add(allRatings[i]);
            }
            return toReturn;
        }

        public UserRating GetUserRatingByGameIdAndUserId(UserRatingView view)
        {
            for (int i = 0; i < allRatings.Count; i++)
            {
                UserRating temp = allRatings[i];
                if (temp.GameId == view.GameId && temp.UserId == view.UserId) return temp;
            }
            return null;
        }

        public List<UserRating> GetUserRatingByUserId(int id)
        {
            List<UserRating> toReturn = new List<UserRating>();
            for (int i = 0; i < allRatings.Count; i++)
            {
                UserRating temp = allRatings[i];
                if (temp.UserId == id) toReturn.Add(allRatings[i]);
            }
            return toReturn;
        }
    }
}
