using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Connect4.Exceptions
{
    public class InvalidMoveException : Exception
    {
        public InvalidMoveException() : base ("Invalid Move")
        {
        }

        public InvalidMoveException(string message) : base(message)
        {
        }
    }
}
