using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetAll();

        Product FindById(int id);

        
        void Add(Product product);

        void Remove(int id);

        void Update(Product product);

    }
}
