namespace Loops
{
    using System;

    /// <summary>
    /// Task 11: Write a program that enters 3 integers n, min and max (min ≤ max) 
    ///          and prints n random numbers in the range [min...max]. 
    /// </summary>
    public class RandomNumbersInRange
    {
        private static readonly Random Generator = new Random();

        public static void Main()
        {
            Console.Title = "Print random numbers in range";
            int count = EnterData("Hom many numbers will be generated (n): ");
            int lowerBorder = EnterData("Enter the lower border of range (min): ");
            int upperBorder = EnterData("Enter the upper border of range (max): ");
            if (lowerBorder > upperBorder)
            {
                // switch borders if value of lower is bigger than upper one
                lowerBorder ^= upperBorder;
                upperBorder = lowerBorder ^ upperBorder;
                lowerBorder ^= upperBorder;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Generated numbers: ");
            Console.ForegroundColor = ConsoleColor.Green;
            for (int index = 0; index < count; index++)
            {
                Console.Write(Generator.Next(lowerBorder, upperBorder + 1));
                if (index < count - 1)
                {
                    Console.Write(" ");
                }
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
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
                if (isValidInput)
                {
                    continue;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You have entered invalid number! Try again <press any key...>");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                Console.Clear();
            }
            while (!isValidInput);

            Console.ForegroundColor = ConsoleColor.White;
            return enteredValue;
        }
    }
}
