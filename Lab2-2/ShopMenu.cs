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
                        ShopMenu.Shop(user);
                        break;
                    case 2:
                        user.DisplayCart();
                        Console.Clear();
                        break;
                        
                    case 3:
                        Console.WriteLine($"The sum total is: {user.CalculateTotal()}");
                        Console.Write("Please enter your password to confirm, or 1 to go back \nPassword: ");
                        
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
                            } 
                            else
                            {
                                Console.WriteLine("invalid password");
                                Console.Write("Please enter your password to confirm, or 1 to go back \nPassword: ");
                            }
                        }
                        break;
                    case 4:
                        Console.WriteLine(user.ToString());
                        Console.WriteLine("Press enter to Continue.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 5:
                        StartMenu.Run();
                        Console.Clear();
                        break;
                }
            }
        }

        //Menu where the user can add products to the cart
        public static void Shop(Customer user)
        {
            int id = 1;
            while (id != 0)
            {
                Console.Clear();
                //Calls Storage.Inventory to instantiate the products list in this class.
                List<Product> products = Storage.Inventory();

                
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