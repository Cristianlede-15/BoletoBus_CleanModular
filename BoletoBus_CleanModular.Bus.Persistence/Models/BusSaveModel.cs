using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletoBus_CleanModular.Bus.Persistence.Models
{
    public class BusSaveModel
    {
        public DateTime? FechaCreacion { get; set; }
        public object? Disponible { get; internal set; }
    }
}
