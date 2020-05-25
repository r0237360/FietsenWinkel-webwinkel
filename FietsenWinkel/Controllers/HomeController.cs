using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace FietsenWinkel.Controllers
{
    public class HomeController : Controller
    {

        public static int ShoppingBagId = 0;


        //Initiate controller using constructor injection to use BLL

        //HomeService service;

        /*public HomeController()
        {
            service = new HomeService();
        }*/

        IHomeService service;
                          
        public HomeController(IHomeService _service)
        {
            service = _service;
        }

        //
        // Logic to define the picture shown on the Home page 
        //

        public IActionResult Index()
        {
            // string image = hService.GenerateImage()
            string image = service.GenerateImage();
            ViewData["image"] = image;
            return View();

            //Random r = new Random();
            //int getal = r.Next(1, 5);
            //ViewData["nummer"] = getal;
            //return View();
                                   
        }

        
    }
}