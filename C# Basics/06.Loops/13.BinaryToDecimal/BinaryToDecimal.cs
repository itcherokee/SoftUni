namespace Loops
{
    using System;
    using System.Globalization;
    using System.Linq;

    /// <summary>
    /// Task 13: Using loops write a program that converts a binary integer number to its decimal form. 
    ///          The input is entered as string. The output should be a variable of type long. 
    ///          Do not use the built-in .NET functionality. 
    /// </summary>
    public class BinaryToDecimal
    {
        public static void Main()
        {
            Console.Title = "Convert Binary to Decimal";
            string binaryNumber = EnterData("Enter binary number: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Decimal representation of binary number is: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(BinToDec(binaryNumber));
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }

        // Converts binary number to decimal number
        private static long BinToDec(string binaryNumber)
        {
            long result = 0;
            for (int index = binaryNumber.Length - 1, power = 0; index >= 0; index--, power++)
            {
                var multiplier = (long)Math.Pow(2, power);
                byte digit = byte.Parse(binaryNumber[index].ToString(CultureInfo.InvariantCulture));
                result += digit * multiplier;
            }

            return result;
        }

        private static string EnterData(string message)
        {
            bool isValidInput = false;
            string enteredValue;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(message);
                Console.ForegroundColor = ConsoleColor.Yellow;
                enteredValue = Console.ReadLine();

                // checks does all characters within the string are '0' or '1' using lambda expression
                if (enteredValue != null && enteredValue.All(ch => ch == '0' || ch == '1'))
                {
                    isValidInput = true;
                }

                if (isValidInput)
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