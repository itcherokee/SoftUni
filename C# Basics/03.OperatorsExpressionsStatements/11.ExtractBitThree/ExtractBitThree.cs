namespace OperatorsExpressionsStatements
{
    using System;

    /// <summary>
    /// Task 11: Using bitwise operators, write an expression for finding the value of the bit #3 
    ///          of a given unsigned integer. The bits are counted from right to left, starting from bit #0. 
    ///          The result of the expression should be either 1 or 0.
    /// </summary>
    public class ExtractBitThree
    {
        public static void Main()
        {
            Console.Title = "Extract value of bit 3 in a given unsigned integer";
            uint number = EnterData("Please enter an unsigned integer number: ");
            try
            {
                var bitValue = CheckBit(number, 3);
                Console.WriteLine("Bit number #3 in unsigned integer \"{0}\" has a value = {1}", number, bitValue);
                Console.Write("Here is number {0} in binary format: ", number);
                Console.ForegroundColor = ConsoleColor.Green;
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

        private static int CheckBit(uint number, int position)
        {
            if (position > (sizeof(uint) * 8) || position < 0)
            {
                throw new ArgumentOutOfRangeException("Invalid position specified for the bit range of integer!");
            }

            uint mask = (uint)(1 << position);
            uint result = number & mask;
            return (result >> position) == 1 ? 1 : 0;
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
