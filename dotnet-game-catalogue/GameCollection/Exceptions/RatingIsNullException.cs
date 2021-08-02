using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCollection.Exceptions
{
    public class RatingIsNullException : Exception
    {
        public RatingIsNullException(string message) : base(message)
        {

        }

        public RatingIsNullException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
