namespace OperatorsExpressionStaments
{
    using System;

    /// <summary>
    /// Task 5: Write an expression that checks for given integer if its third digit from right-to-left is 7
    /// </summary>
    public class CheckHundredsForSeven
    {
        public static void Main()
        {
            Console.Title = "Check hundreds are 7";
            int numberChecked = EnterData("Please enter a three, four or more digit (integer) number: ");
            string result = (numberChecked / 100) % 10 == 7 ? string.Empty : "NOT ";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Third digit (right-to-left or hundreds) is {0}7!", result);
            Console.ForegroundColor = ConsoleColor.White;
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