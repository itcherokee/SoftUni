using System;
using System.Text;

namespace _5.CatchTheBits
{
    class CatchTheBits
    {
        static void Main(string[] args)
        {
            var bytes = new byte[256];
            byte n = byte.Parse(Console.ReadLine());
            byte step = byte.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                bytes[i] = byte.Parse(Console.ReadLine());
            }

            int position = 1;
            int multiplyer = 1;
            var output = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                if (position > 7)
                {
                    position -= 8;
                }

                while (position < 8)
                {
                    int bit = GetBitAsDigit(bytes[i], 7 - position);
                    output.Append(bit);
                    position = 1 + multiplyer++ * step - (i * 8);
                }
            }

            if (output.Length % 8 != 0)
            {
                if (output.Length < 8)
                {
                    output.Append('0', 8 - output.Length);
                }
                else
                {
                    output.Append('0', output.Length % 8);
                }
            }

            int numberOfBytes = output.Length / 8;
            for (int i = 0; i < numberOfBytes; i++)
            {
                Console.WriteLine(BinToDec(output.ToString(0, 8)));
                output.Remove(0, 8);
            }
        }

        public static int GetBitAsDigit(int inputNumber, int position)
        {
            int mask = 1 << position;
            int result = inputNumber & mask;
            result >>= position;
            return result;
        }

        private static long BinToDec(string binaryNumber)
        {
            long result = 0;
            for (int index = binaryNumber.Length - 1, power = 0; index >= 0; index--, power++)
            {
                var multiplier = (long)Math.Pow(2, power);
                byte digit = byte.Parse(binaryNumber[index].ToString());
                result += digit * multiplier;
            }

            return result;
        }
    }
}
