namespace OperatorsExpressionsStatements
{
    using System;

    /// <summary>
    /// Task 3: Write a Boolean expression that checks for given integer if it can be 
    ///         divided (without remainder) by 7 and 5 in the same time.
    /// </summary>
    public class DevideBySevenAndFive
    {
        public static void Main()
        {
            Console.Title = "Can number be devided by 7 and 5 at the same time without remainder?";
            int checkedNumber = EnterData("Enter an integer to check is it divisable by 5 & 7 at the same time: ");
            if (checkedNumber % 35 == 0) // or: (checkedNumber % 7 == 0 && checkedNumber % 5 == 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The number can be divided by 5 and 7 at the same time!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Unfortunately the number can NOT be divided by 5 and 7 at the same time!");
            }

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
