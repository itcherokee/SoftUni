namespace ConsoleInOut
{
    using System;

    /// <summary>
    /// Task 1: Write a program that reads 3 real numbers from the console and prints their sum.
    /// </summary>
    public class SumOfThreeNumbers
    {
        public static void Main()
        {
            Console.Title = "Sum of 3 numbers";
            Console.WriteLine("Calculating sum of three real numbers.");
            Console.ForegroundColor = ConsoleColor.White;
            double numberOne = EnterData("Enter first number: ");
            double numberTwo = EnterData("Enter second number: ");
            double numberThree = EnterData("Enter third number: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("The Sum of numbers {0}, {1} and {2} is {3}", numberOne, numberTwo, numberThree, numberOne + numberTwo + numberThree);
            Console.ReadKey();
        }

        private static double EnterData(string message)
        {
            bool isValidInput;
            double enteredValue;
            do
            {
                Console.Write(message);
                Console.ForegroundColor = ConsoleColor.Yellow;
                isValidInput = double.TryParse(Console.ReadLine(), out enteredValue);
                if (!isValidInput)
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