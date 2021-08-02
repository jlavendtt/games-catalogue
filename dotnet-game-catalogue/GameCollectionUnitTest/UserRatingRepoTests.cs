using GameCollection;
using GameCollection.Exceptions;
using GameCollection.Models.Auth;
using GameCollection.Models.Domain;
using GameCollection.Models.ViewModels;
using GameCollection.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.Collections.Generic;

namespace GameCollectionUnitTest
{
    class UserRatingRepoTests
    {
        DbUserRatingRepo ratingRepo;
        int userId;
        int gameId;

        [SetUp]
        public void Setup()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.test.json").Build();
            var builder = new DbContextOptionsBuilder<CollectionDbContext>();
            builder.UseSqlServer(config.GetConnectionString("TestDb"));
            CollectionDbContext context = new CollectionDbContext(builder.Options);

            ratingRepo = new DbUserRatingRepo(context);
            context.UserRatings.RemoveRange(context.UserRatings);
            context.Users.RemoveRange(context.Users);
            context.Games.RemoveRange(context.Games);
            context.SaveChanges();
            User user = new User
            {
                Username = "name",
                Email = "email"
            };

            Game game = new Game
            {
                Name = "test",
                Pic = "source"
            };
            DbUserRepo userRepo = new DbUserRepo(context);
            DbGameRepo gameRepo = new DbGameRepo(context);
            userId = userRepo.AddUser(user);
            gameId = gameRepo.AddGame(game);
        }

        private void resetRepo()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.test.json").Build();
            var builder = new DbContextOptionsBuilder<CollectionDbContext>();
            builder.UseSqlServer(config.GetConnectionString("TestDb"));
            CollectionDbContext context = new CollectionDbContext(builder.Options);

            ratingRepo = new DbUserRatingRepo(context);
        }

        [Test]
        public void AddRating()
        {

            UserRating rating = new UserRating
            {
                UserId = userId,
                GameId = gameId,
                Completed = true,
                Description = "hello"
            };
            ratingRepo.AddUserRating(rating);
            List<UserRating> foundRatings = ratingRepo.GetAllUserRatings();
            UserRating firstUserRating = foundRatings[0];
            Assert.AreEqual(1, foundRatings.Count);

            Assert.AreEqual(true, firstUserRating.Completed);
            Assert.AreEqual("hello", firstUserRating.Description);
        }

        [Test]
        public void TestAddNullRating()
        {
            Assert.Throws<RatingIsNullException>(() => ratingRepo.AddUserRating(null));

        }

       

        [Test]
        public void GetRatingByUserId()
        {
            UserRating rating = new UserRating
            {
                UserId = userId,
                GameId = gameId,
                Completed = true,
                Description = "hello"
            };
            
            ratingRepo.AddUserRating(rating);


            UserRating firstUserRating = ratingRepo.GetUserRatingByUserId(userId)[0];

            Assert.AreEqual(true, firstUserRating.Completed);
            Assert.AreEqual("hello", firstUserRating.Description);
        }

        [Test]
        public void DeleteUserRating()
        {
            UserRating rating = new UserRating
            {
                UserId = userId,
                GameId = gameId,
                Completed = true,
                Description = "hello"
            };

            ratingRepo.AddUserRating(rating);
            this.resetRepo();
            UserRatingView view = new UserRatingView
            {
                GameId = gameId,
                UserId = userId
            };
            ratingRepo.DeleteUserRating(view);
            List<UserRating> list = ratingRepo.GetAllUserRatings();

            Assert.AreEqual(0, list.Count);
        }

        [Test]
        public void EditUserRating()
        {
            UserRating rating = new UserRating
            {
                UserId = userId,
                GameId = gameId,
                Completed = true,
                Description = "hello"
            };

            ratingRepo.AddUserRating(rating);
            this.resetRepo();
            UserRating toEdit = new UserRating
            {
                UserId = userId,
                GameId = gameId,
                Completed = false,
                Description = "goodbye"
            };
            ratingRepo.EditUserRating(toEdit);
            List<UserRating> list = ratingRepo.GetAllUserRatings();
            UserRating firstUserRating = list[0];


            Assert.AreEqual(false, firstUserRating.Completed);
            Assert.AreEqual("goodbye", firstUserRating.Description);
        }
    }
}
