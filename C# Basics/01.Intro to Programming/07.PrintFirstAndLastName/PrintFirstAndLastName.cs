namespace IntroToProgramming
{
    using System;

    // Task 7:  Create console application that prints your first and last name, each at a separate line.
    public class PrintFirstAndLastName
    {
        public static void Main()
        {
            const string FirstName = "Madona";
            const string SecondName = "Madonova";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("First name: {0}\nSecond name: {1}", FirstName, SecondName);
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }
    }
}