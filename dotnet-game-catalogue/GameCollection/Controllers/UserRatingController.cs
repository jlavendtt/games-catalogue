
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
using System.Security.Claims;

namespace GameCollection.Controllers
{
    [ApiController]
    [Authorize]
    
    public class UserRatingController : Controller
    {
        IRatingService _service;


        public UserRatingController(IRatingService service)
        {

            _service = service;
        }

        [HttpGet("/UserRating")]
        public IActionResult GetAllUserRatings()
        {
            return Accepted(_service.GetAllUserRatings());
        }

        [HttpGet("/UserRatingUser/{id}")]
        public IActionResult GetUserRatingsByUserId(int id)
        {
            List<UserRating> userRatings = _service.GetUserRatingsByUserId(id);
            return Accepted(userRatings);
        }

        [HttpGet("/UserRatingGame/{id}")]
        public IActionResult GetUserRatingsByGameId(int id)
        {
            List<UserRating> userRatings = _service.GetUserRatingsByGameId(id);
            return Accepted(userRatings);
        }

        [HttpGet("/UserRatingUserGame")]
        public IActionResult GetUserRatingByUserIdAndGameId(UserRatingView view)
        {
            UserRating userRating = _service.GetUserRatingByGameIdAndUserId(view);
            return Accepted(userRating);
        }

        [HttpPost("/UserRating")]
        public IActionResult AddUser(UserRating userRating)
        {
            _service.AddUserRating(userRating);
            return this.Accepted(userRating);
        }

        [HttpPut("/UserRating")]
        public IActionResult EditUser(UserRating edited)
        {
            //BlogUser curUser = _context.BlogUsers.Find(edited.BlogUserId);
            //_context.Entry(curUser).CurrentValues.SetValues(edited);
            _service.EditUserRating(edited);
            return Accepted(edited);
        }
        [Authorize]
        [HttpGet("/UserRating/Completed")]
        public IActionResult GetCompletedRatings()
        {
            
            int id = int.Parse((this.User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value));
            List<UserRating> userRatings = _service.GetCompletedUserRating(id);
            return Ok(userRatings);
        }

        [Authorize]
        [HttpGet("/UserRating/Started")]
        public IActionResult GetStartedRatings()
        {

            int id = int.Parse((this.User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value));
            List<UserRating> userRatings = _service.GetStartedUserRatings(id);
            return Ok(userRatings);
        }

        [Authorize]
        [HttpGet("/UserRating/NotStarted")]
        public IActionResult GetNotStartedRatings()
        {

            int id = int.Parse((this.User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value));
            List<UserRating> userRatings = _service.GetNotStartedUserRatings(id);
            return Ok(userRatings);
        }

        [HttpDelete("/UserRating")]
        public IActionResult DeleteUser(UserRatingView view)
        {
            //BlogUser toDelete = _context.BlogUsers.Find(id);
            _service.DeleteUserRating(view);
            return Accepted();
        }
    }
}
