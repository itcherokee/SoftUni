namespace ExceptionsHomework
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class Utils
    {
        public static T[] Subsequence<T>(T[] elements, int startIndex, int count)
        {
            if (startIndex + count > elements.Length)
            {
                throw new ArgumentOutOfRangeException("Subsequence", "\"StartIndex\" + \"count\" are greater than \"arr\" length!");
            }

            List<T> result = new List<T>();
            for (int i = startIndex; i < startIndex + count; i++)
            {
                result.Add(elements[i]);
            }

            return result.ToArray();
        }

        public static string ExtractEnding(string input, int count)
        {
            if (input == null)
            {
                throw new ArgumentNullException("ExtractEnding", "\"input\" can not be null!");
            }

            if (count > input.Length - 1)
            {
                throw new ArgumentOutOfRangeException("ExtractEnding", "\"count\" is bigger then \"input\" length!");
            }

            var result = new StringBuilder();
            for (int index = input.Length - count; index < input.Length; index++)
            {
                result.Append(input[index]);
            }

            return result.ToString();
        }

        public static bool CheckPrime(int number)
        {
            if (number < 2)
            {
                throw new ArgumentOutOfRangeException("CheckPrime - number", "Only numbers bigger than 1 could be prime!");
            }

            int sqrt = (int)Math.Sqrt(number);
            for (int divisor = 2; divisor <= sqrt; divisor++)
            {
                if (number % divisor == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
