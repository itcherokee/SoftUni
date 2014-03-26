namespace OperatorsExpressionsStatements
{
    using System;

    /// <summary>
    /// Task 13: Write a Boolean expression that returns if the bit at position p (counting from 0, 
    ///          starting from the right) in given integer number n has value of 1. 
    /// </summary>
    public class CheckBitAtPosition
    {
        public static void Main()
        {
            Console.Title = "Check if selected bit at position is set to 1.";
            int number = 0;
            int position = 0;
            number = EnterData("Please enter an integer number: ");
            position = EnterData("Which bit of that number to be checked for 1 (counts from 0): ");
            if (position <= (sizeof(int) * 8))
            {
                Console.Write("Does bit number \"{0}\" in number \"{1}\" is set to 1: ", position, number);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(IsBitUp(number, position));
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You have entered incorect position for bit and program will exit. Start over.");
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }

        private static bool IsBitUp(int number, int position)
        {
            int mask = 1 << position;
            int result = number & mask;
            return (result >> position) == 1;
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