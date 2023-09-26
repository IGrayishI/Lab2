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
        public static void Run(Customer user)
        {
            int id = 0;
            
            while (id != 4)
            {
                Console.Clear();
                Console.WriteLine($"Welcome! What would you like to do? " +
                                $"\n1. Shop " +
                                $"\n2. Check Cart " +
                                $"\n3. Go to checkout" +
                                $"\n4. Quit");

                //Calls Storage.Inventory to instantiate the products list in this class.
                string userInput = Console.ReadLine();
                int.TryParse(userInput, out id);

                switch (id)
                {
                    case 1:
                        ShopMenu.Shop(user);
                        break;
                    case 2:
                        Console.WriteLine(user.ToString());
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.WriteLine(user.CalculateTotal());
                        Console.ReadKey();
                        break;
                }
            }
        }

        //Menu where the user can add products to the cart
        public static void Shop(Customer user)
        {
            int id = 0;
            while (id != 5)
            {
                List<Product> products = Storage.Inventory();
                
                Console.WriteLine($"What do you want to buy? " +
                $"\n1. {products[0].Name}" +
                $"\n2. {products[1].Name}" +
                $"\n3. {products[2].Name}" +
                $"\n4. {products[3].Name}" +
                $"\n5. Quit.");

                string userInput = Console.ReadLine();
                int.TryParse(userInput, out id);

                switch (id)
                {
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
                    case 5:
                        continue;
                }
            }    
        }
    }
}
