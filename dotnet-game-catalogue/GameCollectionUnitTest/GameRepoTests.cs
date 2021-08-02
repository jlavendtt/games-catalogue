using GameCollection;
using GameCollection.Exceptions;
using GameCollection.Models.Domain;
using GameCollection.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.Collections.Generic;

namespace GameCollectionUnitTest
{
    public class GameRepoTests
    {
        DbGameRepo gameRepo;

        [SetUp]
        public void Setup()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.test.json").Build();
            var builder = new DbContextOptionsBuilder<CollectionDbContext>();
            builder.UseSqlServer(config.GetConnectionString("TestDb"));
            CollectionDbContext context = new CollectionDbContext(builder.Options);

            gameRepo = new DbGameRepo(context);
            context.Games.RemoveRange(context.Games);
            context.SaveChanges();
        }

        private void resetRepo()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.test.json").Build();
            var builder = new DbContextOptionsBuilder<CollectionDbContext>();
            builder.UseSqlServer(config.GetConnectionString("TestDb"));
            CollectionDbContext context = new CollectionDbContext(builder.Options);

            gameRepo = new DbGameRepo(context);
        }

        [Test]
        public void AddGame()
        {
            Game game = new Game
            {
                Name = "test",
                Pic = "source"
            };

            gameRepo.AddGame(game);
            List<Game> foundGames = gameRepo.GetAllGames();
            Game firstGame = foundGames[0];
            Assert.AreEqual(1, foundGames.Count);

            Assert.AreEqual("test", firstGame.Name);
            Assert.AreEqual("source", firstGame.Pic);
        }
        [Test]
        public void TestAddNullGame()
        {
            Assert.Throws<GameIsNullException>(() => gameRepo.AddGame(null));

        }

        [Test]
        public void TestGetInvalidId()
        {
            Assert.Throws<GameNotFoundException>(() => gameRepo.GetGameById(1));

        }

        [Test]
        public void GetGameById()
        {
            Game game = new Game
            {
                Name = "test",
                Pic = "source"
            };

            int id = gameRepo.AddGame(game);
           

            Game foundGame = gameRepo.GetGameById(id);

            Assert.AreEqual("test", foundGame.Name);
            Assert.AreEqual("source", foundGame.Pic);
        }

        [Test]
        public void DeleteGame()
        {
            Game game = new Game
            {
                Name = "test",
                Pic = "source"
            };

            int id = gameRepo.AddGame(game);
            this.resetRepo();
            gameRepo.DeleteGame(id);
            List<Game> list = gameRepo.GetAllGames();

            Assert.AreEqual(0, list.Count);
        }

        [Test]
        public void EditGame()
        {
            Game game = new Game
            {
                Name = "test",
                Pic = "source"
            };

           int id = gameRepo.AddGame(game);
            this.resetRepo();
            Game editedGame = new Game
            {
                Name = "newTest",
                Pic = "newSource",
                Id = id
            };
            gameRepo.EditGame(editedGame);
            Game foundGame = gameRepo.GetGameById(id);
            

            Assert.AreEqual("newTest", foundGame.Name);
            Assert.AreEqual("newSource", foundGame.Pic);
        }
    }
}