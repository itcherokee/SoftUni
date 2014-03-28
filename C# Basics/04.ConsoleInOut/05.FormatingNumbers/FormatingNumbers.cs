namespace ConsoleInOut
{
    using System;

    /// <summary>
    /// Task 5: Write a program that reads 3 numbers: an integer a (0 ≤ a ≤ 500), a floating-point b and 
    ///         a floating-point c and prints them in 4 virtual columns on the console. Each column should 
    ///         have a width of 10 characters. The number a should be printed in hexadecimal, left aligned; 
    ///         then the number a should be printed in binary form, padded with zeroes, then the number b should 
    ///         be printed with 2 digits after the decimal point, right aligned; the number c should be printed 
    ///         with 3 digits after the decimal point, left aligned. 
    /// </summary>
    public class FormatingNumbers
    {
        public static void Main()
        {
            Console.Title = "Formating numbers";
            int numberA = EnterInteger("Enter a valid integer number (a): ");
            double numberB = EnterFloat("Enter first valid floating-point number (b): ");
            double numberC = EnterFloat("Enter second valid floating-point number (c): ");
            Console.Clear();
            Console.WriteLine("|{0,10}|{1,10}|{2,10}|{3,10}|", "\"c\" in Hex", "\"a\" in bin", "\"b\"   ", "\"c\"   ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("|{0,-10:X}|{1,10}|{2,10:F2}|{3,-10:F3}|", numberA, Convert.ToString(numberA, 2).PadLeft(10, '0'), numberB, numberC);
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }

        private static int EnterInteger(string message)
        {
            bool isValidInput;
            int enteredValue;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(message);
                Console.ForegroundColor = ConsoleColor.Yellow;
                isValidInput = int.TryParse(Console.ReadLine(), out enteredValue);
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

        private static double EnterFloat(string message)
        {
            bool isValidInput;
            double enteredValue;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
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
