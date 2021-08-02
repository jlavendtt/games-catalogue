using GameCollection.Models;
using GameCollection.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameCollection.Exceptions;

namespace GameCollection.Repositories
{
    public class DbGameRepo : IGameRepo
    {
        CollectionDbContext _context;

        public DbGameRepo(CollectionDbContext context)
        {
            _context = context;
        }

        public int AddGame(Game game)
        {
            if (game == null) throw new GameIsNullException("Cannot add null game");
            _context.Games.Add(game);
            _context.SaveChanges();
            return (game.Id);
        }

        public void DeleteGame(int id)
        {
            Game toDelete = new Game
            {
                Id = id
            };
            _context.Attach(toDelete);
            _context.Remove(toDelete);
            _context.SaveChanges();
            return;
        }

        public void EditGame(Game edited)
        {
            _context.Attach(edited);
            _context.Entry(edited).State = EntityState.Modified;
            _context.SaveChanges();
            return;
        }

        public List<Game> GetAllGames()
        {
            
            return _context.Games.ToList();
        }

        public Game GetGameById(int id)
        {
            Game game = _context.Games.Include(g => g.Ratings)
                .Include("Ratings.Rater")
                .Include(g=> g.Genres)
                .Where(x => x.Id == id)
                .SingleOrDefault();
            if (game == null) throw new GameNotFoundException("Can not find game with that Id");
            return game;

            
        }
    }
}
