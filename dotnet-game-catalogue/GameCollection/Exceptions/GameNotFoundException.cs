using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCollection.Exceptions
{
    public class GameNotFoundException : Exception
    {
        public GameNotFoundException(string message) : base(message)
        {

        }

        public GameNotFoundException(string message, Exception inner) : base(message,inner)
        {

        }
    }
}
