using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class ShoppingBagRepository : IShoppingBagRepository
    {
        DataContext context;
        
        public ShoppingBagRepository(DataContext _context)
        {
            context = _context;

        }

        public void Add(ShoppingBag shoppingBag)
        {
            context.ShoppingBags.Add(shoppingBag);
            context.SaveChanges();
        }

        public ShoppingBag FindById(int id)
        {
            return context.ShoppingBags
                .Where(sb => sb.SBId == id)
                .Include(c => c.Customer)
                .Single();
        }

        public int FindLastId()
        {
            return context.ShoppingBags.Max(sb => sb.SBId);
        }

        public List<ShoppingBag> Get()
        {
            return context.ShoppingBags
                .Include(c => c.Customer)
                .ToList();
        }

        public void Remove(int id)
        {
            var shoppingBag = context.ShoppingBags.SingleOrDefault(sb => sb.SBId == id);
            context.ShoppingBags.Remove(shoppingBag);
            context.SaveChanges();
        }

        public void Update(ShoppingBag shoppingBag)
        {
            context.ShoppingBags.Update(shoppingBag);
            context.SaveChanges();
        }
    }
}
