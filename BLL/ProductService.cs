using BLL.Interfaces;
using DAL.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class ProductService : IProductService
    {
        IProductRepository repository;

        public ProductService(IProductRepository _repository)
        {
            repository = _repository;
        }

        public List<Product> GetAllProducts()
        {
            return repository.GetAll();
        }

        public Product FindProductById(int id)
        {
            return repository.FindById(id);
        }

        public void AddProduct(Product product)
        {
            repository.Add(product);
        }


        public void RemoveProduct(int id)
        {
            repository.Remove(id);
        }

        public void UpdateProduct(Product product)
        {
            repository.Update(product);
        }
    }
}
