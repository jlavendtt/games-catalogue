using GameCollection.Models.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace GameCollection.Models.Domain
{
    public class UserRating
    {
        [ForeignKey("RatedGame")]
        public int GameId { get; set; }
        [ForeignKey("Rater")]
        public int UserId { get; set; }
        public Game RatedGame { get; set; }

        public User Rater { get; set; }

        public int Rating { get; set; }

        public bool Completed { get; set; }

        public bool Started { get; set; }

        public string Description { get; set; }
    }
}
