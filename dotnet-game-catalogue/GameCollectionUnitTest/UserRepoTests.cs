using GameCollection;
using GameCollection.Exceptions;
using GameCollection.Models.Auth;
using GameCollection.Models.Domain;
using GameCollection.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.Collections.Generic;

namespace GameCollectionUnitTest
{
    class UserRepoTests
    {
        DbUserRepo userRepo;

        [SetUp]
        public void Setup()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.test.json").Build();
            var builder = new DbContextOptionsBuilder<CollectionDbContext>();
            builder.UseSqlServer(config.GetConnectionString("TestDb"));
            CollectionDbContext context = new CollectionDbContext(builder.Options);

            userRepo = new DbUserRepo(context);
            context.Users.RemoveRange(context.Users);
            context.SaveChanges();
        }

        private void resetRepo()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.test.json").Build();
            var builder = new DbContextOptionsBuilder<CollectionDbContext>();
            builder.UseSqlServer(config.GetConnectionString("TestDb"));
            CollectionDbContext context = new CollectionDbContext(builder.Options);

            userRepo = new DbUserRepo(context);
        }
        [Test]
        public void AddUser()
        {
            User user = new User
            {
                Username = "name",
                Email = "email"
            };

            userRepo.AddUser(user);
            List<User> foundUsers = userRepo.GetAllUsers();
            User firstUser = foundUsers[0];
            Assert.AreEqual(1, foundUsers.Count);

            Assert.AreEqual("name", firstUser.Username);
            Assert.AreEqual("email", firstUser.Email);
        }
        [Test]
        public void TestAddNullUser()
        {
            Assert.Throws<UserIsNullException>(() => userRepo.AddUser(null));

        }

        [Test]
        public void TestGetInvalidId()
        {
            Assert.Throws<UserNotFoundException>(() => userRepo.GetUserById(1));

        }

        [Test]
        public void TestInvalidUsername()
        {
            Assert.Throws<UserNotFoundException>(() => userRepo.GetUserByUsername("shoudln't exist"));

        }

        [Test]
        public void GetUserById()
        {
            User user = new User
            {
                Username = "name",
                Email = "email"
            };

            int id = userRepo.AddUser(user);


            User foundUser = userRepo.GetUserById(id);

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

            int id = userRepo.AddUser(user);
            this.resetRepo();
            userRepo.DeleteUser(id);
            List<User> list = userRepo.GetAllUsers();

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

            int id = userRepo.AddUser(user);
            this.resetRepo();
            User editedUser = new User
            {
                Username = "newTest",
                Email = "newSource",
                Id = id
            };
            userRepo.EditUser(editedUser);
            User foundUser = userRepo.GetUserById(id);


            Assert.AreEqual("newTest", foundUser.Username);
            Assert.AreEqual("newSource", foundUser.Email);
        }
    }
}
