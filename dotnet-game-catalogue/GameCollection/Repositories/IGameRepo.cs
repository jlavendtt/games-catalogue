using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameCollection.Models;
using GameCollection.Models.Domain;

namespace GameCollection.Repositories
{
    public interface IGameRepo
    {
        List<Game> GetAllGames();
        Game GetGameById(int id);

        int AddGame(Game game);

        void DeleteGame(int id);

        void EditGame(Game edited);
        
    }
}
