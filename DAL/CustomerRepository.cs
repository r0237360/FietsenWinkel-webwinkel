using DAL.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class CustomerRepository : ICustomerRepository
    {

        DataContext context;


        public CustomerRepository(DataContext _context)
        {
            context = _context;

        }
                        

        public List<Customer> GetAll()
        {
            return context.Customers.ToList();
        }

        public Customer FindById(int id)
        {
            return context.Customers.Where(c => c.CId == id).SingleOrDefault();
        }

        public void Add(Customer customer)
        {
            context.Customers.Add(customer);
            context.SaveChanges();
        }

        public void Remove(int id)
        {
            context.Customers.Remove(context.Customers.Single(c => c.CId == id));
            context.SaveChanges();
        }

        public void Update(Customer customer)
        {
            context.Customers.Update(customer);
            context.SaveChanges();
        }
    }
}
