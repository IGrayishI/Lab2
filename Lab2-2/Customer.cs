using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Customer
    {
        //fields
        private string _name;
        private string _password;
        private List<Product> _shoppingCart;

        // Constructor to initialize Name, Password, and ShoppingCart
        public Customer(string name, string password)
        {
            _name = name;
            _password = password;
            _shoppingCart = new List<Product>();
        }

        //properties
        public string Name { get { return _name; } set { _name = value; } }
        public string Password { get { return _password; } set { _name = value; } }
        


        // Method to add a product to the shopping cart
        public void AddToCart(Product product)
        {
            _shoppingCart.Add(product);
        }

        // Method to calculate the sum total of items in the cart
        public double CalculateTotal()
        {
            double total = 0;
            foreach (Product product in _shoppingCart)
            {
                total += product.Price;
            }
            return Math.Round(total, 2);
        }

        // Method to verify the password
        public bool VerifyPassword(string password)
        {
            return Password == password;
        }

        // ToString method to display customer information
        public override string ToString()
        {
            //Going to add a password clarification before clearing the cart.
            // Customize this method to display customer information in a nice way
            foreach (Product product in _shoppingCart)
            {
                Console.WriteLine(product.Name);
            }
            return $"Customer Name: {Name} \nTotal in Cart: {Math.Round(CalculateTotal(), 2):C}";
        }

        public void DisplayCart()
        {
            foreach (Product product in _shoppingCart)
            {
                Console.WriteLine(product);
            }
            Console.ReadKey();
        }
    }
}
