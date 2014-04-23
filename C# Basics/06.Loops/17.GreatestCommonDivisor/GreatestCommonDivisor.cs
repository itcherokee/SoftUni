namespace Loops
{
    using System;

    /// <summary>
    /// Task 17: Write a program that calculates the greatest common divisor (GCD) 
    ///          of given two integers a and b. Use the Euclidean algorithm. 
    /// </summary>
    public class GreatestCommonDivisor
    {
        public static void Main()
        {
            Console.Title = "Find the greatest common divisor";
            int numberN = EnterData("Enter first integer value: ");
            int numberM = EnterData("Enter second integer value: ");

            // select higher number as divinend & smaller as divider 
            numberN = numberN ^ numberM;
            numberM = numberN ^ numberM;
            numberN = numberN ^ numberM;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Greatest common divisor is ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(GCD(numberN, numberM));
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }

        // calculate GCD
        private static int GCD(int numberN, int numberM)
        {
            int result = 0;
            int gcd = 0;
            do
            {
                result = numberN % numberM;
                if (result == 0)
                {
                    gcd = numberM;
                }
                else
                {
                    numberN = numberM;
                    numberM = result;
                }
            }
            while (result != 0);

            return gcd;
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
                if (isValidInput)
                {
                    continue;
                }

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