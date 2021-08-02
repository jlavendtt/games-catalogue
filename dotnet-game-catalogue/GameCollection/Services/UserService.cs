using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Exceptions;
using GameCollection.Models;
using GameCollection.Models.Auth;
using GameCollection.Models.Domain;
using GameCollection.Models.ViewModels;
using GameCollection.Models.ViewModels.Requests;
using GameCollection.Repositories;
using Microsoft.IdentityModel.Tokens;


namespace GameCollection.Services
{
    public class UserService : IUserService
    {
        IUserRepo _userRepo;



        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;

        }

        public void RegisterUser(RegisterUserViewModel vm)
        {
            User previouslyUsed = _userRepo.GetUserByUsername(vm.Username);
            if (previouslyUsed != null)
            {
                throw new UserNameInUseException();
            }


            Role basicRole = _userRepo.GetRoleByName("user");
            UserRole bridgeRow = new UserRole();
            bridgeRow.RoleId = basicRole.Id;
            bridgeRow.SelectedRole = basicRole;
            User toAdd = new User();
            bridgeRow.EnrolledUser = toAdd;
            toAdd.Roles.Add(bridgeRow);
            toAdd.Email = vm.Email;
            toAdd.Username = vm.Username;
            using (var hMac = new System.Security.Cryptography.HMACSHA512())
            {
                byte[] salt = hMac.Key;
                byte[] hash = hMac.ComputeHash(Encoding.UTF8.GetBytes(vm.Password));
                toAdd.PasswordSalt = salt;
                toAdd.PasswordHash = hash;
            }

            _userRepo.AddUser(toAdd);


        }

        public User GetByUserName(string name)
        {
            User user = _userRepo.GetUserByUsername(name);
            if (user == null) throw new UserNotFoundException("User not found for that username");
            return user;
        }

        public string Login(LoginRequest vm)
        {
            User curUser = _userRepo.GetUserByUsername(vm.Username);
            bool passValidated = this.ValidatedPassword(vm.Password, curUser.PasswordSalt, curUser.PasswordHash);
            if (!passValidated)
            {
                throw new InvalidPasswordException();
            }
            string token = this.GenerateToken(curUser);
            return token;
        }

        private string GenerateToken(User curUser)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(AppSettings.Secret);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    curUser.Roles.Select(r => new Claim(ClaimTypes.Role, r.SelectedRole.Name))
                    .Append(new Claim(ClaimTypes.NameIdentifier, curUser.Id.ToString()))),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)

            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            string tokenString = tokenHandler.WriteToken(token);
            return tokenString;

        }



        private bool ValidatedPassword(string password, byte[] passwordSalt, byte[] passwordHash)
        {
            using (var hMac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                byte[] passHashed = hMac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < passwordHash.Length; ++i)
                {
                    if (passwordHash[i] != passHashed[i])
                    {
                        return false;
                    }
                }
                return true;

            }
        }

        public List<User> GetAllUsers()
        {
            return _userRepo.GetAllUsers();
        }
        public User GetUserById(int id)
        {
            User user = _userRepo.GetUserById(id);
            if (user == null) throw new UserNotFoundException("Can't find user with that id");
            return user;
        }



        public int AddUser(User toAdd)
        {
            if (toAdd == null) throw new UserIsNullException("Can't add null user");
            return _userRepo.AddUser(toAdd);
        }



        //internal List<Genre> GetGenresByIds(int[] selectedGenreIds)
        //{

        //    throw new NotImplementedException("make new genre repo ");
        //}




        public void DeleteUser(int id)
        {
            _userRepo.DeleteUser(id);
        }







        public void EditUser(User edited)
        {
            _userRepo.EditUser(edited);
        }








    }
}
