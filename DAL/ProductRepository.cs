using DAL.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class ProductRepository : IProductRepository
    {
        DataContext context;


        public ProductRepository(DataContext _context)
        {
            context = _context;

        }

        public List<Product> GetAll()
        {
            return context.Products.ToList();
        }

        public Product FindById(int id)
        {
            return context.Products.Where(p => p.PId == id).SingleOrDefault();
        }
               
        public void Add(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

        public void Remove(int id)
        {
            //var product = context.Products.Single(p => p.ProductId == id);
            //context.Products.Remove(product);

            context.Products.Remove(context.Products.Single(p => p.PId == id));
            context.SaveChanges();
        }

        public void Update(Product product)
        {
            context.Products.Update(product);
            context.SaveChanges();
        }
    }
}
