using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IProductService
    {

        // Get a list of products 
        List<Product> GetAllProducts();

        // Find 1 product by id
        Product FindProductById(int id);

        // CRU operations for product
       
        void AddProduct(Product product);

        void RemoveProduct(int id);

        void UpdateProduct(Product product);

    }
}
