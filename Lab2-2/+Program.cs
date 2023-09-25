using Lab2_2;
using System.ComponentModel.Design;
using System.IO.Pipes;
using System.Runtime.InteropServices;

namespace Lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StartMenu.Run();

            //Avslutade på StoreFront case 2-3
            //StartMenu (Login och register är nästan klar. behöver bara ändra så att man blir promptad att registrera sig om man skriver ett användarnamn som inte finns.
            //och instansiera kunderna som ska finnas.
        }
    }
}