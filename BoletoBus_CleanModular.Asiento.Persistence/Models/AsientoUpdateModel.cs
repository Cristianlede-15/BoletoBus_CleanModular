using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletoBus_CleanModular.Asiento.Persistence.Models
{
    public class AsientoUpdateModel : AsientoBaseModel
    {
        public int? NumeroPiso { get; set; }
        public int? NumeroAsiento { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}
