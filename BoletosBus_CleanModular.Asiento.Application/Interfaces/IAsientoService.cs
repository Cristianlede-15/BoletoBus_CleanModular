using BoletoBus_CleanModular.Asiento.Application.Base;
using BoletoBus_CleanModular.Asiento.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletoBus_CleanModular.Asiento.Application.Interfaces
{
    public interface IAsientoService
    {
        ServiceResult GetAsientos();
        ServiceResult GetAsiento(int id);
        ServiceResult UpdateAsientos(AsientoUpdateDto asientoUpdate);
        ServiceResult DeleteAsientos(AsientoDeleteDto asientoDelete);
        ServiceResult SaveAsiento(AsientoSaveDto asientoSave);
    }
}
