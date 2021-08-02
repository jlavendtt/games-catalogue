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
    class GameServiceTests
    {
        GameService serv;

        [SetUp]
        public void Setup()
        {
            InMemGameRepo repo = new InMemGameRepo();
            serv = new GameService(repo);
        }

        [Test]
        public void AddGame()
        {
            Game game = new Game
            {
                Name = "test",
                Pic = "source"
            };

            serv.AddGame(game);
            List<Game> foundGames = serv.GetAllGames();
            Game firstGame = foundGames[0];
            Assert.AreEqual(1, foundGames.Count);

            Assert.AreEqual("test", firstGame.Name);
            Assert.AreEqual("source", firstGame.Pic);
        }
        [Test]
        public void TestAddNullGame()
        {
            Assert.Throws<GameIsNullException>(() => serv.AddGame(null));

        }

        [Test]
        public void TestGetInvalidId()
        {
            Assert.Throws<GameNotFoundException>(() => serv.GetGameById(1));

        }

        [Test]
        public void GetGameById()
        {
            Game game = new Game
            {
                Name = "test",
                Pic = "source"
            };

            int id = serv.AddGame(game);


            Game foundGame = serv.GetGameById(id);

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

            int id = serv.AddGame(game);
            
            serv.DeleteGame(id);
            List<Game> list = serv.GetAllGames();

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

            int id = serv.AddGame(game);
            Game editedGame = new Game
            {
                Name = "newTest",
                Pic = "newSource",
                Id = id
            };
            serv.EditGame(editedGame);
            Game foundGame = serv.GetGameById(id);


            Assert.AreEqual("newTest", foundGame.Name);
            Assert.AreEqual("newSource", foundGame.Pic);
        }
    }
}
