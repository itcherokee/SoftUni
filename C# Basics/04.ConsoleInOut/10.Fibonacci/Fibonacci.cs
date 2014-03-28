namespace ConsoleInOut
{
    using System;
    using System.Numerics;

    /// <summary>
    /// Task 10: Write a program that reads a number n and prints on the console the first n members 
    ///          of the Fibonacci sequence (at a single line, separated by spaces) : 0, 1, 1, 2, 3, 
    ///          5, 8, 13, 21, 34, 55, 89, 144, 233, …. Note that you may need to learn how to use loops. 
    /// </summary>
    public class Fibonacci
    {
        public static void Main()
        {
            Console.Title = "Fibonacci numbers";
            BigInteger numberOne = 0;
            BigInteger numberTwo = 1;
            BigInteger currentNumber = numberOne;
            long lastNumber = EnterData("Enter last number you require from Fibonacci sequence: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(lastNumber + ": ");
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < lastNumber; i++)
            {
                Console.Write(currentNumber);
                numberOne = numberTwo;
                numberTwo = currentNumber;
                currentNumber = numberOne + numberTwo;
                if (i < lastNumber - 1)
                {
                    Console.Write(" ");
                }
            }

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
                if (!isValidInput && enteredValue >= 0)
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