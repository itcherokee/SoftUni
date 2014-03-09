namespace IntroToProgramming
{
    using System;

    // Task 15*: Write a program to read your birthday from the console and print how old you are now 
    //           and how old you will be after 10 years.
    public class AgeAfterTenYears
    {
        public static void Main()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter your bithday (format: DD.MM.YYYY): ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            DateTime birthday;
            bool isSuccessful = DateTime.TryParse(Console.ReadLine(), out birthday);
            if (isSuccessful)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                int currentYears = DateTime.Now.Year - birthday.Year;
                Console.WriteLine("Your age now is: {0} years", currentYears);
                Console.WriteLine("After 10 years you will be on: {0} years", currentYears + 10);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid date has been entered.");
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }
    }
}