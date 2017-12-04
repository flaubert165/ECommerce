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
            _list = list;
            commited = false;
        }

        public T Create(T entity)
        {
            _list.Add(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            _list.Remove(entity);
        }

        public List<T> GetAll()
        {
            return _list;
        }

        public T GetById(int id)
        {
            return _list.Find(x => x.Id == id);
        }

        public IQueryable<T> Query(Expression<Func<T, bool>> filter)
        {
            return _list.AsQueryable();
        }

        public void Update(T entity)
        {
            _list[_list.IndexOf(GetById(entity.Id))] = entity;
        }
    }
}
