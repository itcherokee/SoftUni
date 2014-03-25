namespace OperatorsExpressionsStatements
{
    using System;
    using System.Globalization;

    /// <summary>
    /// Task 6:     Write a program that takes as input a four-digit number in format abcd (e.g. 2011) and performs the following:
    ///             • Calculates the sum of the digits (in our example 2+0+1+1 = 4).
    ///             • Prints on the console the number in reversed order: dcba (in our example 1102).
    ///             • Puts the last digit in the first position: dabc (in our example 1201).
    ///             • Exchanges the second and the third digits: acbd (in our example 2101).
    ///             The number has always exactly 4 digits and cannot start with 0
    /// </summary>
    public class FourDigitNumber
    {
        public static void Main()
        {
            Console.Title = "Four-Digit number calculations.";
            int number = EnterData("Please enter a valid 4 digit number: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Sum of digits   : {0}", Sum(number));
            Console.WriteLine("Reversed digit  : {0}", Reverse(number));
            Console.WriteLine("Last digit first: {0}", MoveLastFirst(number));
            Console.WriteLine("Swaped 2nd & 3rd: {0}", Swap(number));
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }

        private static int Sum(int number)
        {
            int result = 0;
            for (int index = 0; index < 4; index++)
            {
                result += number % 10;
                number /= 10;
            }

            return result;
        }

        private static string Reverse(int number)
        {
            string result = string.Empty;
            for (int index = 0; index < 4; index++)
            {
                result += number % 10;
                number /= 10;
            }

            return result;
        }

        private static string MoveLastFirst(int number)
        {
            string result = (number % 10).ToString(CultureInfo.InvariantCulture);
            number /= 10;
            result += number;
            return result;
        }

        private static string Swap(int number)
        {
            string result = string.Empty;
            string second = string.Empty;
            for (int index = 0; index < 4; index++)
            {
                string current = (number % 10).ToString(CultureInfo.InvariantCulture);
                if (index == 1)
                {
                    second = current;
                    number /= 10;
                    continue;
                }

                if (index == 2)
                {
                    current = second + current;
                }

                result = current + result;
                number /= 10;
            }

            return result;
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
                if (!isValidInput && enteredValue.ToString(CultureInfo.InvariantCulture).Length > 4)
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