using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_2
{
    internal static class PaymentHelper
    {
        enum exchangeRate
        {
            SEK,
            USD,
            EUR
        }

        //Methods

        //Convert price from sek to USD
        public static double sekToUSD(double sumToConvert)
        {
            double sumInUSD = Math.Round((sumToConvert / 11.03), 2);
            return sumInUSD;
        }

        //Convert price from sek to EUR
        public static double sekToEUR(double sumToConvert)
        {
            double SumInEUR = Math.Round((sumToConvert / 11.9749), 2);
            return SumInEUR;
        }

        //Asks what currency the user would prefer and converts accordingly.
        public static double ChoiceOfCurrency( double totalCostInSEK)
        {
            Console.WriteLine("In what currency would you prefer? \n0. SEK (Default) \n1. EUR \n2. USD");
            string userInput = Console.ReadLine();
            int.TryParse(userInput, out int id);

            switch (id)
            {
                case 1:
                    double totalCostInEUR = sekToEUR(totalCostInSEK); 
                    return totalCostInEUR;
                case 2:
                    double totalCostInUSD = sekToUSD(totalCostInSEK);
                    return totalCostInUSD;
                default : return totalCostInSEK;
            }
        }
    }
}
