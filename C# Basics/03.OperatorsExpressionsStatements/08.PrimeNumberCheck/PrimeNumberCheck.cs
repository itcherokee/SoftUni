namespace OperatorsExpressionsStatements
{
    using System;

    /// <summary>
    /// Task 8: Write an expression that checks if given positive integer number n (n ≤ 100) 
    ///         is prime (i.e. it is divisible without remainder only to itself and 1).
    /// </summary>
    public class PrimeNumberCheck
    {
        public static void Main()
        {
            Console.Title = "Checks a number does it prime";
            int numberEntered = EnterData("Please enter a positive number (n<=100) to check is it a prime: ");
            string result = string.Empty;
            Console.ForegroundColor = ConsoleColor.Red;
            if (numberEntered < 0)
            {
                result = "Negatine numbers can not be primes!.";
            }
            else if (numberEntered == 0 || numberEntered == 1)
            {
                result = "Number 0 and 1 are neighter primes nor complex.";
            }
            else if (IsPrime(numberEntered))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                result = "The number you have entered is a prime number!";
            }
            else
            {
                result = "This is not a prime number!";
            }

            Console.WriteLine(result);
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }

        private static bool IsPrime(int numberEntered)
        {
            if ((numberEntered & 1) == 0)
            {
                return numberEntered == 2;
            }

            for (int i = 3; (i * i) <= numberEntered; i += 2)
            {
                if ((numberEntered % i) == 0)
                {
                    return false;
                }
            }

            return numberEntered != 1;
        }

        private static int EnterData(string message)
        {
            bool isValidInput = default(bool);
            int enteredValue = default(int);
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(message);
                Console.ForegroundColor = ConsoleColor.Yellow;
                isValidInput = int.TryParse(Console.ReadLine(), out enteredValue);
                if (!isValidInput || enteredValue > 100)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You have entered invalid number! Try again <press any key...>");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            while (!isValidInput);

            Console.ForegroundColor = ConsoleColor.White;
            return enteredValue;
        }
    }
}