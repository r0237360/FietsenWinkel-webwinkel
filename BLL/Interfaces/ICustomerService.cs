using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface ICustomerService
    {
        
        List<Customer> GetAllCustomers();

        Customer FindCustomerById(int id);

        void AddCustomer(Customer customer);

        void RemoveCustomer(int id);

        void UpdateCustomer(Customer customer);
                    


    }
}
