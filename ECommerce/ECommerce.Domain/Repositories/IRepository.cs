using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ECommerce.Domain.Repositories
{
    public interface IRepository<T>
    {
        T Create(T entity);
        IQueryable<T> Query(Expression<Func<T, bool>> filter);
        List<T> GetAll();
        T GetById(int id);
        void Update(T entity);
        void Delete(int id);
    }
}
