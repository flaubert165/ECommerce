using System;
using System.Collections.Generic;
using ECommerce.Domain.Entities;

namespace ECommerce.Domain.Services
{
    public interface ICategory
    {
        List<Category> Get();
        List<Category> Get(int skip, int take);
        Category Get(int id);
        Category Create(Category command);
        Category Update(Category command);
        Category Delete(int id);
    }
}
