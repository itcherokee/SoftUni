namespace HelperLibrary
{
    using System;

    public class Binary
    {



        /// <summary>
        /// Represent given number as binary representation.
        /// </summary>
        /// <param name="inputNumber">Input number.</param>
        /// <returns>Binary representation as string.</returns>
        public static string BinaryPreview(int inputNumber)
        {
            return Convert.ToString(inputNumber, 2).PadLeft(32, '0');
        }

        /// <summary>
        /// Checks does the corresponding bit is set to 1.
        /// </summary>
        /// <param name="inputNumber">Input number.</param>
        /// <param name="position">Bit position to check.</param>
        /// <returns>True if bit is set to 1, otherwise returns False</returns>
        public static bool IsBitSetToOne(int inputNumber, int position)
        {
            int mask = 1 << position;
            int result = inputNumber & mask;
            result >>= position;
            return result == 1 ? true : false;
        }

        /// <summary>
        /// Checks does the corresponding bit is set to 0.
        /// </summary>
        /// <param name="inputNumber">Input number.</param>
        /// <param name="position">Bit position to check.</param>
        /// <returns>True if bit is set to 0, otherwise returns False</returns>
        public static bool IsBitSetToZero(int inputNumber, int position)
        {
            int mask = 1 << position;
            int result = inputNumber & mask;
            result >>= position;
            return result == 1 ? false : true;
        }

        /// <summary>
        /// Sets bit to 1.
        /// </summary>
        /// <param name="inputNumber">Input number.</param>
        /// <param name="position">Bit position to change to 1.</param>
        /// <returns>Number with modified bit.</returns>
        public static int SetBitToOne(int inputNumber, int position)
        {
            int mask = 1 << position;
            int result = inputNumber | mask;
            return result;
        }

        /// <summary>
        /// Sets range of bits to 1.
        /// </summary>
        /// <param name="inputNumber">Input number.</param>
        /// <param name="position">Bit position to change to 0.</param>
        /// <param name="countOfBits">Number of bits within the range.</param>
        /// <returns>Number with modified bit.</returns>
        public static int SetBitsRangeToOne(int inputNumber, int position, int countOfBits)
        {
            if (position + countOfBits > 31)
            {
                throw new ArgumentOutOfRangeException("Invalid values for countOfBits or position.");
            }

            int mask = 1;
            for (int index = 0; index < countOfBits; index++)
            {
                mask *= 2;
            }

            mask = (mask - 1) << position;
            int result = inputNumber | mask;
            return result;
        }

        /// <summary>
        /// Sets bit to 0.
        /// </summary>
        /// <param name="inputNumber">Input number.</param>
        /// <param name="position">Bit position to change to 0.</param>
        /// <returns>Number with modified bit.</returns>
        public static int SetBitToZero(int inputNumber, int position)
        {
            int mask = 1 << position;
            int result = inputNumber & ~mask;
            return result;
        }

        /// <summary>
        /// Sets range of bits to 0.
        /// </summary>
        /// <param name="inputNumber">Input number.</param>
        /// <param name="position">Bit position to change to 0.</param>
        /// <param name="countOfBits">Number of bits within the range.</param>
        /// <returns>Number with modified bit.</returns>
        public static int SetBitsRangeToZero(int inputNumber, int position, int countOfBits)
        {
            if (position + countOfBits > 31)
            {
                throw new ArgumentOutOfRangeException("Invalid values for countOfBits or position.");
            }

            int mask = 1;
            for (int index = 0; index < countOfBits; index++)
            {
                mask *= 2;
            }

            mask = (mask - 1) << position;
            int result = inputNumber & ~mask;
            return result;
        }

        /// <summary>
        /// Gets bit at position as digit (1 or 0).
        /// </summary>
        /// <param name="inputNumber">Input number.</param>
        /// <param name="position">Bit popsition to check.</param>
        /// <returns>Digital representation of bit at the requested position (1 or 0).</returns>
        public static int GetBitAsDigit(int inputNumber, int position)
        {
            int mask = 1 << position;
            int result = inputNumber & mask;
            result >>= position;
            return result;
        }

        /// <summary>
        /// Gets range of bits as digit.
        /// </summary>
        /// <param name="inputNumber">Input number.</param>
        /// <param name="position">Bit popsition to check.</param>
        /// <param name="countOfBits">Number of bits within range starting at <paramref name="position"/></param>
        /// <returns>Digital representation of bit at the requested position (1 or 0).</returns>
        public static int GetRangeOfBitsAsDigit(int inputNumber, int position, int countOfBits)
        {
            if (position + countOfBits > 31)
            {
                throw new ArgumentOutOfRangeException("invalid position or countOfBits provided.");
            }

            int mask = 1;
            for (int index = 0; index < countOfBits; index++)
            {
                mask *= 2;
            }

            mask = (mask - 1) << position;
            int result = inputNumber & mask;
            result >>= position;
            return result;
        }

        /// <summary>
        /// Calculates the sum of all bits set to 1.
        /// </summary>
        /// <param name="inputNumber">Input number.</param>
        /// <returns>Sum of all 1s bits.</returns>
        public static int SumOfBits(int inputNumber)
        {
            int result = default(int);
            for (int index = 0; index < 32; index++)
            {
                result += GetBitAsDigit(inputNumber, index);
            }

            return result;
        }

        /// <summary>
        /// Swaps the two bits.
        /// </summary>
        /// <param name="inputNumber">Input number.</param>
        /// <param name="positionOfFirstBit">Position of first bit to be swaped.</param>
        /// <param name="positionOfSecondBit">Position of second bit to be swaped.</param>
        /// <returns>Number with swaped bits.</returns>
        public static int SwapBits(int inputNumber, int positionOfFirstBit, int positionOfSecondBit)
        {
            int firstBit = GetBitAsDigit(inputNumber, positionOfFirstBit);
            int secondBit = GetBitAsDigit(inputNumber, positionOfSecondBit);
            int result = inputNumber;
            if (firstBit == 1)
            {
                result = SetBitToOne(result, positionOfSecondBit);
            }
            else
            {
                result = SetBitToZero(result, positionOfSecondBit);
            }

            if (secondBit == 1)
            {
                result = SetBitToOne(result, positionOfFirstBit);
            }
            else
            {
                result = SetBitToZero(result, positionOfFirstBit);
            }

            return result;
        }

        /// <summary>
        /// Swaps two ranges of bits.
        /// </summary>
        /// <param name="inputNumber">Input number.</param>
        /// <param name="positionOfFirstBitRange">Position of first bit to be swaped.</param>
        /// <param name="positionOfSecondBitRange">Position of second bit to be swaped.</param>
        /// <returns>Number with swaped bits.</returns>
        public static int SwapBits(int inputNumber, int positionOfFirstBitRange, int positionOfSecondBitRange, int countOfBits)
        {
            if (positionOfFirstBitRange + countOfBits > positionOfSecondBitRange)
            {
                throw new ArgumentOutOfRangeException("Illegal argument's value setup.");
            }

            int result = inputNumber;

            int firstBitRange = GetRangeOfBitsAsDigit(result, positionOfFirstBitRange, countOfBits);
            int secondBitRange = GetRangeOfBitsAsDigit(result, positionOfSecondBitRange, countOfBits);

            result = SetBitsRangeToZero(result, positionOfFirstBitRange, countOfBits);
            result = SetBitsRangeToZero(result, positionOfSecondBitRange, countOfBits);

            result = result | (firstBitRange << positionOfSecondBitRange);
            result = result | (secondBitRange << positionOfFirstBitRange);

            return result;
        }
    }
}