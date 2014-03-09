namespace IntroToProgramming
{
    using System;

    // Task 14*: Create a console application that prints the current date and time. 
    public class PrintCurrentDateTime
    {
        public static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Today is: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(DateTime.Now);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}