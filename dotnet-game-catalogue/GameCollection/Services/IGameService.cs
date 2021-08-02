using GameCollection.Models.Domain;
using System.Collections.Generic;

namespace GameCollection.Services
{
    public interface IGameService
    {
        int AddGame(Game game);
        void DeleteGame(int id);
        void EditGame(Game edited);
        List<Game> GetAllGames();
        Game GetGameById(int id);
        List<Genre> GetGenresByIds(int[] selectedGenreIds);
    }
}