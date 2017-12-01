using System.Collections.Generic;
using ECommerce.Domain.Entities;

namespace ECommerce.Domain.Repositories
{
    public interface IProductRepository
    {
        Product Create(Product product);
        List<Product> GetAll();
        Product GetById(int id);
        List<Product> Get(int skip, int take);
        List<Product> GetOutOfStock();
        void Update(Product product);
        void Delete(Product id);

    }
}
