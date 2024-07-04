using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletoBus_CleanModular.Asiento.Persistence.Exceptions
{
    public class AsientoDbException : Exception
    {
        public AsientoDbException(string message) : base(message)
        {
        }

        public AsientoDbException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
