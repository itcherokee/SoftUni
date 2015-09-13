// Task 6:  Implement a data structure ReversedList<T> that holds a sequence of elements of generic type T. 
//          It should hold a sequence of items in reversed order. The structure should have some capacity 
//          that grows twice when it is filled.....

namespace ReversedList
{
    using System;

    public class TestReversedList
    {
        public static void Main()
        {
            Console.WriteLine("Creation of ReversedList with initial values: ");
            ReversedList<int> list = new ReversedList<int>(new int[] { 1, 2, 3, 4 });
            Console.WriteLine("Capacity: " + list.Capacity);
            Console.WriteLine("Count: " + list.Count);
            Console.WriteLine("Elements: {0}", string.Join(", ", list));
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("Press any key for next demo....");
            Console.ReadKey();
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("Creation of blank ReversedList with initial capacity of 3");
            Console.WriteLine("------------------------------------------------------------");
            list = new ReversedList<int>(3);
            Console.WriteLine("Capacity: " + list.Capacity);
            Console.WriteLine("Count: " + list.Count);
            Console.WriteLine("Elements: {0}", list.Count == 0 ? "(no elements)" : string.Join(", ", list));
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("Press any key for next demo....");
            Console.ReadKey();
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("Add elelments (1, 2, 3) to blank ReversedList of size 3");
            Console.WriteLine("------------------------------------------------------------");
            list = new ReversedList<int>(3);
            list.Add(1);
            list.Add(2);
            list.Add(3);
            Console.WriteLine("Capacity: " + list.Capacity);
            Console.WriteLine("Count: " + list.Count);
            Console.WriteLine("Elements: {0}", list.Count == 0 ? "(no elements)" : string.Join(", ", list));
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("Press any key for next demo....");
            Console.ReadKey();
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("Add one additional elelment (10) to above ReversedList -> double capacity");
            Console.WriteLine("------------------------------------------------------------");
            list.Add(10);
            Console.WriteLine("Capacity: " + list.Capacity);
            Console.WriteLine("Count: " + list.Count);
            Console.WriteLine("Elements: {0}", list.Count == 0 ? "(no elements)" : string.Join(", ", list));
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("Press any key for next demo....");
            Console.ReadKey();
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("Remove element from 2nd index from above ReversedList");
            Console.WriteLine("------------------------------------------------------------");
            var removed = list.Remove(2);
            Console.WriteLine("Capacity: " + list.Capacity);
            Console.WriteLine("Count: " + list.Count);
            Console.WriteLine("Element removed: {0}", removed);
            Console.WriteLine("Elements: {0}", list.Count == 0 ? "(no elements)" : string.Join(", ", list));
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("Press any key for next demo....");
            Console.ReadKey();
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("Show elements with indexes -> Enumerator + indexes");
            Console.WriteLine("------------------------------------------------------------");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine("Index: {0} -> {1}", i, list[i]);
            }
        }
    }
}