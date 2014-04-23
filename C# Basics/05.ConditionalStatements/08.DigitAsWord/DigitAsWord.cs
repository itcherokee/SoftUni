namespace ConditionalStatements
{
    using System;

    /// <summary>
    /// Task 8: Write a program that asks for a digit (0-9), and depending on the input, shows 
    ///         the digit as a word (in English). Print “not a digit” in case of invalid inut. 
    ///         Use a switch statement.
    /// </summary>
    public class DigitAsWord
    {
        public static void Main()
        {
            Console.Title = "Converting digit to name";
            Console.WriteLine("Enter a digit in range [0-9]: ");
            byte number;
            bool isValid = byte.TryParse(Console.ReadLine(), out number);
            if (!isValid)
            {
                number = 10;
            }

            string numberName;
            switch (number)
            {
                case 0:
                    numberName = "zero";
                    break;
                case 1:
                    numberName = "one";
                    break;
                case 2:
                    numberName = "two";
                    break;
                case 3:
                    numberName = "three";
                    break;
                case 4:
                    numberName = "four";
                    break;
                case 5:
                    numberName = "five";
                    break;
                case 6:
                    numberName = "six";
                    break;
                case 7:
                    numberName = "seven";
                    break;
                case 8:
                    numberName = "eight";
                    break;
                case 9:
                    numberName = "nine";
                    break;
                default:
                    numberName = "not a digit";
                    break;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("You have entered number: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(numberName);
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }
    }
}