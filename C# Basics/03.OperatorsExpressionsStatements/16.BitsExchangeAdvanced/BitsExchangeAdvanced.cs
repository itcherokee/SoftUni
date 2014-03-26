namespace OperatorsExpressionsStatements
{
    using System;
    using System.Text;

    /// <summary>
    /// Task 16: Write a program that exchanges bits {p, p+1, …, p+k-1} with bits {q, q+1, …, q+k-1} of 
    ///          a given 32-bit unsigned integer. The first and the second sequence of bits may not overlap. 
    /// </summary>
    public class BitsExchangeAdvanced
    {
        private static int bitCount = 0; // number of bits to be exchanged "k"
        private static int firstBitRangeStart = 0; // start bit for the first range of bits "p"
        private static int secondBitRangeStart = 0; // start bit for the second range of bits "q"

        public static void Main()
        {
            Console.Title = "Exchange 2 groups of \"k\" bits in a given number";
            uint number = EnterData("Please enter the number to be modified: ", InputType.Number);
            bitCount = (int)EnterData("How many bits are going to be replaced [1..16] (k): ", InputType.BitCount);
            if (bitCount < 16)
            {
                firstBitRangeStart = (int)EnterData("Enter the first bits group position [0-15]: ", InputType.FirstRange);
                secondBitRangeStart = (int)EnterData("Enter the second bits group position [16-31]: ", InputType.SecondRange);
            }
            else
            {
                Console.WriteLine("You have selected to swap uint's 2 halfs (each one of 16 bits).");
                firstBitRangeStart = 0;
                secondBitRangeStart = 16;
            }

            StringBuilder numberChangedStr = new StringBuilder();
            numberChangedStr.Append(Convert.ToString(number, 2).PadLeft(32, '0'));
            uint[] wrongInput = new uint[32];
            for (int i = 0; i <= 31; i++)
            {
                wrongInput[i] = uint.Parse(numberChangedStr[i].ToString());
            }

            Array.Reverse(wrongInput);
            Tuple<int, int> exchangedBits;
            for (int i = 0; i <= bitCount - 1; i++)
            {
                exchangedBits = SwapBits(Convert.ToInt32(wrongInput[firstBitRangeStart + i]), Convert.ToInt32(wrongInput[(secondBitRangeStart + i)]));
                wrongInput[firstBitRangeStart + i] = (uint)exchangedBits.Item1;
                wrongInput[secondBitRangeStart + i] = (uint)exchangedBits.Item2;
            }

            Array.Reverse(wrongInput);
            numberChangedStr.Clear();
            for (int i = 0; i <= 31; i++)
            {
                numberChangedStr.Append(wrongInput[i]);
            }

            Console.WriteLine("Original binary number {0}", Convert.ToString(number, 2).PadLeft(32, '0'));
            Console.WriteLine("Modified binary number {0}", numberChangedStr);
            Console.ReadKey();
        }

        private static uint EnterData(string message, InputType operation)
        {
            bool isValidInput = false;
            uint enteredValue = 0;
            do
            {
                Console.Write(message);
                isValidInput = uint.TryParse(Console.ReadLine(), out enteredValue);
                switch (operation)
                {
                    case InputType.Number: // nothing to check in number as it has been checked above in "parse"
                        break;
                    case InputType.BitCount: // validates entered value for bits number "k" - max 16 bits as uint is 32 bits
                        if ((enteredValue < 1) || (enteredValue > 16))
                        {
                            isValidInput = false;
                        }

                        break;
                    case InputType.FirstRange: // validates entered value for first position "p"
                        if (enteredValue > (31 - (bitCount + bitCount - 1)) || enteredValue < 0)
                        {
                            isValidInput = false;
                        }

                        break;
                    case InputType.SecondRange: // validates entered value for second position "q"
                        if ((enteredValue > (31 - bitCount + 1)) || ((firstBitRangeStart + bitCount) > enteredValue) || enteredValue < 0)
                        {
                            isValidInput = false;
                        }

                        break;
                }

                if (!isValidInput)
                {
                    Console.WriteLine("You have entered incorrect number or symbol(s). Try again (press key).");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            while (!isValidInput);

            Console.Clear();
            return enteredValue;
        }

        /// <summary>
        /// Exchange inplace two values (represent bits) without temp variable.
        /// </summary>
        /// <param name="bitOne">First value.</param>
        /// <param name="bitTwo">Second value.</param>
        /// <returns>Tuple with swaped values.</returns>
        private static Tuple<int, int> SwapBits(int bitOne, int bitTwo)
        {
            bitOne = bitOne ^ bitTwo;
            bitTwo = bitOne ^ bitTwo;
            bitOne = bitOne ^ bitTwo;
            return new Tuple<int, int>(bitOne, bitTwo);
        }
    } 
}