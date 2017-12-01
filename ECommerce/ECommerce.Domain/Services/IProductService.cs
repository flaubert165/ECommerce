using System.Collections.Generic;
using ECommerce.Domain.Entities;

namespace ECommerce.Domain.Services
{
    public interface IProductService
    {
        List<Product> GetAll();
        List<Product> Get(int skip, int take);
        List<Product> GetOutOfStock();
        Product GetById(int id);
        Product Create(Product product);
        void Update(Product product);
        void Delete(int id);
    }
}
