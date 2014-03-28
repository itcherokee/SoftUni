namespace ConsoleInOut
{
    using System;

    /// <summary>
    /// Task 8: Write a program that reads an integer number n from the console and prints all the numbers 
    ///         in the interval [1..n], each on a single line. Note that you may need to use a for-loop.
    /// </summary>
    public class NumbersFromOneToN
    {
        public static void Main()
        {
            Console.Title = "Print [1..n] number's interval";
            int number = EnterData("Please enter an integer number (number of digits): ");
            for (int i = 1; i <= number; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(i);
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
