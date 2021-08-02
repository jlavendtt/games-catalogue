using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCollection.Exceptions
{
    public class GameIsNullException : Exception
    {
        public GameIsNullException(string message) : base(message)
        {

        }

        public GameIsNullException(string message, Exception inner) : base(message,inner)
        {

        }
    }
}
