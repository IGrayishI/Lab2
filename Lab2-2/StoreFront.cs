using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_2
{
    internal class StoreFront
    {
        public void Run()
        {
            Console.WriteLine($"Welcome! What would you like to do? " +
                $"\n1. Shop " +
                $"\n2. Check Cart " +
                $"\n3. Go to checkout"); 

            string userInput = Console.ReadLine();

            int.TryParse( userInput, out int id );

            switch ( id )
            {
               case 1:
                    Console.WriteLine($"What do you want to buy? " +
                        $"\n1. " +
                        $"\n2. " +
                        $"\n3. " +
                        $"\n4. " +
                        $"\n5. ");
                    break;

            }

        }
    }
}
