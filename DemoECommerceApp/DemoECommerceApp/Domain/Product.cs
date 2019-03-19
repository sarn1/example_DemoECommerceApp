﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoECommerceApp.Domain
{
    public class Product
    {
        public Product(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
