﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletoBus_CleanModular.Asiento.Persistence.Models
{
    public class AsientoSaveModel : AsientoBaseModel
    {
        public int NumeroPiso { get; set; }
        public int NumeroAsiento { get; set; }
        public int? CapacidadTotal { get; set; }
        public bool? Disponible { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }
}
