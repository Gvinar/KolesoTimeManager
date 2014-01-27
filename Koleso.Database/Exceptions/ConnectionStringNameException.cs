using System;

namespace Koleso.Database.Exceptions
{
    public class ConnectionStringNameException : Exception
    {
        public ConnectionStringNameException()
        {    
        }

        public ConnectionStringNameException(string message)
            : base(message)
        {
        }
    }
}
