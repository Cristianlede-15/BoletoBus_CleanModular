using BoletoBus_CleanModular.Bus.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletoBus_CleanModular.Bus.Persistence.Interfaces
{
    public interface IBusDb
    {
        void SaveBus(BusSaveDto busSaveModel);
        void UpdateBus(BusUpdateDto busUpdateModel);
        void DeleteBus(BusDeleteDto busDeleteModel);

        List<BusAccessDto> GetBuses();
        BusAccessDto GetBuses(int IdBus);
    }
}
