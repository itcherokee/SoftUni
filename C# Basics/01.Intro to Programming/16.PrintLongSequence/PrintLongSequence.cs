namespace IntroToProgramming
{
    using System;

    // Task 16*: Write a program that prints the first 1000 members of the sequence: 2, -3, 4, -5, 6, -7, … 
    //           You might need to learn how to use loops in C# (search in Internet).
    public class PrintLongSequence
    {
        public static void Main()
        {
            const int Start = 2;
            const int NumberOfElements = 1000;
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int index = Start; index < Start + NumberOfElements; index++)
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
                if (index < Start + NumberOfElements - 1)
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
