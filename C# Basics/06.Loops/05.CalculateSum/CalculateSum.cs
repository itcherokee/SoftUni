namespace Loops
{
    using System;

    /// <summary>
    /// Task 5: Write a program that, for a given two integer numbers n and x, calculates the sum 
    ///         S = 1 + 1!/x + 2!/x^2 + … + n!/x^n. Use only one loop. 
    ///         Print the result with 5 digits after the decimal point.
    /// </summary>
    public class CalculateSum
    {
        public static void Main()
        {
            Console.Title = "Calculate the sum of expression S = 1 + 1!/X + 2!/X" + '\u00B2' + "+ … + N!/X" + '\x1DB0';
            int numberN = EnterData('N', true);
            int numberX = EnterData('X', false);
            decimal resultSum = 1m;
            decimal power = 1;
            for (int count = 1; count <= numberN; count++)
            {
                power *= numberX;
                resultSum += Factorial(count) / power;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Sum of expresion is: {0:F5}", resultSum);
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }

        private static int Factorial(int upperNumber)
        {
            int factorialResult = 1;
            for (int count = 1; count <= upperNumber; count++)
            {
                factorialResult *= count;
            }

            return factorialResult;
        }

        private static int EnterData(char numberName, bool zeroAllowed)
        {
            bool isValidInput;
            int inputNumber;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Enter value for \"{0}\" = ", numberName);
                Console.ForegroundColor = ConsoleColor.Yellow;
                isValidInput = int.TryParse(Console.ReadLine(), out inputNumber);
                if (isValidInput && (inputNumber != 0 || zeroAllowed))
                {
                    continue;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("You have entered symbol(s){0}. Try again.", zeroAllowed ? string.Empty : " or number equal to 0", numberName);
                Console.ReadKey();
                Console.Clear();
                isValidInput = false;
            }
            while (!isValidInput);

            return inputNumber;
        }
    }
}