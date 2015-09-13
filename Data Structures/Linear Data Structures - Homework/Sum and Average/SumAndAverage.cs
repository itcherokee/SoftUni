// Task 1:  Write a program that reads from the console a sequence of integer numbers 
//          (on a single line, separated by a space). Calculate and print the sum and average 
//          of the elements of the sequence. Keep the sequence in List<int>.

namespace SumAndAverage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SumAndAverage
    {
        public static void Main()
        {
            Console.Write("Enter digits: ");
            var digits = new List<int>(Console.ReadLine().Trim().Split(' ').Select(int.Parse));
            Console.WriteLine("Sum={0}; Average={1}", digits.Sum(), digits.Average());
        }
    }
}