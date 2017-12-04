using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Repositories;
using ECommerce.Domain.Services;

namespace ECommerce.Application.Services
{
    public class CategoryService : ICategoryService
    {
        IRepository<Category> _repository;

        public CategoryService(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public Category Create(Category category)
        {
            if (category == null)
                throw new Exception();

            return _repository.Create(category);
        }

        public List<Category> GetAll()
        {
            return _repository.GetAll();
        }

        public Category GetById(int id)
        {
            return _repository.GetById(id);
        }

        public IQueryable<Category> Query(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Category category)
        {
           _repository.Update(category);
        }

        public void Delete(int id)
        {
            var category = _repository.GetById(id);

            if (category == null)
                throw new Exception();
            
            _repository.Delete(category);
        }
    }
}
