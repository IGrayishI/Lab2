﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Product
    {
        //Fields
        private string _name;
        private double _price;
        
        //Constructor
        public Product(string name, double price)
        {
            _name = name;
            _price = price;
        }

        //Properties
        public string Name { get { return _name; } set { _name = value; } }
        public double Price { get { return _price; } set { _price = value; } }

    }
}