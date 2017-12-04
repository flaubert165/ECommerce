using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Repositories;
using ECommerce.Infrastructure.Data;

namespace ECommerce.Infrastructure.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        MySQLDataContext _context;

        public CategoryRepository(MySQLDataContext context)
        {
            _context = context;
        }

        public Category Create(Category entity)
        {
            _context.Categories.Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public List<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public Category GetById(int id)
        {
            return _context.Categories.Find(id);
        }

        public IQueryable<Category> Query(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Category entity)
        {
            _context.Categories.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(Category entity)
        {
            _context.Categories.Remove(entity);
            _context.SaveChanges();
        }
    }
}
