using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameCollection.Models.Domain
{
    [Table("Genres")]
    public class Genre
    {
        [Column("id")]
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Game> Games { get; set; }
    }
}
