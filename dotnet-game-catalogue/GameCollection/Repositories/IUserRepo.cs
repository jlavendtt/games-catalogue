using GameCollection.Models;
using GameCollection.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCollection.Repositories
{
    public interface IUserRepo
    {
        List<User> GetAllUsers();
        User GetUserById(int id);

        int AddUser(User toAdd);

        void DeleteUser(int id);

        void EditUser(User edited);

        Role GetRoleByName(string role);
        User GetUserByUsername(string username);
    }
}
