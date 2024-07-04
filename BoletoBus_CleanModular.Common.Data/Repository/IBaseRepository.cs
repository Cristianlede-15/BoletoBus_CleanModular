using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BoletoBus_CleanModular.Common.Data.Repository
{
    public interface IBaseRepository<TEntity, TTypeId> where TEntity : class
    {
        void Save(TEntity entity);
        void Remove(TEntity entity);
        void Update(TEntity entity);
        List<TEntity> GetAll();
        TEntity FindById(TTypeId id);
        Task<bool> Exists(Expression<Func<TEntity, bool>> filter);
    }
}
