// Task 2:  Create your own LINQ extension methods:
//          • public static IEnumerable<T> WhereNot<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
//            { … } – works just like Where(predicate) but filters the non-matching items from the collection.
//          • public static IEnumerable<T> Repeat<T>(this IEnumerable<T> collection, int count) { … } – repeats
//            the collection count times.
//          • public static IEnumerable<string> WhereEndsWith<string>(this IEnumerable<string> collection, 
//            IEnumerable<string> suffixes) { … } – filters all items from the collection that ends with some 
//            of the specified suffixes.

namespace CustomLinq
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CustomLinqMethodsExec
    {
        public static void Main()
        {
            var enumerableInt = new List<int>() { 2, 3, 8, 6, 7, 5 };
            Console.WriteLine("Initial list of ints: {0}", string.Join(", ", enumerableInt));
            var enumerableString = new List<string>() { "opa", "lele", "evala", "maraba", "hopa", "mahala" };
            Console.WriteLine("Initial list of strings: {0}\n", string.Join(", ", enumerableString));

            Console.WriteLine("*** WhereNot() extension method demo ***");
            var whereNotResultInt = enumerableInt.WhereNot(x => x % 2 == 0).ToList();
            Console.WriteLine("Ints that are not even: {0}", string.Join(",", whereNotResultInt));
            var whereNotResultString = enumerableString.WhereNot(x => x.Length == 4).ToList();
            Console.WriteLine(
                "Strings that have length other than 4: {0}\n", string.Join(", ", whereNotResultString));

            Console.WriteLine("*** Repeat() extension method demo ***");
            var repeatResultInt = enumerableInt.Repeat(2);
            Console.WriteLine(
                "Int's collection repeated 2 times: {0}\n", string.Join(", ", repeatResultInt));

            Console.WriteLine("*** WhereEndsWith() extension method demo ***");
            var suffixes = new List<string>() { "ba", "la" };
            var whereEndsWith = enumerableString.WhereEndsWith(suffixes);
            Console.WriteLine(
                "Strings that ends with \"ba\" or \"la\": {0}\n", string.Join(", ", whereEndsWith));
        }
    }
}
