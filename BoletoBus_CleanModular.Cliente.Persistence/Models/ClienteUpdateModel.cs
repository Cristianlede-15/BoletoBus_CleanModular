﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletoBus_CleanModular.Cliente.Persistence.Models
{
    public class ClienteUpdateModel : ClienteBaseModel
    {
        public DateTime? FechaModificacion { get; set; }

    }
}
