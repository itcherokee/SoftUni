namespace IntroToProgramming
{
    using System;

    // Task 6:  Write a program to print the numbers 1, 101 and 1001, each at a separate line. 
    //          Name the program correctly. You should submit in your homework the Visual Studio project 
    //          holding the source code of the PrintNumbers program
    public class PrintNumbers
    {
        public static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("1");
            Console.WriteLine("101");
            Console.WriteLine("1001");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }
    }
}
