using BoletoBus_CleanModular.Bus.Application.Base;
using BoletoBus_CleanModular.Bus.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletoBus_CleanModular.Bus.Application.Interfaces
{
    public interface IBusService
    {
        ServiceResult GetBuses();
        ServiceResult GetBus(int id);
        ServiceResult UpdateBuses(BusUpdateDto busUpdate);
        ServiceResult DeleteBus(BusDeleteDto busDelete);
        ServiceResult SaveBus(BusSaveDto busSave);
    }
}
