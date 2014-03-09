namespace IntroToProgramming
{
    using System;

    // Task 5:  Modify the previous application to print your name. Ensure you have named the application 
    //          well (e.g. “PrintMyName”). You should submit a separate project Visual Studio project holding 
    //          the PrintMyName class as part of your homework
    public class PrintMyName
    {
        public static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("My name is: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Madona");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }
    }
}
