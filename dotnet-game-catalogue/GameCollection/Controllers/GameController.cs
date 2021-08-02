
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using GameCollection.Models;
using GameCollection.Services;
using GameCollection.Models.Domain;
using GameCollection.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace GameCollection.Controllers
{
    [ApiController]
    [Authorize]
    public class GameController : Controller
    {
        IGameService _service;

 

        public GameController(IGameService service)
        {
            _service = service;
        }

        [HttpGet("/Game")]
        public IActionResult GetAllGames()
        {
            return Accepted(_service.GetAllGames());
        }

        [HttpGet("/Game/{id}")]
        public IActionResult GetGame(int id)
        {
            Game game = _service.GetGameById(id);
            return Accepted(game);
        }

        [HttpPost("/Game")]
        public IActionResult AddGame(AddGameViewModel vm)
        {
            List<Genre> genres = _service.GetGenresByIds(vm.SelectedGenreIds);
            Game game = vm.GameToAdd;
            game.Genres = genres;

            _service.AddGame(game);
            return this.Accepted(game.Id);
        }

        [HttpPut("/Game")]
        public IActionResult EditGame(Game edited)
        {
            //BlogUser curUser = _context.BlogUsers.Find(edited.BlogUserId);
            //_context.Entry(curUser).CurrentValues.SetValues(edited);
            _service.EditGame(edited);
            return Accepted();
        }

        [HttpDelete("/Game/{id}")]
        public IActionResult DeleteGame(int id)
        {
            //BlogUser toDelete = _context.BlogUsers.Find(id);
            _service.DeleteGame(id);
            return Accepted();
        }
    }
}
