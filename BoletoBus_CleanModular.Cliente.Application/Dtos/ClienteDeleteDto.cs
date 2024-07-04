using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletoBus_CleanModular.Cliente.Application.Dtos
{
    public class ClienteDeleteDto : ClienteBaseDto
    {
        public DateTime? FechaEliminacion { get; set; }

    }
}
