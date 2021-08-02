using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameCollection.Models.Domain
{
    [Table("Games")]
    public class Game {


        [Column("id")]  
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string Pic { get; set; }

        public List<Genre> Genres { get; set; }
        
        public List<UserRating> Ratings { get; set; }

        //ToDo add pictures
    }
}
