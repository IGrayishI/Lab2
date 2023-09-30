using Lab2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab2_2
{
internal class Member : Lab2.Customer
    {
        public enum Membership
        {
            Gold = 15,
            Silver = 10,
            Bronze = 5,
        }

        //Fields
        private Membership _level;

        //Constructor
        public Member(string name, string password, Membership level)
            : base(name, password)
        {
            _level = level;
        }

        //Properties
        public Membership Level { get { return _level; } set { _level = value; } }

        //Methods

        //ToString method to overide and display Member information
        public override string ToString()
        {
            //Customize this method to display customer information in a nice way
            return $"Member Name: {Name} \nPassword: {Password} \nYour membership is: {_level} with a discount of {(int)_level}%";
        }

        //Displays the cart with the sum total.
        public void DisplayCart()
        {
            Dictionary<string, int> itemCounts = new Dictionary<string, int>();
            Dictionary<string, double> itemCosts = new Dictionary<string, double>();
            double totalCost = 0;

            //Calculates the number of items in the cart, and saves count and total cost.
            foreach (Product product in ShoppingCart)
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

                Console.WriteLine($"{productName}: {count} * {groupCost / count} = {groupCost} SEK");
                Console.WriteLine("---------------------------");
            }
            
            totalCost = PaymentHelper.ChoiceOfCurrency(totalCost);

            double discount = ((int)_level) / 100.0;
            double sumWithDiscount = totalCost - (totalCost * discount);

            Console.WriteLine($"Total cost: {Math.Round(totalCost, 2)}");
            Console.WriteLine($"Total cost with membership: {Math.Round(sumWithDiscount, 2)}");
            Console.WriteLine("Press Enter to Continue.");
            Console.ReadKey();
        }

        public override double CalculateTotal()
        {
            double totalCost = base.CalculateTotal();
            double discount = ((int)_level) / 100.0;
            double sumWithDiscount = totalCost - (totalCost * discount);
            sumWithDiscount = PaymentHelper.ChoiceOfCurrency(sumWithDiscount);
            return sumWithDiscount;
        }
    }
}
