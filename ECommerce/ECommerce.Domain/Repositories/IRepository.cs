using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ECommerce.Domain.Repositories
{
    public interface IRepository<T>
    {
        IQueryable<T> Query(Expression<Func<T, bool>> filter);
        IEnumerable<T> GetAll();
        T GetById(int id);
        T Create(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
