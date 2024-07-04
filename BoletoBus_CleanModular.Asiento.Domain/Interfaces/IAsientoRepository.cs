using BoletoBus_CleanModular.Asiento.Domain.Entities;
using BoletoBus_CleanModular.Common.Data.Repository;

namespace BoletoBus_CleanModular.Asiento.Domain.Interfaces
{
    public interface IAsientoRepository : IBaseRepository<Asiento.Domain.Entities.Asiento, int>
    {
        List<Asiento.Domain.Entities.Asiento> GetAsientosPorId(int asientoId);
    }
}
