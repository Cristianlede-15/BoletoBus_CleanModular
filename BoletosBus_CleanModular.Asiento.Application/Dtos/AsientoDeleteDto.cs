﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletosBus_CleanModular.Asiento.Application.Dtos
{
    public class AsientoDeleteDto : AsientoBaseDto
    {
        public DateTime? FechaEliminacion { get; set; }

    }
}
