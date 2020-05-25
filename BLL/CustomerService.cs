using BLL.Interfaces;
using DAL.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class CustomerService : ICustomerService
    {

        ICustomerRepository repository;

        public CustomerService(ICustomerRepository _repository)
        {
            repository = _repository;
        }
               

        public List<Customer> GetAllCustomers()
        {
            return repository.GetAll();
        }

        public Customer FindCustomerById(int id)
        {
            return repository.FindById(id);
        }

        public void AddCustomer(Customer customer)
        {
            repository.Add(customer);
        }

        public void RemoveCustomer(int id)
        {
            repository.Remove(id);
        }

        public void UpdateCustomer(Customer customer)
        {
            repository.Update(customer);
        }
    }
}
