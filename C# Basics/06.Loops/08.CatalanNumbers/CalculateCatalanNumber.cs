namespace Loops
{
    using System;
    using System.Numerics;

    /// <summary>
    /// Task 8: Write a program to calculate the nth Catalan number by given n (1 < n < 100).
    /// </summary>
    public class CalculateCatalanNumber
    {
        public static void Main()
        {
            Console.Title = "Calculate n-th Catalan number";
            int numberN = EnterData("Enter the n-th member from Catalan numbers to calculate it. N=");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("The N-th Catalan number is: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Factorial(2 * numberN) / (Factorial(numberN + 1) * Factorial(numberN)));
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }

        // Calculating Factorial using recursion
        private static BigInteger Factorial(BigInteger upperNumber)
        {
            BigInteger factorialResult = 1;
            for (int count = 1; count <= upperNumber; count++)
            {
                factorialResult *= count;
            }

            return factorialResult;
        }

        // User data input
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