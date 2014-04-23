namespace ConditionalStatements
{
    using System;
    using System.Globalization;

    /// <summary>
    /// Task 10: A beer time is after 1:00 PM and before 3:00 AM. Write a program that enters a time 
    ///          in format “hh:mm tt” (an hour in range [01...12], a minute in range [00…59] and AM / PM designator)
    ///          and prints “beer time” or “non-beer time” according to the definition above or “invalid time” 
    ///          if the time cannot be parsed. Note that you may need to learn how to parse dates and times. 
    /// </summary>
    public class BeerTime
    {
        public static void Main()
        {
            Console.Title = "Beer time";
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter a time: ");
            DateTime time;
            bool isValid = DateTime.TryParseExact(Console.ReadLine(), "h:m tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out time);
            if (isValid)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("It is ");
                Console.ForegroundColor = ConsoleColor.Green;
                if (time.Hour >= 13 || time.Hour < 3)
                {
                    Console.WriteLine("beer time");
                }
                else
                {
                    Console.WriteLine("non-beer time");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid time!");
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }
    }
}