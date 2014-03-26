namespace OperatorsExpressionsStatements
{
    using System;

    /// <summary>
    /// Task 14: We are given an integer number n, a bit value v (v=0 or 1) and a position p. 
    ///          Write a sequence of operators (a few lines of C# code) that modifies n to hold 
    ///          the value v at the position p from the binary representation of n while preserving 
    ///          all other bits in n.
    /// </summary>
    public class SetBitAtPosition
    {
        public static void Main()
        {
            Console.Title = "Modify given bit with a given value in an integer";
            int number = EnterData("Please enter an integer number to be modified (n): ");
            int bitValue = EnterData("What will be the value (v) of the bit [0..1]: ");
            int bitPosition = EnterData("At what position (p) to place the value [0..31]: ");
            try
            {
                var result = SetBit(number, bitPosition, bitValue);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Number (n)    | {0,-11} ({1})", number, Convert.ToString(number, 2).PadLeft(32, '0'));
                Console.WriteLine("Position (p)  | {0,-11}  {1}", bitPosition, "^".PadLeft(32 - bitPosition, ' ').PadRight(32 - bitPosition, ' '));
                Console.WriteLine("Value (v)     | {0,-11}", bitValue);
                Console.WriteLine("Resultant int | {0,-11} ({1})", result, Convert.ToString(result, 2).PadLeft(32, '0'));
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }

        private static int SetBit(int number, int position, int bitValue)
        {
            if (position > (sizeof(int) * 8) || position < 0)
            {
                throw new ArgumentOutOfRangeException("Specified bit position is invalid for an integer!");
            }

            int mask = 1 << position;
            int result = 0;
            switch (bitValue)
            {
                case 0:
                    result = number & (~mask);
                    break;
                case 1:
                    result = number | mask;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Bit values could be only 0 or positive 1!");
                    break;
            }

            return result;
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