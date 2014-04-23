namespace Loops
{
    using System;
    using System.Numerics;

    /// <summary>
    /// Task 7: In combinatorics, the number of ways to choose k different members out of a group 
    ///         of n different elements (also known as the number of combinations) is calculated 
    ///         by the following formula: n!/(k!(n-k)!)
    ///         For example, there are 2598960 ways to withdraw 5 cards out of a standard deck 
    ///         of 52 cards. Your task is to write a program that calculates n! / (k! * (n-k)!) 
    ///         for given n and k (1 < k < n < 100). Try to use only two loops.
    /// </summary>
    public class FactorialDivision
    {
        public static void Main()
        {
            Console.Title = "Calculate n!/(k!(n-k)!)";
            Console.WriteLine("Enter value for N and K considering following restriction (1 < k < n < 100)");
            int numberN = EnterData("N = ");
            int numberK = EnterData("K = ");
            if (numberK <= 1 || numberN <= numberK || numberN >= 100)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You have violated the restriction (1<K<N<100).\nProgram will exit now!");
                return;
            }

            // n! / (k! * (n-k)!)
            BigInteger result = Factorial(numberN) / (Factorial(numberK) * Factorial(numberN - numberK));
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Result is: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(result);
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }

        // Calculates Factorial using recursion
        private static BigInteger Factorial(int upperNumber)
        {
            BigInteger factorialResult = 1;
            for (int count = 1; count <= upperNumber; count++)
            {
                factorialResult *= count;
            }

            return factorialResult;
        }

        // Input of user data
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