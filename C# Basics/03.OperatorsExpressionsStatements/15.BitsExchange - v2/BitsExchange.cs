namespace OperatorsExpressionsStatements
{
    using System;
    using System.Text;

    /// <summary>
    /// Task 15: * Write a program that exchanges bits 3, 4 and 5 with bits 24, 25 and 26 of given 32-bit unsigned integer.
    /// </summary>
    public class BitsExchange
    {
        public static void Main()
        {
            Console.Title = "Exchange 2 groups of 3 bits preselected in a given number";
            uint initialBits = EnterData("Enter unsigned integer to swap folowing bits [3..5] vs. [24..26]: ");
            Console.Write("Original binary number: ");
            Console.ForegroundColor = ConsoleColor.Green;
            PrintBits(Convert.ToString(initialBits, 2).PadLeft(32, '0'));
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\nModified binary number: ");
            Console.ForegroundColor = ConsoleColor.Green;
            PrintBits(Swap(initialBits));
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }

        private static string Swap(uint number)
        {
            var resultBits = new StringBuilder();
            resultBits.Append(Convert.ToString(number, 2).PadLeft(32, '0'));
            for (int i = 5; i <= 7; i++)
            {
                char bitOne = resultBits[i];
                char bitTwo = resultBits[21 + i];
                resultBits.Remove(i, 1).Insert(i, bitTwo);
                resultBits.Remove(21 + i, 1).Insert(21 + i, bitOne);
            }

            return resultBits.ToString();
        }

        private static void PrintBits(string resultBits)
        {
            for (int i = 0; i <= 31; i++)
            {
                switch (i)
                {
                    case 5:
                    case 6:
                    case 7:
                    case 26:
                    case 27:
                    case 28:
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(resultBits[i]);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    default:
                        Console.Write(resultBits[i]);
                        break;
                }
            }
        }

        private static uint EnterData(string message)
        {
            bool isValidInput = default(bool);
            uint enteredValue = default(uint);
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(message);
                Console.ForegroundColor = ConsoleColor.Yellow;
                isValidInput = uint.TryParse(Console.ReadLine(), out enteredValue);
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