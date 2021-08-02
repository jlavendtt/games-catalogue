using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GameCollection.Models.Domain;
using Newtonsoft.Json;

namespace GameCollection.Models.Auth
{
    [Table("Users")]
    public class User
    {
        [Column("id")]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }

        [JsonIgnore]
        public byte[] PasswordHash { get; set; }
        [JsonIgnore]
        public byte[] PasswordSalt { get; set; }

        public List<UserRole> Roles { get; set; } = new List<UserRole>();

        public List<UserRating> Ratings { get; set; }
    }
}
