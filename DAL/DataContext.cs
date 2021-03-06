﻿using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        // not part of exercice, created in video tutorial
        public DbSet<User> Users { get; set; }

        //Define the models you want to persist in the DB
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ShoppingBag> ShoppingBags { get; set; }
        public DbSet<ShoppingItem> ShoppingItems { get; set; }
        public DbSet<Product> Products { get; set; }



    }
}
