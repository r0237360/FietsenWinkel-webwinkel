using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace FietsenWinkel.Controllers
{
    public class ShoppingItemController : Controller
    {
        IShoppingItemService service;

        public ShoppingItemController(IShoppingItemService _service)
        {
            service = _service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateShoppingItem(ShoppingItem shoppingItem)
        {
           return View();
        }
    }
}