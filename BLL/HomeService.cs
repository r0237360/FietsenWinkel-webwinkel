using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class HomeService : IHomeService
    {
        
        public string GenerateImage()
        {
            Random r = new Random();
            int getal = r.Next(1, 5);
            
            return "/images/bikes/Fiets" + getal.ToString() + ".jpg";
        }
    }
}
