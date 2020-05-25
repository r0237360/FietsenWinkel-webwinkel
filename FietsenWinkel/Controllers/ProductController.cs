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
    public class ProductController : Controller
    {
        
        //Initiate controller using constructor injection to use BLL
        
        IProductService service;

        public ProductController(IProductService _service)
        {
            service = _service;
        }
        
        //
        // Index page of products where a list of all products is shown.
        //

        public IActionResult Index(int? _SBId)
        {
            List<Product> products = service.GetAllProducts();
            return View(products);
        }


        //
        // CRUD operation : Create
        //


        public IActionResult CreateProduct()
        {
            return View();
        }

        //Post:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateProduct([Bind("PId, PName, PPrice")] Product product)
        {
            if (ModelState.IsValid)
            {
                service.AddProduct(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }
        
        //
        //CRUD operation : Update
        //

        public IActionResult UpdateProduct(int PId)
        {
            Product product = service.FindProductById(PId);
            return View(product);
        }


        //Post:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateProduct(int PId, [Bind("PId, PName, PPrice")] Product product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    service.UpdateProduct(product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction("Index");

            }
            return View(product);
        }

        //
        //CRUD operation : Delete
        //

        //public IActionResult DeleteProduct(int PId)
        //{

        //    service.RemoveProduct(PId);
        //    return RedirectToAction("Index");
        //}


        public IActionResult DeleteProduct(int PId)
        {

            Product product = service.FindProductById(PId);
            return View(product);
        }

        //Post:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ExecuteDeleteProduct(int PId)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    service.RemoveProduct(PId);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction("Index");

            }
            return View();
        }

        //
        //Business action: Buy a product
        //

        public IActionResult BuyProduct(int PId, int? SBId)
        {
            Product product = service.FindProductById(PId);
            ViewData["SBId"] = SBId;
            ViewData["Quantity"] = 0;

            return View(product);
        }


        //Post:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult BuyProduct(int PId, int quantity, [Bind("PId, PName, PPrice")] Product product)
        {
            
            int CId = 1;

            if (ModelState.IsValid)
            {
                try
                {

                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                } 
                return RedirectToAction("CreateShoppingBag", "ShoppingBag", new { CId, PId, quantity });

            }
            return View(product);
        }




    }
}