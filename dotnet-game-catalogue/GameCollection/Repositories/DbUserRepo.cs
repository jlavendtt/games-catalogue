using GameCollection.Exceptions;
using GameCollection.Models;
using GameCollection.Models.Auth;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCollection.Repositories
{
    public class DbUserRepo : IUserRepo
    {
        CollectionDbContext _context;
        public DbUserRepo(CollectionDbContext context)
        {
            _context = context;
        }
        public int AddUser(User toAdd)
        {
            if (toAdd == null) throw new UserIsNullException("Cannot add null user");
            _context.Users.Add(toAdd);
            _context.SaveChanges();
            return (toAdd.Id);
        }

        public void DeleteUser(int id)
        {
            
            User toDelete = new User
            {
                Id = id
            };
            _context.Attach(toDelete);
            _context.Remove(toDelete);
            _context.SaveChanges();
            return;
        }

        public void EditUser(User edited)
        {
            _context.Attach(edited);
            _context.Entry(edited).State = EntityState.Modified;
            _context.SaveChanges();
            return;
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public Role GetRoleByName(string role)
        {
           Role toReturn = _context.Roles.SingleOrDefault(r => r.Name.ToLower() == role.ToLower());
            return toReturn;
        }

        public User GetUserById(int id)
        {
            User user = _context.Users.Include(u => u.Ratings)
                .Include("Ratings.RatedGame")
                .Where(x=> x.Id == id)
                .SingleOrDefault();
            if (user == null) throw new UserNotFoundException("Cannot find user with that id");
            return user;
        }

        public User GetUserByUsername(string username)
        {
            User toReturn = _context.Users
                .Include("Ratings.RatedGame")
                .Include("Roles.SelectedRole")
                .SingleOrDefault(u => u.Username.ToLower() == username.ToLower());
            if (toReturn == null) throw new UserNotFoundException("Cannot find user with that username");
            return toReturn;

        }
    }
}
