using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class StoreFront
    {

        public void Run(Customer user)
        {
            
            

            Console.WriteLine($"Welcome! What would you like to do? " +
                $"\n1. Shop " +
                $"\n2. Check Cart " +
                $"\n3. Go to checkout");

            //Calls Storage.Inventory to instansiate the product list in this class.
            List<Product> products = Storage.Inventory();

            string userInput = Console.ReadLine();

            int.TryParse(userInput, out int id);


            switch (id)
            {
                case 1:
                    while (id != 5)
                    {
                        Console.WriteLine($"What do you want to buy? " +
                        $"\n1. {products[0].Name}" +
                        $"\n2. {products[1].Name}" +
                        $"\n3. {products[2].Name}" +
                        $"\n4. {products[3].Name}" +
                        $"\n5. Quit.");
                        userInput = Console.ReadLine();
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
                                break;
                        }

                    }
                    break;
                case 2:
                    user.DisplayCart();
                    break;
                case 3:
                    
                    break;
               
            }

        }
    }
}
