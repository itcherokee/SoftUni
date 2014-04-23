using System;

namespace Task3
{
    class NewHouse
    {
        static void Main(string[] args)
        {
            byte height = byte.Parse(Console.ReadLine());
            byte half = (byte)(height / 2 + 1);
            for (int roof = 0; roof < half; roof++)
            {
                Console.WriteLine("{0}{1}{2}{1}{0}", new string('-', half - roof - 1), new string('*', roof), "*");
            }
            for (int floor = 0; floor < height; floor++)
            {
                Console.WriteLine("|{0}|", new string('*', height - 2));
            }
        }
    }
}
