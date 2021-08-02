using GameCollection;
using GameCollection.Exceptions;
using GameCollection.Models.Auth;
using GameCollection.Models.Domain;
using GameCollection.Repositories;
using GameCollection.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.Collections.Generic;
namespace GameCollectionUnitTest
{
    class UserRatingServiceTests
    {
        RatingService serv;
        int userId;
        int gameId;

        [SetUp]
        public void Setup()
        {
            InMemUserRatingRepo repo = new InMemUserRatingRepo();
            serv = new RatingService(repo);
            
        }

        [Test]
        public void CompletedWithoutStartingTest()
        {
            UserRating rating = new UserRating();
            rating.Completed = true;
            rating.Started = false;
            Assert.Throws<RatingCompletedAndNotStartedException>(() => serv.AddUserRating(rating));
        }

        
    }
}
