using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ECommerce.Domain.Repositories
{
    public interface IRepository<TEntity>
    {
        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> filter);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        TEntity Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
    }
}
