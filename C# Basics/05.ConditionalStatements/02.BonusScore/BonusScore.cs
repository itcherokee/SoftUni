namespace ConditionalStatements
{
    using System;

    /// <summary>
    /// Task 2: Write a program that applies bonus score to given score in the range [1…9] by the following rules:
    ///         • If the score is between 1 and 3, the program multiplies it by 10.
    ///         • If the score is between 4 and 6, the program multiplies it by 100.
    ///         • If the score is between 7 and 9, the program multiplies it by 1000.
    ///         • If the score is 0 or more than 9, the program prints “invalid score”.
    /// </summary>
    public class BonusScore
    {
        public static void Main()
        {
            Console.Title = "Bonus score";
            int score = EnterData("Please enter the score: ");
            int bonus;
            switch (score)
            {
                case 1:
                case 2:
                case 3:
                    bonus = score * 10;
                    break;
                case 4:
                case 5:
                case 6:
                    bonus = score * 100;
                    break;
                case 7:
                case 8:
                case 9:
                    bonus = score * 1000;
                    break;
                default:
                    bonus = 0;
                    break;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            if (bonus != 0)
            {
                Console.Write("Your total score is: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(bonus);
            }
            else
            {
                Console.WriteLine("Invalid score!");
            }

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
