namespace Loops
{
    using System;
    using System.Globalization;
    using System.Linq;

    /// <summary>
    /// Task 15: Using loops write a program that converts a hexadecimal integer number to its decimal form. 
    ///          The input is entered as string. The output should be a variable of type long. 
    ///          Do not use the built-in .NET functionality. 
    /// </summary>
    public class HexadecimalToDecimal
    {
        public static void Main()
        {
            Console.Title = "Convert Hexadecimal to Decimal";
            string hexNumber = EnterData("Enter hexadecimal number: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Decimal representation of hexadecimal number is: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(HexToDec(hexNumber));
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }

        // Converts hexadecimal to decimal number
        private static long HexToDec(string hexNumber)
        {
            string number = hexNumber.ToLower();
            char[] alphas = { 'a', 'b', 'c', 'd', 'e', 'f' };
            long result = 0;
            for (int index = number.Length - 1, power = 0; index >= 0; index--, power++)
            {
                byte digit = 0;
                var multiplier = (long)Math.Pow(16, power);
                if (number[index] >= '0' && number[index] <= '9')
                {
                    digit = byte.Parse(number[index].ToString(CultureInfo.InvariantCulture));
                }
                else
                {
                    switch (number[index])
                    {
                        case 'a':
                            digit = 10;
                            break;
                        case 'b':
                            digit = 11;
                            break;
                        case 'c':
                            digit = 12;
                            break;
                        case 'd':
                            digit = 13;
                            break;
                        case 'e':
                            digit = 14;
                            break;
                        case 'f':
                            digit = 15;
                            break;
                    }
                }

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

                // checks does all characters within the string are valid Hex 
                if (enteredValue != null && IsHex(enteredValue))
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

        // Checks does all symbols in Hex number are valid hex chars
        private static bool IsHex(string hexNumber)
        {
            string number = hexNumber.ToLower();
            bool result = number.Select(symbol => ((symbol >= '0' && symbol <= '9') || (symbol >= 'a' && symbol <= 'f')))
                            .All(isHex => isHex);
            return result;
        }
    }
}
