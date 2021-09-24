using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T2Task1
{
    class ValidationException : Exception
    {
        private const string DefaultMessage = "Wrong format";
        public ValidationException() : base(DefaultMessage)
        {

        }
        public ValidationException(string Message) : base(Message)
        {

        }

        public ValidationException(Exception innerException): base(DefaultMessage,innerException)
        {

        }


        public ValidationException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
