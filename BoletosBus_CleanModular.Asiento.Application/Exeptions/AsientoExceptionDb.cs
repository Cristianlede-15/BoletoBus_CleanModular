using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletoBus_CleanModular.Asiento.Application.Exeptions
{
    public class AsientoExceptionDb : ArgumentNullException
    {
        public AsientoExceptionDb(string message) : base(message) { }

    }
}
