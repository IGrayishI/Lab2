using System.ComponentModel.Design;
using System.IO.Pipes;
using System.Runtime.InteropServices;

namespace Lab2_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StoreFront Menu          = new StoreFront();
            List<Customer> customers = new List<Customer>();
            List<Product> products   = Storage.Inventory();
            string username          = "user";
            bool isLoopRunning = true;

            while (isLoopRunning)
            {
                // Display the main menu with options for registration and login
                Console.WriteLine("Welcome to the Super Simple Store.\nDo you want to Login or Register?\n1. Login\n2.Register");

                // Handle user's choice (register or login)
                string userInput    = Console.ReadLine();
                int isNumber        = 0;
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
                            Customer findPassword = customers.FirstOrDefault(Customer => Customer.Password == password);
                            
                            if (findPassword != null)
                            {
                                // If successful, allow the user to shop, view cart, or check out
                                Menu.Run();
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid password");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Username is not registered.");
                        }
                        

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