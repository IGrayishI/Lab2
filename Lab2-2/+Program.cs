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

            //The original thought was to save the sum of each purchase in a double, and upgrade the users membership based on score. But, life got in the way.
            //I omited the desired customers from the savefile, incase it breaks on download. 
            //They are hardcoded at the top in the StartMenu.
        }
    }
}