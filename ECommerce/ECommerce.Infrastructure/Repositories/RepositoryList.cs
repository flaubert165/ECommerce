using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Repositories;

namespace ECommerce.Infrastructure.Repositories
{
    public class RepositoryList<T> : IRepository<T> where T : Entity
    {
        private readonly List<T> _list;
        public bool commited;

        public RepositoryList(List<T> list)
        {
            this._list = list;
            commited = false;
        }

        public T Create(T entity)
        {
            entity.Id = 1;
            _list.Add(entity);

            return entity;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            return _list;
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Query(Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
