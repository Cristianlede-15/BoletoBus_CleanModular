using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BoletoBus_CleanModular.Bus.Application.Base;
using BoletoBus_CleanModular.Common.Data.Base;

namespace BoletoBus_CleanModular.Common.Data.Repository
{
    public interface IBaseRepository<TEntity, TTypeId> where TEntity : class
    {
        ServiceResult Save(TEntity entity);
        ServiceResult Remove(TEntity entity);
        ServiceResult Update(TEntity entity);
        List<TEntity> GetAll();
        TEntity FindById(TTypeId id);
    }
}
