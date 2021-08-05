using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace GameCollection.Models.Domain
{
    public class Game {


        [BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }
        public string Name { get; set; }

        public string Pic { get; set; }

        public List<Genre> Genres { get; set; }
        
        public List<UserRating> Ratings { get; set; }

        //ToDo add pictures
    }
}
