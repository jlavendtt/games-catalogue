using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCollection.Exceptions
{
    public class RatingCompletedAndNotStartedException : Exception
    {
        public RatingCompletedAndNotStartedException(string message) : base(message)
        {

        }

        public RatingCompletedAndNotStartedException(string message, Exception inner) : base(message,inner)
        {

        }
    }
}
