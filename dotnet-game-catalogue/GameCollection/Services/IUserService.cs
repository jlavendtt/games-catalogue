using GameCollection.Models.Auth;
using GameCollection.Models.ViewModels.Requests;
using System.Collections.Generic;

namespace GameCollection.Services
{
    public interface IUserService
    {
        int AddUser(User toAdd);
        void DeleteUser(int id);
        void EditUser(User edited);
        List<User> GetAllUsers();
        User GetByUserName(string name);
        User GetUserById(int id);
        string Login(LoginRequest vm);
        void RegisterUser(RegisterUserViewModel vm);
    }
}