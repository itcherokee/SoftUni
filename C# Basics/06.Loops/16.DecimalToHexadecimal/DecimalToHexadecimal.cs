namespace Loops
{
    using System;
    using System.Globalization;

    /// <summary>
    /// Task 16: Using loops write a program that converts an integer number to its hexadecimal representation. 
    ///          The input is entered as long. The output should be a variable of type string. 
    ///          Do not use the built-in .NET functionality. 
    /// </summary>
    public class DecimalToHexadecimal
    {
        public static void Main()
        {
            Console.Title = "Convert Decimal to Hexadecimal";
            long decimalNumber = EnterData("Enter decimal number: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Hexadecimal representation of decimal number is: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(DecToHex(decimalNumber));
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }

        // Converts decimal number to hexadecimal number
        private static string DecToHex(long number)
        {
            string result = string.Empty;
            long quotient = number;
            do
            {
                var remainder = (byte)(quotient % 16);
                quotient /= 16;
                string digit = string.Empty;
                if (remainder <= 9)
                {
                    digit = remainder.ToString(CultureInfo.InvariantCulture);
                }
                else
                {
                    switch (remainder)
                    {
                        case 10:
                            digit = "A";
                            break;
                        case 11:
                            digit = "B";
                            break;
                        case 12:
                            digit = "C";
                            break;
                        case 13:
                            digit = "D";
                            break;
                        case 14:
                            digit = "E";
                            break;
                        case 15:
                            digit = "F";
                            break;
                    }
                }

                result = digit + result;
            }
            while (quotient != 0);

            return result;
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