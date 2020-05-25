using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IShoppingBagRepository
    {
        
        List<ShoppingBag> Get();
        ShoppingBag FindById(int id);

        int FindLastId();

        void Add(ShoppingBag shoppingBag);

        void Remove(int id);

        void Update(ShoppingBag shoppingBag);

        

        


    }
}
