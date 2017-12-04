using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ECommerce.Domain.Entities;

namespace ECommerce.Domain.Services
{
    public interface ICategoryService
    {
        Category Create(Category category);
        IQueryable<Category> Query(Expression<Func<Category, bool>> filter);
        List<Category> GetAll();
        Category GetById(int id);
        void Update(Category category);
        void Delete(int id);
    }
}
