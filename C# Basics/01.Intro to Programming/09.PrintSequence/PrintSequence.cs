namespace IntroToProgramming
{
    using System;

    // Task 9:  Write a program that prints the first 10 members of the sequence: 2, -3, 4, -5, 6, -7, ...
    public class PrintSequence
    {
        public static void Main()
        {
            const int Start = 2;
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int index = Start; index < Start + 10; index++)
            {
                // check is it odd or even
                if (index % 2 != 0)
                {
                    Console.Write(index * -1);
                }
                else
                {
                    Console.Write(index);
                }

                // logic to put commas between numbers
                if (index < Start + 10 - 1)
                {
                    Console.Write(", ");
                }
                else
                {
                    Console.WriteLine();
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }
    }
}