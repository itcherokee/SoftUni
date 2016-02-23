
// Task 4:  Write a program that removes from given sequence all numbers that occur odd number of times.

namespace RemoveOddOccurences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RemoveOddOccurences
    {
        public static void Main()
        {
            Console.Write("Enter digits: ");
            var digits = new List<int>(Console.ReadLine().Trim().Split(' ').Select(int.Parse));
            var evenOccurences = digits.ToList();
            foreach (var number in digits)
            {
                var occurences = digits.Count(x => x == number);
                if (occurences % 2 != 0 && evenOccurences.Contains(number))
                {
                    evenOccurences.RemoveAll(x => x == number);
                }
            }

            Console.WriteLine("{0}", string.Join(" ", evenOccurences));
        }
    }
}
