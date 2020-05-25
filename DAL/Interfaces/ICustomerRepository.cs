using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface ICustomerRepository
    {

        List<Customer> GetAll();

        Customer FindById(int id);

        void Add(Customer customer);

        void Update(Customer customer);
        
        void Remove(int id);
           
    }
}
