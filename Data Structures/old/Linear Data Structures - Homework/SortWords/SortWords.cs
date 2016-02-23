// Task 2:  Write a program that reads from the console a sequence of words (strings on a single line, separated by a space). 
//          Sort them alphabetically. Keep the sequence in List<string>.

namespace SortWords
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SortWords
    {
        public static void Main()
        {
            Console.Write("Enter words: ");
            var words = new List<string>(Console.ReadLine().Trim().Split(' ').OrderBy(x => x));
            Console.WriteLine("{0} ", string.Join(" ", words));

        }
    }
}
