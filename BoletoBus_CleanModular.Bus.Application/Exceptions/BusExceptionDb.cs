using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletoBus_CleanModular.Bus.Application.Exceptions
{
    public class BusExceptionDb : ArgumentNullException
    {
        public BusExceptionDb(string message) : base(message) { }

    }
}
