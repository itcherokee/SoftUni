namespace ConsoleInOut
{
    using System;

    /// <summary>
    /// Task 4: Write a program that gets two numbers from the console and prints the greater of them. 
    ///         Try to implement this without if statements. 
    /// </summary>
    public class NumberComparer
    {
        public static void Main()
        {
            Console.Title = "Find greater number of two - v.2";
            Console.WriteLine("This algorythm works only with whole numbers!");
            int numberOne = EnterData("Enter first number (integer): ");
            int numberTwo = EnterData("Enter second number (integer): ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            int delta = numberOne - numberTwo;
            int sign = (delta >> 31) & 0x1;
            int maxNumber = numberOne - (sign * delta);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Bigger number is: {0}", maxNumber);
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