﻿using Lab2_2;
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

            //Dont forget to change how the memebership level is set. If everyone is bronze then what is the point of having a level?..  
        }
    }
}