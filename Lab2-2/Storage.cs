using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_2
{
    static class Storage
    {
        static public List<Product> Inventory()
        {
            List<Product> products = new List<Product>();
            products.Add(new Product("Can of Beans", 23.50));
            products.Add(new Product("Olive Oil", 24.99));
            products.Add(new Product("Paprika", 14.99));
            products.Add(new Product("Garlic", 6));

            return new List<Product>(products); // Returns a copy instead of the original list to hinder tampering, well in theory at least.
        }
    }
}