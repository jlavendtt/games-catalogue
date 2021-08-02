using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCollection.Exceptions
{
    public class UserIsNullException : Exception
    {
        public UserIsNullException(string message) : base(message)
        {

        }

        public UserIsNullException(string message, Exception inner) : base(message,inner)
        {

        }
    }
}
