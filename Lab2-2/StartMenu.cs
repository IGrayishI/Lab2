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
            string dataRead = File.ReadAllText("data.txt");
            Console.WriteLine("Data read from the file: " + dataRead);

            List<Customer> customers = new List<Customer>();

            Customer knatte = new("Knatte", "123");
            Customer fnatte = new("Fnatte", "321");
            Customer tjatte = new("Tjatte", "213");

            customers.Add(knatte);
            customers.Add(fnatte);
            customers.Add(tjatte);

            string username;
            bool isLoopRunning = true;


            while (isLoopRunning)
            {
                // Display the main menu with options for registration and login
                Console.WriteLine("Welcome to the Super Simple Store.\nDo you want to Login or Register?\n1. Login\n2. Register \n3. Quit");

                // Handle user's choice (register or login)
                string userInput = Console.ReadLine();
                int isNumber = 0;
                if (int.TryParse(userInput, out isNumber))
                {
                    if (isNumber == 1/* User chooses to login */)
                    {
                        Console.Clear();
                        // Prompt for customer name and password
                        Console.Write("Please enter your username: ");
                        username = Console.ReadLine();
                        
                        // Find the customer in the customers list based on the name
                        Customer findUsername = customers.FirstOrDefault(Customer => Customer.Name == username);

                        if (findUsername != null)
                        {
                            Console.Clear();
                            Console.Write("Please enter your password: ");
                            string password = Console.ReadLine();

                            // Verify the password
                            if (findUsername.Password == password)
                            {
                                Console.Clear();
                                Customer user = new Customer(username, password);
                                ShopMenu.Run(user);
                                break;
                            }
                            else  
                            {
                                Console.Clear();
                                Console.WriteLine("Password invalid.");
                                break;
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Username is not registered.");
                        }
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else if (isNumber == 2/* User chooses to register */)
                    {
                        Register(customers);
                        Console.Clear();
                    }
                    else if (isNumber == 3/* User chooses to quit */ )
                    {
                        isLoopRunning = false;
                        Console.WriteLine("Thanks for visiting us!");
                    }
                }
                // Invalid choice, display an error message
                else
                {
                    Console.WriteLine("Please enter a valid number.");
                    Console.Clear();
                }
            }
            
            static void Register(List<Customer> customers)
            {
                // Prompt for customer name and password
                Console.Write("Please enter your desired username: ");
                string username = Console.ReadLine();

                Console.Write("Please enter your desired password: ");
                string password = Console.ReadLine();

                // Create a new customer object and add it to the customers list
                Customer newCustomer = new Customer(username, password);
                customers.Add(newCustomer);

                string dataToSave = Convert.ToString(newCustomer);
                File.WriteAllText("data.txt", dataToSave);
            }
        }
    }
}
