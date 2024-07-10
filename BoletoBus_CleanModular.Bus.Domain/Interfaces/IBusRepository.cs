using BoletoBus_CleanModular.Common.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletoBus_CleanModular.Bus.Domain.Interfaces
{
    public interface IBusRepository : IBaseRepository<Bus.Domain.Entities.Bus, int>
    {

    }
}
