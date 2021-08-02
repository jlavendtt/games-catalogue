using System;
using System.Runtime.Serialization;

namespace GameCollection.Services
{
    [Serializable]
    internal class UserNameInUseException : Exception
    {
        public UserNameInUseException()
        {
        }

        public UserNameInUseException(string message) : base(message)
        {
        }

        public UserNameInUseException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UserNameInUseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}