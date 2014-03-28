namespace ConsoleInOut
{
    using System;

    /// <summary>
    /// Task 9: Write a program that enters a number n and after that enters more n numbers 
    ///         and calculates and prints their sum. Note that you may need to use a for-loop.
    /// </summary>
    public class SumOfNumbers
    {
        public static void Main()
        {
            Console.Title = "Sum of all entered numbers";
            long totalNumbers = EnterData("Enter the count of numbers to be calculated: ");
            long sumOfAllNumbers = default(long);
            for (int i = 0; i < totalNumbers; i++)
            {
                sumOfAllNumbers += EnterData(string.Format("Enter digit number {0}: ", i + 1));
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Sum of all entered numbers is: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(sumOfAllNumbers);
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }

        private static long EnterData(string message)
        {
            bool isValidInput;
            long enteredValue;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(message);
                Console.ForegroundColor = ConsoleColor.Yellow;
                isValidInput = long.TryParse(Console.ReadLine(), out enteredValue);
                if (isValidInput && enteredValue >= 1)
                {
                    continue;
                }

                isValidInput = false;
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