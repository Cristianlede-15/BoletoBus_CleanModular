using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletoBus_CleanModular.Cliente.Application.Exceptions
{
    public class ClienteExceptionsDb : ArgumentNullException
    {
        public ClienteExceptionsDb(string message) : base(message) { }

    }
}
