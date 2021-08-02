using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCollection.Exceptions
{
    public class RatingCompletedButNotStartedException : Exception
    {

        public RatingCompletedButNotStartedException(string message) : base(message)
        {

        }

        public RatingCompletedButNotStartedException(string message, Exception inner) : base(message,inner)
        {

        }
    }
}
