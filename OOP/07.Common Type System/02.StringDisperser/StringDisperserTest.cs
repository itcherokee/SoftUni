namespace StringUtils
{
    using System;

    public class StringDisperserTest
    {
        public static void Main()
        {
            var disperserOne = new StringDisperser("gosho", "pesho", "tanio");
            var disperserTwo = disperserOne.Clone();
            Console.WriteLine("Cloned disperser are equal with original: {0}", disperserOne.Equals(disperserTwo));
            Console.WriteLine("Cloned disperser are same object as original: {0}", object.ReferenceEquals(disperserOne, disperserTwo));
            Console.Write("Enumerated content: ");
            foreach (var ch in disperserOne)
            {
                Console.Write(ch + " ");
            }

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
