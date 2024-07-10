using BoletoBus_CleanModular.Common.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletoBus_CleanModular.Cliente.Domain.Interfaces
{
    public interface IClienteRepository : IBaseRepository<Cliente.Domain.Entities.Cliente, int>
    {
    }
}
