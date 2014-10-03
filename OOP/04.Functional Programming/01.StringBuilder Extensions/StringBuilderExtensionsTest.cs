// Task 01: Implement the following extension methods for the class StringBuilder:
//          • Substring(int startIndex, int length) – returns a new String object, 
//            containing the elements in the given range. Throw an exception when 
//            the range is invalid.
//          • RemoveText(string text) – removes all occurrences of the specified 
//            text (case-insensitive) from the StringBuilder. The method should 
//            not create a new StringBuilder, but should modify the existing one 
//            and return it as a result.
//          • AppendAll<T>(IEnumerable<T> items) – appends the string representations
//            of all items from the specified collection. Use ToString() to convert 
//            from T to string.
//          Write a program to demonstrate that your new extension methods work correctly.

namespace StringBuilderExtensions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class StringBuilederExtensionTest
    {
        public static void Main()
        {
            var text = new StringBuilder("I'm the grates Cezar of all times!");
            Console.WriteLine("Original phraze: {0}\n", text);

            Console.WriteLine("(Substring) - Name: {0}", text.Substring(15, 5));
            var list = new List<string>() { " As ", "we ", "all ", "are!" };
            Console.WriteLine("(AppendAll) - Some new words: {0}", text.AppendAll(list));
            Console.WriteLine("(RemoveText) - Remove name: {0}", text.RemoveText("Cezar"));
        }
    }
}
