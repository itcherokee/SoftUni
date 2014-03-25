namespace OperatorsExpressionsStatements
{
    using System;

    /// <summary>
    /// Task 1: "Write an expression that checks if given integer is odd or even." - using modulus operator
    /// </summary>
    public class OddOrEvenIntegers
    {
        public static void Main()
        {
            Console.Title = "Check number is odd or even";
            int number = EnterData("Please enter a valid integer number: ");
            Console.WriteLine("Your number is {0}", number % 2 == 0 ? "Even" : "Odd");
            Console.ReadKey();
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
