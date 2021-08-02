using GameCollection.Exceptions;
using GameCollection.Models.Domain;
using GameCollection.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCollection.Services
{
    public class GameService : IGameService
    {
        IGameRepo _gameRepo;

        public GameService(IGameRepo gameRepo)
        {
            _gameRepo = gameRepo;
        }
        public List<Game> GetAllGames()
        {
            return _gameRepo.GetAllGames();
        }
        public Game GetGameById(int id)
        {
            Game game = _gameRepo.GetGameById(id);
            if (game == null) throw new GameNotFoundException("Game not found with that id");
            return game;
        }
        public int AddGame(Game game)
        {
            if (game == null) throw new GameIsNullException("Cannot add null game");
            return _gameRepo.AddGame(game);
        }
        public void DeleteGame(int id)
        {
            _gameRepo.DeleteGame(id);
        }
        public void EditGame(Game edited)
        {
            _gameRepo.EditGame(edited);
        }

        public List<Genre> GetGenresByIds(int[] selectedGenreIds)
        {
            throw new NotImplementedException();
        }
    }
}
