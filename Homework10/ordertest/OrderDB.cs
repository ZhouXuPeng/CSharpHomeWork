﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ordertest
{

    public class OrderDB : DbContext
    {

        public OrderDB() : base("OrderDataBase") { }

        public DbSet<Order> Order { get; set; }
        //public DbSet<OrderDetail> OrderDetail { get; set; }
        //public DbSet<Customer> Customer { get; set; }
        //public DbSet<Goods> Goods { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
    }

}