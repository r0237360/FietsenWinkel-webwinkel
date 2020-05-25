using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace FietsenWinkel.Controllers
{
    public class CustomerController : Controller
    {
        //Initiate controller using constructor injection to use BLL

        ICustomerService service;

        public CustomerController(ICustomerService _service)
        {
            service = _service;
        }


        //
        // Index page of customers where a list of all products is shown.
        //

        public IActionResult Index()
        {
            List<Customer> customers = service.GetAllCustomers();
            return View(customers);
        }

        //
        // CRUD operation : Create
        //


        public IActionResult CreateCustomer()
        {
            return View();
        }

        //Post:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateCustomer([Bind("CId, CName, CFirstName")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                service.AddCustomer(customer);
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        //
        //CRUD operation : Update
        //

        public IActionResult UpdateCustomer(int CId)
        {
            Customer customer = service.FindCustomerById(CId);
            return View(customer);
        }


        //Post:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateCustomer(int CId, [Bind("CId, CName, CFirstName")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    service.UpdateCustomer(customer);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction("Index");

            }
            return View(customer);
        }


        //
        //CRUD operation : Delete
        //
    


        public IActionResult DeleteCustomer(int CId)
        {

            Customer customer = service.FindCustomerById(CId);
            return View(customer);
        }

        //Post:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ExecuteDeleteCustomer(int CId)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    service.RemoveCustomer(CId);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction("Index");

            }
            return View();
        }



    }
}