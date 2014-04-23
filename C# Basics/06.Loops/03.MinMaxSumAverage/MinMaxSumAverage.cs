namespace Loops
{
    using System;

    /// <summary>
    /// Task 3: Write a program that reads from the console a sequence of n integer numbers and returns 
    ///         the minimal, the maximal number, the sum and the average of all numbers (displayed with 
    ///         2 digits after the decimal point). The input starts by the number n (alone in a line) 
    ///         followed by n lines, each holding an integer number. The output is like in the examples below. 
    /// </summary>
    public class MinMaxSumAverage
    {
        public static void Main()
        {
            Console.Title = "Find Minimal & Maximal number in sequence";
            int count = EnterData("Enter the count of integer sequence: ");
            int sum = 0;
            int min = int.MaxValue;
            int max = int.MinValue;
            for (int index = 0; index < count; index++)
            {
                int number = EnterData("Number: ");

                // checks number does it smallest
                if (number < min)
                {
                    min = number;
                }

                // checks number does it biggest
                if (number > max)
                {
                    max = number;
                }

                // add to sum
                sum += number;
            }

            Print("Minimal number: ", min.ToString());
            Print("Maximal number: ", max.ToString());
            Print("Sum of all numbers: ", sum.ToString());
            Print("Average of all numbers: ", (sum / (float)count).ToString("F2"));
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }

        private static void Print(string message, string value)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(message);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(value);
        }

        private static int EnterData(string message)
        {
            bool isValidInput;
            int enteredValue;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(message);
                Console.ForegroundColor = ConsoleColor.Yellow;
                isValidInput = int.TryParse(Console.ReadLine(), out enteredValue);
                if (isValidInput || enteredValue >= 1)
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