namespace ConditionalStatements
{
    using System;
    using System.Linq;

    /// <summary>
    /// Task 3: Classical play cards use the following signs to designate the card 
    ///         face: 2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K and A. Write a program that 
    ///         enters a string and prints “yes” if it is a valid card sign or “no” otherwise. 
    /// </summary>
    public class CheckForAPlaycard
    {
        public static void Main()
        {
            Console.Title = "Check for a valid play card";
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter a play card: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string line = Console.ReadLine();
            if (line != null)
            {
                string card = line.Trim();
                string[] cards = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Play card is valid: ");
                if (cards.Contains(card))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("yes");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("no");
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }
    }
}