﻿namespace IntroToProgramming
{
    using System;

    // Task 10: Reformat the following C# code to make it readable according to the C# best practices for 
    //          code formatting. Change the casing of the identifiers in the code (e.g. use PascalCase for 
    //          the class name).
    public class HorribleCode
    {
        public static void Main()
        {
            Console.WriteLine("Hi, I am horribly formatted program");
            Console.WriteLine("Numbers and squares:");
            for (int index = 0; index < 10; index++)
            {
                Console.WriteLine(index + " --> " + (index * index));
            }
        }
    }
}