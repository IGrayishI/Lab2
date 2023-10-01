using Lab2_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal static class ShopMenu
    {
        public static void Run(Member user)
        {
            int id = 0;
            
            while (id != 5)
            {
                Console.WriteLine($"Welcome! What would you like to do? " +
                                $"\n1. Shop." +
                                $"\n2. Check Cart." +
                                $"\n3. Go to checkout." +
                                $"\n4. Display user information." +
                                $"\n5. Back.");
                
                string userInput = Console.ReadLine();
                int.TryParse(userInput, out id);

                Console.Clear();
                switch (id)
                {
                    case 1:
                        //Sends the user to the shop
                        ShopMenu.Shop(user);
                        break;
                        //Displays the cart, and sum total.
                    case 2:
                        user.DisplayCart();
                        Console.Clear();
                        break;
                        //Displays the checkout, clears the cart if correct password is input.
                    case 3:
                        Console.WriteLine($"The sum total is: {user.CalculateTotal()}");
                        Console.Write("Please enter your password to confirm, or 1 to go back " +
                                    "\nPassword: ");
                        
                        while (userInput != "1")
                        {
                            userInput = Console.ReadLine();
                            Console.Clear();
                            if (userInput == user.Password)
                            {
                                Console.WriteLine("Thank you for your purchase.");
                                user.ClearCart();
                                Console.ReadKey();
                                break;
                            }
                            else if (userInput == "1")
                            {
                                break;
                            }else
                            {
                                Console.WriteLine("invalid password");
                                Console.Write("Please enter your password to confirm, or 1 to go back " +
                                            "\nPassword: ");
                            }
                        }
                        //End of case 3.
                        break;

                        //Displays the user information
                    case 4:
                        Console.WriteLine(user.ToString());
                        Console.WriteLine("Press enter to Continue.");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                        //Returns to StartMenu
                    case 5:
                        Console.Clear();
                        break;
                }
            }
        }

        //Menu where the user can add products to the cart
        public static void Shop(Customer user)
        {
            //Creates the method inventory to instantiate the items.
            static List<Product> Inventory()
            {
                List<Product> products = new List<Product>();
                products.Add(new Product("Can of Beans", 23.50));
                products.Add(new Product("Olive Oil", 24.99));
                products.Add(new Product("Paprika", 14.99));
                products.Add(new Product("Garlic", 6));

                return new List<Product>(products); // Returns a copy instead of the original list to hinder tampering, well in theory at least.
                                                    // (This was in its own class before, but it seemed redundant)
            }
                //Calls Inventory to instantiate the products list in this class.
                List<Product> products = Inventory();

            int id = 1;
            while (id != 0)
            {
                Console.Clear();

                
                Console.WriteLine($"What do you want to buy? ");
                Console.WriteLine("0. Quit");

                //Writes out all items in the products list.
                for (int i = 0; i < products.Count; i++)
                {
                    Console.WriteLine(i + 1 + ". " + products[i].Name + ": " + products[i].Price);
                }

                //Takes users input and trys if its a number.
                string userInput = Console.ReadLine();
                int.TryParse(userInput, out id);

                switch (id)
                {
                    case 0:
                        break;
                    case 1:
                        user.AddToCart(products[0]);
                        break;
                    case 2:
                        user.AddToCart(products[1]);
                        break;
                    case 3:
                        user.AddToCart(products[2]);
                        break;
                    case 4:
                        user.AddToCart(products[3]);
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        Console.ReadKey();
                        break;
                }
                Console.Clear();
            }
        }
    }
}