using BLL.Interfaces;
using BLL.ViewModels;
using DAL.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class ShoppingBagService:IShoppingBagService
    {
        IShoppingBagRepository repository;
        IShoppingItemRepository shoppingItemRepository;

        public ShoppingBagService(IShoppingBagRepository _repository, IShoppingItemRepository _shoppingItemRepository)
        {
            repository = _repository;
            shoppingItemRepository = _shoppingItemRepository;
        }

        public void AddShoppingBag(ShoppingBag shoppingBag)
        {
            repository.Add(shoppingBag);
        }

        public int FindLastShoppingBagId()
        {
            return repository.FindLastId();
        }

        public ShoppingBag FindShoppingBagById(int id)
        {
            return repository.FindById(id);
        }

        public List<ShoppingBag> GetAllShoppingBags()
        {
            return repository.Get();
        }

        public void RemoveShoppingBag(int id)
        {
            repository.Remove(id);
        }

        public void UpdateShoppingBag(ShoppingBag shoppingBag)
        {
            repository.Update(shoppingBag);
        }

        
        public shoppingBagViewModel AddItemToShoppingBag(int shoppingBagId, int customerId, int productId, int quantity)
        {
            ShoppingBag shoppingBag = null;
            if (shoppingBagId == 0)
            {
                //Check if there is a shopping bag. If not create one and register it in the DB
                shoppingBag = new ShoppingBag();
                shoppingBag.CId = customerId;
                shoppingBag.SBDate = DateTime.Now.Date;

                AddShoppingBag(shoppingBag);

                shoppingBagId = FindLastShoppingBagId();
                shoppingBag.SBId = shoppingBagId;
                
            }

            //Here we add a shopping item and register it in the DB
            ShoppingItem shoppingItem = new ShoppingItem();

            shoppingItem.SBId = shoppingBagId;
            shoppingItem.PId = productId;
            shoppingItem.SIQuantity = quantity;
            shoppingItemRepository.Add(shoppingItem);

            // create a new view so that all information can be transfered to the view
            shoppingBagViewModel bag = new shoppingBagViewModel();
            bag.shoppingBag = shoppingBag;
            bag.shoppingItems.Add(shoppingItem);

            return bag;

            
        }

        //Calculation of subtotals

        public shoppingBagViewModel FindShoppingBagWithItems(int id)
        {
            shoppingBagViewModel bag = new shoppingBagViewModel();
            bag.shoppingBag = FindShoppingBagById(id); ;
            bag.shoppingItems = shoppingItemRepository.GetItemsPerShoppingBag(id);


            foreach (var item in bag.shoppingItems)
            {
                item.SISubTotal = item.SIQuantity * item.Product.PPrice;

            }

            bag.shoppingBag.SBTotalQuantity = bag.shoppingItems.Sum(sb => sb.SIQuantity);
            bag.shoppingBag.SBSubTotal = bag.shoppingItems.Sum(sb => sb.SISubTotal);


            //Calculation of the discount but only if items are higher then 2 => 5% or higher then 5 => 10%  
            

            if (bag.shoppingBag.SBTotalQuantity > 5)
            {
                bag.shoppingBag.SBDiscountPct = 10;
                bag.shoppingBag.SBDiscount = bag.shoppingBag.SBSubTotal* bag.shoppingBag.SBDiscountPct / 100;
                bag.shoppingBag.SBTotal = bag.shoppingBag.SBSubTotal - bag.shoppingBag.SBDiscount;
            }
            else
            {
                if (bag.shoppingBag.SBTotalQuantity > 2)
                {
                    bag.shoppingBag.SBDiscountPct = 5;
                    bag.shoppingBag.SBDiscount = bag.shoppingBag.SBSubTotal * bag.shoppingBag.SBDiscountPct / 100;
                    bag.shoppingBag.SBTotal = bag.shoppingBag.SBSubTotal - bag.shoppingBag.SBDiscount;


                }
                else 
                {
                    bag.shoppingBag.SBDiscount = 0;
                    bag.shoppingBag.SBTotal = bag.shoppingBag.SBSubTotal;
                }
               
            }

                


            return bag;
        }
        

    }
}
