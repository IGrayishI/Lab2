using Lab2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_2
{
    internal static class StartMenu
    {
        public static void Run()
        {
            StoreFront Menu = new StoreFront();
            List<Customer> customers = new List<Customer>();
            
            string username = "user";
            bool isLoopRunning = true;

            while (isLoopRunning)
            {
                // Display the main menu with options for registration and login
                Console.WriteLine("Welcome to the Super Simple Store.\nDo you want to Login or Register?\n1. Login\n2. Register");

                // Handle user's choice (register or login)
                string userInput = Console.ReadLine();
                int isNumber = 0;
                if (int.TryParse(userInput, out isNumber))
                {
                    if (isNumber == 2/* User chooses to register */)
                    {
                        // Prompt for customer name and password
                        Console.Write("Please enter your desired username: ");
                        username = Console.ReadLine();

                        Console.Write("Please enter your desired password: ");
                        string password = Console.ReadLine();

                        // Create a new customer object and add it to the customers list
                        Customer newCustomer = new Customer(username, password);
                        customers.Add(newCustomer);
                    }
                    else if (isNumber == 1/* User chooses to login */)
                    {
                        // Prompt for customer name and password
                        Console.Write("Please enter your username: ");
                        username = Console.ReadLine();
                        

                        // Find the customer in the customers list based on the name
                        Customer findUsername = customers.FirstOrDefault(Customer => Customer.Name == username);
                        
                        if (findUsername != null)
                        {
                            Console.Write("Please enter your password: ");
                            string password = Console.ReadLine();

                            // Verify the password
                            if (findUsername.Password == password)
                            {
                                Customer user = new Customer(username, password);
                                Menu.Run(user);
                                break;
                            }
                            else  
                            {
                                Console.WriteLine("Password invalid.");
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Username is not registered.");
                        }
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
                else
                {
                    // Invalid choice, display an error message
                    Console.WriteLine("Please enter a valid number.");
                    Console.Clear();
                }
            }
        }
    }
}
