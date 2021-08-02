using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameCollection.Models;
using GameCollection.Services;
using GameCollection.Models.Auth;
using GameCollection.Models.ViewModels.Requests;
using Microsoft.AspNetCore.Authorization;

namespace GameCollection.Controllers
{
    [ApiController]
    [Authorize]
    
    public class UserController : Controller
    {
        IUserService _service; 


        
        public UserController(IUserService service)
        {

            _service = service;
        }
        [AllowAnonymous]
        [HttpPost("Register")]
        public IActionResult RegisterUser(RegisterUserViewModel toAdd)
        {
            _service.RegisterUser(toAdd);

            return Ok(1);
        }
        [AllowAnonymous]
        [HttpPost("Login")]

        public IActionResult Login(LoginRequest vm)
        {
            string token = _service.Login(vm);
            return Ok(new {vm.Username, token });
        }

        [HttpGet("/User")]
        public IActionResult GetAllUsers()
        {
            return Accepted(_service.GetAllUsers());
        }

        [HttpGet("/User/{name}")]
        public IActionResult GetUser(string name)
        {
           User user = _service.GetByUserName(name);
            return Accepted(user);
        }

        [HttpGet("/UserById/{id}")]
        public IActionResult GetUserById(int id)
        {
            User user = _service.GetUserById(id);
            return Accepted(user);
        }

        [HttpPost("/User")]
        public IActionResult AddUser(User user)
        {
            _service.AddUser(user);
            return this.Accepted(user.Id);
        }

        

        [HttpPut("/User")]
        public IActionResult EditUser(User edited)
        {
            //BlogUser curUser = _context.BlogUsers.Find(edited.BlogUserId);
            //_context.Entry(curUser).CurrentValues.SetValues(edited);
            _service.EditUser(edited);
            return Accepted();
        }

        [HttpDelete("/User/{id}")]
        public IActionResult DeleteUser(int id)
        {
            //BlogUser toDelete = _context.BlogUsers.Find(id);
            _service.DeleteUser(id);
            return Accepted();
        }

    }
}
