using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletoBus_CleanModular.Bus.Persistence.Models
{
    public class BusUpdateModel : BusBaseModel
    {
        public bool Disponible { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}
