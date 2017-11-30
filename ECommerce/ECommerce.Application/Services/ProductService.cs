using System;
using System.Collections.Generic;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Repositories;
using ECommerce.Domain.Services;
using ECommerce.Helpers.Resources;

namespace ECommerce.Application.Services
{
    public class ProductService : IProductService
    {
        IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public Product Create(Product product)
        {
            if (product == null)
                throw new Exception();
            
            return _repository.Create(product);
        }

        public List<Product> GetAll()
        {
            return _repository.GetAll();
        }

        public List<Product> Get(int skip, int take)
        {
            return _repository.Get(skip, take);
        }

        public Product GetById(int id)
        {
            return _repository.GetById(id);
        }

        public List<Product> GetOutOfStock()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            if (product == null)
                throw new Exception();
            
            _repository.Update(product);
        }

        public void Delete(Product product)
        {
            if (product == null)
                throw new Exception();
            
            _repository.Delete(product);
        }
    }
}
