namespace ConditionalStatements
{
    using System;

    /// <summary>
    /// Task 1: Write an if-statement that takes two integer variables a and b and exchanges their values 
    ///         if the first one is greater than the second one. As a result print the values a and b, 
    ///         separated by a space. 
    /// </summary>
    public class ExchangeIfGreater
    {
        public static void Main()
        {
            Console.Title = "Exchange values if necessary.";
            double numberOne = EnterData("Enter first number: ");
            double numberTwo = EnterData("Enter second number: ");
            if (numberOne > numberTwo)
            {
                numberOne += numberTwo;
                numberTwo = numberOne - numberTwo;
                numberOne -= numberTwo;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Your values: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("{0} {1}", numberOne, numberTwo);
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