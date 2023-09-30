using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Transactions;

namespace Lab2
{
    class Customer
    {
        // Fields
        private string _name;
        private string _password;
        private List<Product> _shoppingCart;

        //Constructor to initialize Name, Password, and ShoppingCart
        public Customer(string name, string password)
        {
            _name = name;
            _password = password;
            _shoppingCart = new List<Product>();
        }

        // Properties
        public string Name { get { return _name; } private set { _name = value; } }
        public string Password { get { return _password; } private set { _password = value; } }
        public List<Product> ShoppingCart { get {  return _shoppingCart; } }

        // Method to add a product to the shopping cart
        public void AddToCart(Product product)
        {
            _shoppingCart.Add(product);
            
        }
        // Method to clear cart of items (After checkout).
        public void ClearCart()
        {
            _shoppingCart.Clear();
            
        }
        // Method to remove from cart. Not Implemented.
        public void RemoveFromCart(Product product)
        {
            _shoppingCart.Remove(product);
        }

        // Method to calculate the sum total of items in the cart
        public virtual double CalculateTotal()
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
    }
}