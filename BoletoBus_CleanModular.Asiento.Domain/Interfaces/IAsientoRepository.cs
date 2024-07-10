using BoletoBus_CleanModular.Asiento.Domain.Entities;
using BoletoBus_CleanModular.Common.Data.Repository;

namespace BoletoBus_CleanModular.Asiento.Domain.Interfaces
{
    public interface IAsientoRepository : IBaseRepository<Domain.Entities.Asiento, int>
    {
    }
}
