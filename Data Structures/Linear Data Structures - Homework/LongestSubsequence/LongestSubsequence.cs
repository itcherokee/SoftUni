// Task 3:  Write a method that finds the longest subsequence of equal numbers in given List<int> and returns 
//          the result as new List<int>. If several sequences has the same longest length, return the leftmost 
//          of them. Write a program to test whether the method works correctly. 

namespace LongestSubsequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LongestSubsequence
    {
        public static void Main()
        {
            Console.Write("Enter sequence of numbers: ");
            var digits = new List<int>(Console.ReadLine().Trim().Split(' ').Select(int.Parse));
            Console.WriteLine("{0} ", string.Join(" ", FindLongestSubsequence(digits)));
        }

        private static IList<int> FindLongestSubsequence(IList<int> numbers)
        {
            if (numbers == null)
            {
                throw new NullReferenceException("Invalid (null) input data provided.");
            }

            if (numbers.Count == 0)
            {
                return numbers;
            }

            var sequenceMaxCount = 1;
            var sequenceMaxIndex = 0;

            var currentSequenceCount = sequenceMaxCount;
            var currentNumber = numbers[0];
            var currentIndex = sequenceMaxIndex;
            for (int i = 1; i < numbers.Count; i++)
            {
                if (currentNumber == numbers[i])
                {
                    currentSequenceCount++;
                    if (i == numbers.Count - 1 && currentSequenceCount > sequenceMaxCount)
                    {
                        sequenceMaxCount = currentSequenceCount;
                        sequenceMaxIndex = currentIndex;
                    }
                }
                else
                {
                    if (currentSequenceCount > sequenceMaxCount)
                    {
                        sequenceMaxCount = currentSequenceCount;
                        sequenceMaxIndex = currentIndex;
                    }
                    
                    currentIndex = i;
                    currentNumber = numbers[i];
                    currentSequenceCount = 1;
                }
            }

            return numbers.Skip(sequenceMaxIndex).Take(sequenceMaxCount).ToList();
        }
    }
}
