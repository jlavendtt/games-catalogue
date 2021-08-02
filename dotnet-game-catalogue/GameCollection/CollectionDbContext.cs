using GameCollection.Models;
using GameCollection.Models.Auth;
using GameCollection.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCollection
{
    public class CollectionDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserRating> UserRatings { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRating>().HasKey(ur => new { ur.GameId, ur.UserId });
            modelBuilder.Entity<UserRole>().HasKey(ur => new { ur.UserId, ur.RoleId });
      
        }

        public CollectionDbContext(DbContextOptions<CollectionDbContext> options) : base(options)
        {

        }
    }
}
