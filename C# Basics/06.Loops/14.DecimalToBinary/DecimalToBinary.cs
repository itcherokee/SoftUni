namespace Loops
{
    using System;

    /// <summary>
    /// Task 13: Using loops write a program that converts an integer number to its binary representation. 
    ///          The input is entered as long. The output should be a variable of type string. 
    ///          Do not use the built-in .NET functionality.
    /// </summary>
    public class DecimalToBinary
    {
        public static void Main()
        {
            Console.Title = "Convert Decimal to Binary";
            long decimalNumber = EnterData("Enter decimal number: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Binary representation of decimal number is: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(DecToBin(decimalNumber));
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }

        // Converts decimal number to binary number
        private static string DecToBin(long number)
        {
            string result = string.Empty;
            while (number != 0)
            {
                result = (number % 2) + result;
                number /= 2;
            }

            return result == string.Empty ? "0" : result;
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
                if (isValidInput && enteredValue >= 0)
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