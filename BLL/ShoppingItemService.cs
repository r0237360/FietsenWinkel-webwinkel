using BLL.Interfaces;
using DAL.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class ShoppingItemService : IShoppingItemService
    {

        IShoppingItemRepository repository;

        public ShoppingItemService(IShoppingItemRepository _repository)
        {
            repository = _repository;
        }

        public void AddShoppingItem(ShoppingItem shoppingItem)
        {
            repository.Add(shoppingItem);
        }

        public ShoppingItem FindShoppingItemById(int id)
        {
            return repository.FindById(id);
        }

        public List<ShoppingItem> GetAllShoppingItems()
        {
            return repository.Get();
        }

        public List<ShoppingItem> GetItemsPerShoppingBag(int id)
        {
            return repository.GetItemsPerShoppingBag(id);
        }

        public void RemoveShoppingItem(int id)
        {
            repository.Remove(id);
        }

        public void UpdateShoppingItem(ShoppingItem shoppingItem)
        {
            repository.Update(shoppingItem);
        }
    }
}
