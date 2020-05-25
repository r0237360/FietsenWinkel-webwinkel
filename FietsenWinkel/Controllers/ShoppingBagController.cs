using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace FietsenWinkel.Controllers
{
    public class ShoppingBagController : Controller
    {
        
        IShoppingBagService serviceShoppingBag;

        public ShoppingBagController(IShoppingBagService _service)
        {
            serviceShoppingBag = _service;
        }


        public IActionResult Index()
        {
            List<ShoppingBag> shoppingBags = serviceShoppingBag.GetAllShoppingBags();

            return View(shoppingBags);
        }

        public IActionResult CreateShoppingBag(int CId, int PId, int quantity)
        {

            shoppingBagViewModel bag = serviceShoppingBag.AddItemToShoppingBag(HomeController.ShoppingBagId, CId, PId, quantity);
            HomeController.ShoppingBagId = bag.shoppingBag.SBId;

            //Go to View Edit
            return RedirectToAction("EditShoppingBag", new { bag.shoppingBag.SBId });

        }

        

        public IActionResult EditShoppingBag(int SBId)
        {
            

            if (SBId > 0)
            {
                shoppingBagViewModel shoppingBag = serviceShoppingBag.FindShoppingBagWithItems(SBId);
                return View(shoppingBag);
            }
            //else if (HomeController.shoppingBagId > 0)
            //{
            //    ShoppingBag shoppingBag = serviceShoppingBag.FindById(HomeController.shoppingBagId);
            //    return View(shoppingBag);
            //}

            return RedirectToAction("Index");

            //ShoppingBag shoppingBag = service.FindById(shoppingBagId);
            //return View(shoppingBag);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditShoppingBag(int SBId, [Bind("CustomerId, Date")] ShoppingBag shoppingBag)
        {
            if (ModelState.IsValid)
            {
                serviceShoppingBag.AddShoppingBag(shoppingBag);
                return RedirectToAction("Index");
            }
            return View(shoppingBag);
        }





    }
}