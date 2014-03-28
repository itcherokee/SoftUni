namespace ConsoleInOut
{
    using System;
    using System.Linq;

    /// <summary>
    /// Task 7: Write a program that enters 5 numbers (given in a single line, separated by a space), 
    ///         calculates and prints their sum.
    /// </summary>
    public class SumOfFiveNumbers
    {
        public static void Main()
        {
            Console.Title = "Sum of all entered numbers";
            double[] numbers = EnterData("Please enter 5 numbers, separated by space: ");
            double sumOfAllNumbers = numbers.Sum();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Sum of all entered numbers is: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(sumOfAllNumbers);
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }

        private static double[] EnterData(string message)
        {
            bool isValidInput;
            double[] enteredValue = new double[5];
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(message);
                Console.ForegroundColor = ConsoleColor.Yellow;

                try
                {
                    string line = Console.ReadLine();
                    if (line != null)
                    {
                        enteredValue = line.Trim().Split().Select(double.Parse).Take(5).ToArray();
                    }

                    isValidInput = true;
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You have entered invalid number! Try again <press any key...>");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadKey();
                    Console.Clear();
                    isValidInput = false;
                }
            }
            while (!isValidInput);

            Console.ForegroundColor = ConsoleColor.White;
            return enteredValue;
        }
    }
}