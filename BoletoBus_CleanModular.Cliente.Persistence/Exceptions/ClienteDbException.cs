using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletoBus_CleanModular.Cliente.Persistence.Exceptions
{

    public class ClienteDbException : Exception
    {
        public ClienteDbException(string message) : base(message)
        {
        }

        public ClienteDbException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
