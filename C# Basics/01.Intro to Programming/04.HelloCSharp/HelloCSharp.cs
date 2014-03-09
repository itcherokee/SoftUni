namespace IntroToProgramming
{
    using System;

    // Task 4:  Create, compile and run a “Hello C#” console application. Ensure you have named the application 
    //          well (e.g. “”HelloCSharp”). You should submit the Visual Studio project holding the HelloCSharp 
    //          class as part of your homework.
    public class HelloCSharp
    {
        public static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Hello C#!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }
    }
}