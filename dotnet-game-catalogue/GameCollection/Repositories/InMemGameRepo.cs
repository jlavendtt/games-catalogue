using GameCollection.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCollection.Repositories
{
    public class InMemGameRepo : IGameRepo
    {
        List<Game> allGames = new List<Game>();
        public int AddGame(Game game)
        {
            
            int max = 0;
            for (int i = 0; i < allGames.Count; i++)
            {
                max = Math.Max(max, allGames[i].Id);
            }
            max++;
            game.Id = max;
            allGames.Add(game);
            return max;
        }

        public void DeleteGame(int id)
        {
            for (int i = 0; i < allGames.Count; i++)
            {
                Game temp = allGames[i];
                if (temp.Id == id) allGames.RemoveAt(i);
            }
        }

        public void EditGame(Game edited)
        {
            for (int i = 0; i < allGames.Count; i++)
            {
                Game temp = allGames[i];
                if (temp.Id == edited.Id) allGames[i] = edited;
            }
        }

        public List<Game> GetAllGames()
        {
            return allGames;
        }

        public Game GetGameById(int id)
        {
            for (int i = 0; i < allGames.Count; i++)
            {
                Game temp = allGames[i];
                if (temp.Id == id) return temp;
            }
            return null;
        }
    }
}
