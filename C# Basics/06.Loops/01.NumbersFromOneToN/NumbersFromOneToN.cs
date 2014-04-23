namespace Loops
{
    using System;

    /// <summary>
    /// Task 1: Write a program that enters from the console a positive integer n and prints all 
    ///         the numbers from 1 to n, on a single line, separated by a space.
    /// </summary>
    public class NumbersFromOneToN
    {
        public static void Main()
        {
            Console.Title = "Prints all numbers from 1 to N";
            uint upperBoundary = EnterData("Please enter the upper boundary of the range to print: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Result = ");
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 1; i <= upperBoundary; i++)
            {
                Console.Write(i + " ");
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.ReadKey();
        }

        private static uint EnterData(string message)
        {
            bool isValidInput;
            uint enteredValue;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(message);
                Console.ForegroundColor = ConsoleColor.Yellow;
                isValidInput = uint.TryParse(Console.ReadLine(), out enteredValue);
                if (isValidInput && enteredValue > 0)
                {
                    continue;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You have entered invalid number! Try again <press any key...>");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                Console.Clear();
                isValidInput = false;
            }
            while (!isValidInput);

            Console.ForegroundColor = ConsoleColor.White;
            return enteredValue;
        }
    }
}