namespace Loops
{
    using System;

    /// <summary>
    /// Task 9: Write a program that reads from the console a positive integer 
    ///         number n (1 ≤ n ≤ 20) and prints a matrix like in the examples below. 
    ///         Use two nested loops. 
    /// </summary>
    public class MatrixOfNumbers
    {
        public static void Main()
        {
            Console.Title = "Print a matrix";
            byte numberN = EnterData("Enter upper border of sequence [1..20] = ");
            Console.ForegroundColor = ConsoleColor.Green;
            for (int count = 1; count <= numberN; count++)
            {
                for (int k = count; k <= (count + numberN - 1); k++)
                {
                    Console.Write("{0,3}", k);
                }

                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }

        private static byte EnterData(string message)
        {
            bool isValidInput;
            byte enteredValue;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(message);
                Console.ForegroundColor = ConsoleColor.Yellow;
                isValidInput = byte.TryParse(Console.ReadLine(), out enteredValue);
                if (isValidInput && (enteredValue >= 1) && (enteredValue <= 20))
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