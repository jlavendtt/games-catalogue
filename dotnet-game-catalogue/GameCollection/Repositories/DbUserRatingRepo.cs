using GameCollection.Exceptions;
using GameCollection.Models;
using GameCollection.Models.Domain;
using GameCollection.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCollection.Repositories
{
    public class DbUserRatingRepo : IUserRatingRepo
    {
        CollectionDbContext _context;

        public DbUserRatingRepo(CollectionDbContext context)
        {
            _context = context;
        }

        public void AddUserRating(UserRating userRating)
        {
            if (userRating == null) throw new RatingIsNullException("Cannot add null rating");
            _context.UserRatings.Add(userRating);
            _context.SaveChanges();
            
        }

        public void DeleteUserRating(UserRatingView view)
        {
            UserRating toDelete = new UserRating
            {
                GameId = view.GameId,
                UserId = view.UserId
            };
            _context.Attach(toDelete);
            _context.Remove(toDelete);
            _context.SaveChanges();
            return;
        }

        public void EditUserRating(UserRating edited)
        {
            _context.Attach(edited);
            _context.Entry(edited).State = EntityState.Modified;
            _context.SaveChanges();
            return;
        }

        public List<UserRating> GetAllCompletedRatings(int userId)
        {
            List<UserRating> userRatings = _context.UserRatings.Include(ur => ur.RatedGame).Where(r => r.UserId == userId && r.Completed).ToList()
                ;
            
            return userRatings;
        }

        public List<UserRating> GetAllNotStartedRatings(int userId)
        {
            List<UserRating> userRatings = _context.UserRatings.Include(ur => ur.RatedGame).Where(r => r.UserId == userId && !r.Started).ToList()
                ;

            return userRatings;
        }

        public List<UserRating> GetAllStartedRatings(int userId)
        {
            List<UserRating> userRatings = _context.UserRatings.Include(ur => ur.RatedGame).Where(r => r.UserId == userId && r.Started && !r.Completed).ToList()
                ;

            return userRatings;
        }

        public List<UserRating> GetAllUserRatings()
        {
            return _context.UserRatings.ToList();
        }

        public List<UserRating> GetUserRatingByGameId(int id)
        {

            //return _context.UserRatings.Where(ur => ur.GameId == id).ToList();
            var result = from rating in _context.UserRatings
                         where rating.GameId == id
                         select rating;
            return result.ToList();

        }

       

        public UserRating GetUserRatingByGameIdAndUserId(UserRatingView view)
        {
            var result = from rating in _context.UserRatings
                         where (rating.GameId == view.GameId && rating.UserId == view.UserId)
                         select rating;
            if (result.ToList().Count > 0) return result.ToList()[0];

            return null;
        }

        public List<UserRating> GetUserRatingByUserId(int id)
        {
            var result = from rating in _context.UserRatings
                         where rating.UserId == id
                         select rating;
            return result.ToList();
        }
    }
}
