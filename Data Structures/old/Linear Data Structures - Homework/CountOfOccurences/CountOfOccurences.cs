// Task 5:  Write a program that finds in given array of integers how many times each of them occurs. 
//          The input sequence holds numbers in range [0…1000]. The output should hold all numbers that 
//          occur at least once along with their number of occurrences. 

namespace CountOfOccurences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CountOfOccurences
    {
        public static void Main()
        {
            Console.Write("Enter digits: ");
            var digits = new List<int>(1000);
            digits.AddRange(Console.ReadLine().Trim().Split(' ').Select(int.Parse));
            var numbers = digits.OrderBy(x => x).Distinct().ToList();
            for (var i = 0; i < numbers.Count; i++)
            {
                Console.WriteLine("{0} -> {1} times", numbers[i], digits.Count(x => x == numbers[i]));
            }
        }
    }
}
