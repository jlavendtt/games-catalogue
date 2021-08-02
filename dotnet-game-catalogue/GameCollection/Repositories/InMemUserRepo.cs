using GameCollection.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCollection.Repositories
{
    public class InMemUserRepo : IUserRepo
    {
        public List<User> AllUsers = new List<User>();
        public int AddUser(User toAdd)
        {
            
            //find max id and increment it
            int max = 0;
            for (int i = 0; i < AllUsers.Count; i++)
            {
                User temp = AllUsers[i];
                max = Math.Max(max, temp.Id);
            }
            max++;
            toAdd.Id = max;
            AllUsers.Add(toAdd);
            return max;
        }

        public void DeleteUser(int id)
        {
            for (int i = 0; i < AllUsers.Count; i++)
            {
                User temp = AllUsers[i];
                if (temp.Id == id) AllUsers.RemoveAt(i);
            }
        }

        public void EditUser(User edited)
        {
            for (int i = 0; i < AllUsers.Count; i++)
            {
                User temp = AllUsers[i];
                if (temp.Id == edited.Id) AllUsers[i] = edited;
            }
        }

        public List<User> GetAllUsers()
        {
            return AllUsers;
        }

        public Role GetRoleByName(string role)
        {
            throw new NotImplementedException();
        }

        public User GetUserById(int id)
        {
            for (int i = 0; i < AllUsers.Count; i++)
            {
                User temp = AllUsers[i];
                if (temp.Id == id) return AllUsers[i];
            }
            return null;
        }

        public User GetUserByUsername(string username)
        {
            for (int i = 0; i < AllUsers.Count; i++)
            {
                User temp = AllUsers[i];
                if (temp.Username == username) return temp;
            }
            return null;
        }
    }
}
