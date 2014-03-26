namespace OperatorsExpressionsStatements
{
    using System;

    /// <summary>
    /// Task 12: Write an expression that extracts from given integer n the value of given bit at index p.
    /// </summary>
    public class ExtractBitFromInteger
    {
        public static void Main()
        {
            Console.Title = "Extract value of a given bit in a given integer";
            int number = EnterData("Please enter an integer number: ");
            int bit = EnterData("Which bit of that number to be extracted (counts from 0): ");
            try
            {
                var bitValue = CheckBit(number, bit);
                Console.WriteLine("Bit number \"{0}\" in integer \"{1}\" has a value = {2}", bit, number, bitValue);
                Console.Write("Here is number {0} in binary format: ", number);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(Convert.ToString(number, 2).PadLeft(32, '0'));
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }

        private static int CheckBit(int number, int position)
        {
            if (position > (sizeof(int) * 8) || position < 0)
            {
                throw new ArgumentOutOfRangeException("Invalid position specified for the bit range of integer!");
            }

            int mask = 1 << position;
            int result = number & mask;
            return (result >> position) == 1 ? 1 : 0;
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