// Task 4.  * Write a program to compare the performance of insertion sort, selection sort, 
//          quicksort for int, double and string values. Check also the following cases: 
//          random values, sorted values, values sorted in reversed order. 

namespace SortAlgorithm
{
    using System;
    using System.Diagnostics;

    public class TestAlgorithmsPerformance
    {
        public static void Main()
        {
            const string SortQuick = "quick";
            const string SortSelection = "selection";
            const string SortInsertion = "insertion";
            const string TypeInt = "int";
            const string TypeDouble = "double";
            const string TypeString = "string";
            const string ContentRandom = "random";
            const string ContentSortedAsc = "sorted asc";
            const string ContentSortedDesc = "sorted desc";

            int[] integerRandom = { 1, 4, 6, 3, 8, 0, -3, 233, -756, 0 };
            int[] integerSortedAsc = { -10, -4, 0, 3, 5, 6, 7, 8, 9, 10, 10000 };
            int[] integerSortedDesc = { 1000, 233, 41, 5, 2, 0, -53, -987, -10000, -222222 };
            double[] doubleRandom = { 1.6, 4.003, 6, 3.6443, 8.01, 0, -3.12345, 233.88734, -756, 0 };
            double[] doubleSortedAsc = { -10.892, -4.34, 0, 3.0001, 5.001, 6.9, 7.999999, 8.98, 9, 10, 10000.1 };
            double[] doubleSortedDesc = { 1000.343, 233, 41.34311, 5.01, 2.0, 0, -53.09823, -987, -10000.34, -222222.222 };
            string[] stringRandom = { "a", "s", "d", "z", "e", "l", "m", "h", "w", "b" };
            string[] stringSortedAsc = { "a", "e", "f", "i", "j", "k", "m", "q", "s", "z" };
            string[] stringSortedDesc = { "z", "s", "q", "m", "k", "j", "i", "f", "e", "a" };

            var timeElapsed = new Stopwatch();

            // int-random
            timeElapsed.Start();
            SortAlgorithms.InsertionSort(integerRandom);
            timeElapsed.Stop();
            ShowResult(SortInsertion, TypeInt, ContentRandom, timeElapsed.Elapsed);
            timeElapsed.Restart();
            SortAlgorithms.SelectionSort(integerRandom);
            timeElapsed.Stop();
            ShowResult(SortSelection, TypeInt, ContentRandom, timeElapsed.Elapsed);
            timeElapsed.Restart();
            SortAlgorithms.QuickSort(integerRandom);
            timeElapsed.Stop();
            ShowResult(SortQuick, TypeInt, ContentRandom, timeElapsed.Elapsed);
            Console.WriteLine();

            // int-sorted ascending
            timeElapsed.Restart();
            SortAlgorithms.InsertionSort(integerSortedAsc);
            timeElapsed.Stop();
            ShowResult(SortInsertion, TypeInt, ContentSortedAsc, timeElapsed.Elapsed);
            timeElapsed.Restart();
            SortAlgorithms.SelectionSort(integerSortedAsc);
            timeElapsed.Stop();
            ShowResult(SortSelection, TypeInt, ContentSortedAsc, timeElapsed.Elapsed);
            timeElapsed.Restart();
            SortAlgorithms.QuickSort(integerSortedAsc);
            timeElapsed.Stop();
            ShowResult(SortQuick, TypeInt, ContentSortedAsc, timeElapsed.Elapsed);
            Console.WriteLine();

            // int-sorted descending
            timeElapsed.Restart();
            SortAlgorithms.InsertionSort(integerSortedDesc);
            timeElapsed.Stop();
            ShowResult(SortInsertion, TypeInt, ContentSortedDesc, timeElapsed.Elapsed);
            timeElapsed.Restart();
            SortAlgorithms.SelectionSort(integerSortedDesc);
            timeElapsed.Stop();
            ShowResult(SortSelection, TypeInt, ContentSortedDesc, timeElapsed.Elapsed);
            timeElapsed.Restart();
            SortAlgorithms.QuickSort(integerSortedDesc);
            timeElapsed.Stop();
            ShowResult(SortQuick, TypeInt, ContentSortedDesc, timeElapsed.Elapsed);
            Console.WriteLine();

            // double-random
            timeElapsed.Restart();
            SortAlgorithms.InsertionSort(doubleRandom);
            timeElapsed.Stop();
            ShowResult(SortInsertion, TypeDouble, ContentRandom, timeElapsed.Elapsed);
            timeElapsed.Restart();
            SortAlgorithms.SelectionSort(doubleRandom);
            timeElapsed.Stop();
            ShowResult(SortSelection, TypeDouble, ContentRandom, timeElapsed.Elapsed);
            timeElapsed.Restart();
            SortAlgorithms.QuickSort(doubleRandom);
            timeElapsed.Stop();
            ShowResult(SortQuick, TypeDouble, ContentRandom, timeElapsed.Elapsed);
            Console.WriteLine();

            // double-sorted ascending
            timeElapsed.Restart();
            SortAlgorithms.InsertionSort(doubleSortedAsc);
            timeElapsed.Stop();
            ShowResult(SortInsertion, TypeDouble, ContentSortedAsc, timeElapsed.Elapsed);
            timeElapsed.Restart();
            SortAlgorithms.SelectionSort(doubleSortedAsc);
            timeElapsed.Stop();
            ShowResult(SortSelection, TypeDouble, ContentSortedAsc, timeElapsed.Elapsed);
            timeElapsed.Restart();
            SortAlgorithms.QuickSort(doubleSortedAsc);
            timeElapsed.Stop();
            ShowResult(SortQuick, TypeDouble, ContentSortedAsc, timeElapsed.Elapsed);
            Console.WriteLine();

            // double-sorted descending
            timeElapsed.Restart();
            SortAlgorithms.InsertionSort(doubleSortedDesc);
            timeElapsed.Stop();
            ShowResult(SortInsertion, TypeDouble, ContentSortedDesc, timeElapsed.Elapsed);
            timeElapsed.Restart();
            SortAlgorithms.SelectionSort(doubleSortedDesc);
            timeElapsed.Stop();
            ShowResult(SortSelection, TypeDouble, ContentSortedDesc, timeElapsed.Elapsed);
            timeElapsed.Restart();
            SortAlgorithms.QuickSort(doubleSortedDesc);
            timeElapsed.Stop();
            ShowResult(SortQuick, TypeDouble, ContentSortedDesc, timeElapsed.Elapsed);
            Console.WriteLine();

            // string-random
            timeElapsed.Restart();
            SortAlgorithms.InsertionSort(stringRandom);
            timeElapsed.Stop();
            ShowResult(SortInsertion, TypeString, ContentRandom, timeElapsed.Elapsed);
            timeElapsed.Restart();
            SortAlgorithms.SelectionSort(stringRandom);
            timeElapsed.Stop();
            ShowResult(SortSelection, TypeString, ContentRandom, timeElapsed.Elapsed);
            timeElapsed.Restart();
            SortAlgorithms.QuickSort(stringRandom);
            timeElapsed.Stop();
            ShowResult(SortQuick, TypeString, ContentRandom, timeElapsed.Elapsed);
            Console.WriteLine();

            // string-sorted ascending
            timeElapsed.Restart();
            SortAlgorithms.InsertionSort(stringSortedAsc);
            timeElapsed.Stop();
            ShowResult(SortInsertion, TypeString, ContentSortedAsc, timeElapsed.Elapsed);
            timeElapsed.Restart();
            SortAlgorithms.SelectionSort(stringSortedAsc);
            timeElapsed.Stop();
            ShowResult(SortSelection, TypeString, ContentSortedAsc, timeElapsed.Elapsed);
            timeElapsed.Restart();
            SortAlgorithms.QuickSort(stringSortedAsc);
            timeElapsed.Stop();
            ShowResult(SortQuick, TypeString, ContentSortedAsc, timeElapsed.Elapsed);
            Console.WriteLine();

            // string-sorted descending
            timeElapsed.Restart();
            SortAlgorithms.InsertionSort(stringSortedDesc);
            timeElapsed.Stop();
            ShowResult(SortInsertion, TypeString, ContentSortedDesc, timeElapsed.Elapsed);
            timeElapsed.Restart();
            SortAlgorithms.SelectionSort(stringSortedDesc);
            timeElapsed.Stop();
            ShowResult(SortSelection, TypeString, ContentSortedDesc, timeElapsed.Elapsed);
            timeElapsed.Restart();
            SortAlgorithms.QuickSort(stringSortedDesc);
            timeElapsed.Stop();
            ShowResult(SortQuick, TypeString, ContentSortedDesc, timeElapsed.Elapsed);
            Console.ReadKey();
        }

        private static void ShowResult(string sort, string type, string content, TimeSpan elapsedTime)
        {
            Console.WriteLine("({0,-9}) ({1}) ({2}) time: {3}", sort, type, content, elapsedTime);
        }
    }
}
