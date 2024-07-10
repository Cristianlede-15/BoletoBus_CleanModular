using BoletosBus_CleanModular.Asiento.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletoBus_CleanModular.Asiento.Persistence.Interfaces
{
    public interface IAsientoDb
    {
        void SaveAsiento(AsientoSaveDto asientoSaveModel);
        void UpdateAsiento(AsientoUpdateDto asientoUpdateModel);
        void DeleteAsiento(AsientoDeleteDto asientoDeleteModel);
        void GetAsientoById(AsientoDeleteDto asientoDeleteModel);

        List<AsientoAccesDto> GetAsientos();
        AsientoAccesDto GetAsientos(int IdAsiento);
    }
}
