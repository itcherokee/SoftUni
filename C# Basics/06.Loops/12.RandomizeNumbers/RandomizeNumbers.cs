namespace Loops
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Task 12: Write a program that enters an integer n and prints the numbers 1, 2, …, n in random order.
    /// </summary>
    public class RandomizeNumbers
    {
        private static readonly Random Generator = new Random();

        public static void Main()
        {
            Console.Title = "Randomize numbers in range 1..n";
            int upperBorder = EnterData("Enter upper border of sequence: ");
            var sequence = new List<int>(Enumerable.Range(1, upperBorder));
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Randomized sequence: ");
            Console.ForegroundColor = ConsoleColor.Green;
            while (sequence.Count != 0)
            {
                var index = Generator.Next(0, sequence.Count);
                Console.Write(sequence[index]);
                if (sequence.Count > 1)
                {
                    Console.Write(" ");
                }

                sequence.RemoveAt(index);
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
                if (isValidInput && enteredValue > 1)
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
