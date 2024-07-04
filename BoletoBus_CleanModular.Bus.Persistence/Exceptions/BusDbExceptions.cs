using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletoBus_CleanModular.Bus.Persistence.Exceptions
{
    public class BusDbExceptions : Exception
    {
        public BusDbExceptions(string message) : base(message)
        {
        }

        public BusDbExceptions(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
