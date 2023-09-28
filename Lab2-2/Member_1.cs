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
    class Member
    {
        // Fields
        private string _name;
        private string _password;
        private List<Product> _shoppingCart;

        //Constructor to initialize Name, Password, and ShoppingCart
        public Member(string name, string password)
        {
            _name = name;
            _password = password;
            _shoppingCart = new List<Product>();
        }

        // Properties
        public string Name { get { return _name; } private set { _name = value; } }
        public string Password { get { return _password; } private set { _password = value; } }

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
        // Method to remove from cart.
        public void RemoveFromCart(Product product)
        {
            _shoppingCart.Remove(product);
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
            //Customize this method to display customer information in a nice way
            
            return $"Customer Name: {_name} \nPassword: {_password}";
        }

        public void DisplayCart()
        {
            Dictionary<string, int> itemCounts = new Dictionary<string, int>();
            Dictionary<string, double> itemCosts = new Dictionary<string, double>();
            double totalCost = 0;

            foreach (Product product in _shoppingCart)
            {
                double productPrice = product.Price;
                string productName = product.Name;

                if (itemCounts.ContainsKey(productName))
                {
                    itemCounts[productName]++;
                    itemCosts[productName] += productPrice;
                }
                else
                {
                    itemCounts[productName] = 1;
                    itemCosts[productName] = productPrice;
                }
                totalCost += productPrice;
            }

            Console.WriteLine("Items in your cart:");
            foreach (var kvp in itemCounts)
            {
                string productName = kvp.Key;
                int count = kvp.Value;
                double groupCost = itemCosts[productName];
                
                Console.WriteLine($"{productName}: {count} * {groupCost / count} = {groupCost}");
                Console.WriteLine("---------------------------");
                
            }
            Console.WriteLine($"Total cost: {Math.Round(totalCost, 2)}");
            Console.WriteLine("Press Enter to Continue.");
            Console.ReadKey();

            Console.Clear();
        }

    }
}