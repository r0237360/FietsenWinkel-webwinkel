using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class ShoppingItemRepository: IShoppingItemRepository
    {
        DataContext context;
        
        public ShoppingItemRepository(DataContext _context)
        {
            context = _context;

        }

        public void Add(ShoppingItem shoppingItem)
        {
            context.ShoppingItems.Add(shoppingItem);
            context.SaveChanges();
        }

        public ShoppingItem FindById(int id)
        {
            return context.ShoppingItems
                .Where(si => si.SIId == id)
                .Single();
        }

        public List<ShoppingItem> Get()
        {
            return context.ShoppingItems.ToList();
        }

        public List<ShoppingItem> GetItemsPerShoppingBag(int id)
        {
            return context.ShoppingItems
                .Where(sb => sb.SBId == id)
                .Include(p => p.Product)
                .ToList();
        }

        public void Remove(int id)
        {
            var shoppingItem = context.ShoppingItems.SingleOrDefault(si => si.SIId == id);
            context.ShoppingItems.Remove(shoppingItem);
            context.SaveChanges();
        }

        public void Update(ShoppingItem shoppingItem)
        {
            context.ShoppingItems.Update(shoppingItem);
            context.SaveChanges();
        }
    }
}
