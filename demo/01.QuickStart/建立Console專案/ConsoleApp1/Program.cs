﻿using Microsoft.Extensions.Hosting;
using System;

namespace ConsoleApp1
{
    public class Program
    {
        // Methods
        public static void Run()
        {  
            // Display
            Console.WriteLine("Hello World");
        }

        public static void Main(string[] args)
        {
            // Host
            MDP.NetCore.Host.Create<Program>(args).Run();
        }
    }
}