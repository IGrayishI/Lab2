using Lab2;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lab2_2.Member;

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

            string dataToSave = "C:\\Users\\Benja\\source\\repos\\Lab2-2\\Lab2-2\\CustomerList.txt";
            File.AppendAllText(dataToSave, $"{username},{password},{level}\n");
        }
        
        //Loading the customers from the save file.
        public static void LoadFile(List<Member> customers)
        {
            // Read the contents of the file
            string readText = File.ReadAllText("C:\\Users\\Benja\\source\\repos\\Lab2-2\\Lab2-2\\CustomerList.txt");

            //Split the text into lines
            string[] lines = readText.Split('\n');

            foreach (string line in lines)
            {
                // Split each line into username and password (assuming they are separated by a space)
                string[] parts = line.Trim().Split(",");

                if (parts.Length == 3)
                {
                    // Create a new Customer object and add it to the list
                    Member.Membership membership;
                    if (Enum.TryParse(parts[2], out membership)) 
                    {
                    customers.Add(new Member(parts[0], parts[1], membership));
                    }
                    else
                    {
                        Console.WriteLine("Can not load savefile. Parse Error.");
                        Console.ReadKey();
                    }
                    
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
                    switch (isNumber)
                    {
                        case 1:
                        // Prompt for customer name and password
                        Console.Clear();
                        Console.Write("Please enter your username: ");
                        username = Console.ReadLine();

                        // Find the customer in the customers list based on the name
                        Member findUsername = customers.FirstOrDefault(Member => Member.Name == username);

                        //if found.
                        if (findUsername != null)
                        {
                            Console.Clear();
                            Console.Write("Please enter your password: ");
                            string password = Console.ReadLine();

                            // Verify the password
                            if (findUsername.Password == password)
                            {
                                Console.Clear();
                                Member user = new Member(username, password, findUsername.Level);
                                ShopMenu.Run(user);
                                break;
                            }else
                            {
                                Console.Clear();
                                Console.WriteLine("Password invalid.");
                                break;
                            }
                        }else // Ask the user if they would like to register.
                        {
                        Console.Clear();
                        Console.WriteLine("Username is not registered. \nWould you like to register? y/n");
                        userInput = Console.ReadLine();
                                if (userInput == "y")
                                {
                                Register(customers);
                                }
                        }
                            break;

                        case 2:
                        Console.Clear();
                        Register(customers);
                            break;

                        case 3:
                        Console.Clear();
                        isLoopRunning = false;
                        Console.WriteLine("Thanks for visiting us!");
                            break;
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