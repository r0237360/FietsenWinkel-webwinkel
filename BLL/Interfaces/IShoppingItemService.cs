using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IShoppingItemService
    {

        List<ShoppingItem> GetAllShoppingItems();

        List<ShoppingItem> GetItemsPerShoppingBag(int id);

        ShoppingItem FindShoppingItemById(int id);

        void UpdateShoppingItem(ShoppingItem shoppingItem);

        void AddShoppingItem(ShoppingItem shoppingItem);

        void RemoveShoppingItem(int id);

    }
}
