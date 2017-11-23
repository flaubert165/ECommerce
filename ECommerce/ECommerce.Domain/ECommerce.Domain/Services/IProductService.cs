using System.Collections.Generic;
using ECommerce.Domain.Entities;

namespace ECommerce.Domain.Services
{
    public interface IProductService
    {
        List<Product> Get();
        List<Product> Get(int skip, int take);
        List<Product> GetOutOfStock();
        Product Get(int id);
        Product Create(Product product);
        Product Update(Product product);
        Product Delete(int id);
    }
}
