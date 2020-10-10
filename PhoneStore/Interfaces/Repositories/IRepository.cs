using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PhoneStore.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity :class
    {
        void Delete(TEntity entity);
        void Delete(object id);
        ICollection<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeProperties = null);
        TEntity GetByID(object id);
        void Insert(TEntity entity);
        void Update(TEntity entity);
    }
}
