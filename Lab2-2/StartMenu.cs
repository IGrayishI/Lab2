using Lab2;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_2
{
    internal static class StartMenu
    {
        public static void Run()
        {
            // Create a list to store Customer objects
            List<Member> customers = new List<Member>();

            StartMenu.LoadFile(customers);

            StartMenu.Menu(customers);

        }
        //----------------Methods---------------
        
        //Register new customers and adding them to the save file.
        static void Register(List<Member> customers)
        {
            // Prompt for customer name and password
            Console.Write("Please enter your desired username: ");
            string username = Console.ReadLine();

            Console.Write("Please enter your desired password: ");
            string password = Console.ReadLine();

            // Create a new customer object and add it to the customers list
            Member.Membership level = Member.Membership.Bronze;
            Member newCustomer = new Member(username, password, level );                     ////Kolla här senare
            customers.Add(newCustomer);

            string dataToSave = "CustomerList.txt";
            File.AppendAllText(dataToSave, $"{username},{password},{level}\n");
        }
        
        //Loading the customers from the save file.
        public static void LoadFile(List<Member> customers)
        {
            // Read the contents of the file
            string readText = File.ReadAllText("CustomerList.file");

            //Split the text into lines
            string[] lines = readText.Split('\n');

            foreach (string line in lines)
            {
                // Split each line into username and password (assuming they are separated by a space)
                string[] parts = line.Trim().Split(",");

                if (parts.Length == 3)
                {
                    // Create a new Customer object and add it to the list
                    customers.Add(new Member(parts[0], parts[1], parts[3]));
                }
            }
        }

        //Start menu
        static public void Menu(List<Member> customers)
        {
            string username;
            bool isLoopRunning = true;

            while (isLoopRunning)
            {
                Console.Clear();
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
                        Member findUsername = customers.FirstOrDefault(Customer => Customer.Name == username);

                        if (findUsername != null)
                        {
                            Console.Clear();
                            Console.Write("Please enter your password: ");
                            string password = Console.ReadLine();

                            // Verify the password
                            if (findUsername.Password == password)
                            {
                                Console.Clear();
                                Lab2.Member user = new Lab2.Member(username, password);
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
                        else // Ask the user if they would like to register.
                        {
                            Console.Clear();
                            Console.WriteLine("Username is not registered. \nWould you like to register? y/n");
                        }

                    }
                    else if (isNumber == 2/* User chooses to register */)
                    {
                        Console.Clear();
                        Register(customers);
                    }
                    else if (isNumber == 3/* User chooses to quit */ )
                    {
                        Console.Clear();
                        isLoopRunning = false;
                        Console.WriteLine("Thanks for visiting us!");
                    }
                }
                // Invalid choice, display an error message
                else
                {
                    Console.Clear();
                    Console.WriteLine("Please enter a valid number.");
                }
            }
        }

    }
}