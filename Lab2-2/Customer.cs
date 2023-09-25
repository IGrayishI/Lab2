using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_2
{
    class Customer
    {
        public string Name { get; }
        private string _password { get; }
        public string Password { get { return _password; } }
        private List<Product> ShoppingCart { get; }

        // Constructor to initialize Name, Password, and ShoppingCart
        public Customer(string name, string password)
        {
            Name = name;
            _password = password;
            ShoppingCart = new List<Product>();
        }

        // Method to add a product to the shopping cart
        public void AddToCart(Product product)
        {
            ShoppingCart.Add(product);
        }

        // Method to calculate the sum total of items in the cart
        public double CalculateTotal()
        {
            double total = 0;
            foreach (Product product in ShoppingCart)
            {
                total += product.Price;
            }
            return total;
        }

        // Method to verify the password
        public bool VerifyPassword(string password)
        {
            return Password == password;
        }

        // ToString method to display customer information
        public override string ToString()
        {
            // Customize this method to display customer information in a nice way
            return $"Customer Name: {Name}\nTotal in Cart: {CalculateTotal():C}";
        }
    }
}
