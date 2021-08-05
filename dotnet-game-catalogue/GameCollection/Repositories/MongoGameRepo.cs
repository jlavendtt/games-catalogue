using GameCollection.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using GameCollection.Models;

namespace GameCollection.Repositories
{
    public class MongoGameRepo : IGameRepo
    {
        IMongoCollection<Game> _games;

        public MongoGameRepo(ICatalogueDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DbName);
            _games = database.GetCollection<Game>(settings.GamesCollectionName);
        }
        public int AddGame(Game game)
        {
            throw new NotImplementedException();
        }

        public void DeleteGame(int id)
        {
            throw new NotImplementedException();
        }

        public void EditGame(Game edited)
        {
            throw new NotImplementedException();
        }

        public List<Game> GetAllGames()
        {
            return _games.Find(g => true).ToList();
        }

        public Game GetGameById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
