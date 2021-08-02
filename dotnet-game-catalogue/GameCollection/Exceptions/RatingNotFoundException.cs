using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCollection.Exceptions
{
    public class RatingNotFoundException : Exception
    {
        public RatingNotFoundException(string message) : base(message)
        {

        }
        public RatingNotFoundException(string message, Exception inner) : base(message,inner)
        {

        }
    }
}
