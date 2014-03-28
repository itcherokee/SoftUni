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
            Console.Title = "Find greater number of two - v.1";
            double numberOne = EnterData("Enter first number: ");
            double numberTwo = EnterData("Enter second number: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Bigger number is: {0}", Math.Max(numberOne, numberTwo));
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }

        private static double EnterData(string message)
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