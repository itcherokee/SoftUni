namespace LinkedList
{
    using System;

    public class Test
    {
        public static void Main()
        {
            var list = new LinkedList<int>();

            list.ForEach(Console.WriteLine);
            Console.WriteLine("--------------------");

            list.Add(5);
            list.Add(3);
            list.Add(5);
            list.Add(10);
            Console.WriteLine("First index of element (5): {0}", list.FirstIndexOf(5));
            Console.WriteLine("Last index of element (5): {0}", list.LastIndexOf(5));

            Console.WriteLine("Count = {0}", list.Count);

            list.ForEach(Console.WriteLine);
            Console.WriteLine("--------------------");

            list.Remove(0);
            list.Remove(2);
            list.Remove(0);

            list.ForEach(Console.WriteLine);
            Console.WriteLine("--------------------");

            list.Remove(0);

            list.ForEach(Console.WriteLine);
            Console.WriteLine("--------------------");
        }
    }
}
