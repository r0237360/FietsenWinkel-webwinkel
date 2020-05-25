using BLL.ViewModels;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IShoppingBagService
    {

        List<ShoppingBag> GetAllShoppingBags();

        ShoppingBag FindShoppingBagById(int id);

        int FindLastShoppingBagId();

        void UpdateShoppingBag(ShoppingBag shoppingBag);

        void AddShoppingBag(ShoppingBag shoppingBag);

        void RemoveShoppingBag(int id);
        
        shoppingBagViewModel AddItemToShoppingBag(int shoppingBagId, int customerId, int productId, int qty);

        shoppingBagViewModel FindShoppingBagWithItems(int id);

    }
}
