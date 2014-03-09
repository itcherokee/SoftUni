namespace IntroToProgramming
{
    using System;

    // Task 8:  Create a console application that calculates and prints the square root of the number 12345. 
    //          Find in Internet “how to calculate square root in C#”.
    public class SquareRoot
    {
        public static void Main()
        {
            const int Number = 12345;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Square root of {0} is: {1}", Number, Math.Sqrt(Number));
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }
    }
}
