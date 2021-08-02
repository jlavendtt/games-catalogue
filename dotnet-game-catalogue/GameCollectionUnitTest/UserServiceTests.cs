using GameCollection;
using GameCollection.Exceptions;
using GameCollection.Models.Auth;
using GameCollection.Models.Domain;
using GameCollection.Repositories;
using GameCollection.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.Collections.Generic;

namespace GameCollectionUnitTest
{
    class UserServiceTests
    {

        UserService serv;

        [SetUp]
        public void Setup()
        {
            InMemUserRepo repo = new InMemUserRepo();
            serv = new UserService(repo);
        }

        [Test]
        public void AddUser()
        {
            User user = new User
            {
                Username = "name",
                Email = "email"
            };

            serv.AddUser(user);
            List<User> foundUsers = serv.GetAllUsers();
            User firstUser = foundUsers[0];
            Assert.AreEqual(1, foundUsers.Count);

            Assert.AreEqual("name", firstUser.Username);
            Assert.AreEqual("email", firstUser.Email);
        }
        [Test]
        public void TestAddNullUser()
        {
            Assert.Throws<UserIsNullException>(() => serv.AddUser(null));

        }

        [Test]
        public void TestGetInvalidId()
        {
            Assert.Throws<UserNotFoundException>(() => serv.GetUserById(1));

        }

        [Test]
        public void TestInvalidUsername()
        {
            Assert.Throws<UserNotFoundException>(() => serv.GetByUserName("shoudln't exist"));

        }

        [Test]
        public void GetUserById()
        {
            User user = new User
            {
                Username = "name",
                Email = "email"
            };

            int id = serv.AddUser(user);


            User foundUser = serv.GetUserById(id);

            Assert.AreEqual("name", foundUser.Username);
            Assert.AreEqual("email", foundUser.Email);
        }

        [Test]
        public void DeleteUser()
        {
            User user = new User
            {
                Username = "name",
                Email = "email"
            };

            int id = serv.AddUser(user);
           
            serv.DeleteUser(id);
            List<User> list = serv.GetAllUsers();

            Assert.AreEqual(0, list.Count);
        }

        [Test]
        public void EditUser()
        {
            User user = new User
            {
                Username = "name",
                Email = "email"
            };

            int id = serv.AddUser(user);
            User editedUser = new User
            {
                Username = "newTest",
                Email = "newSource",
                Id = id
            };
            serv.EditUser(editedUser);
            User foundUser = serv.GetUserById(id);


            Assert.AreEqual("newTest", foundUser.Username);
            Assert.AreEqual("newSource", foundUser.Email);
        }
    }
}
