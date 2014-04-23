namespace Loops
{
    using System;
    using System.Globalization;

    /// <summary>
    /// Task 4: Write a program that generates and prints all possible cards from a standard 
    ///         deck of 52 cards (without the jokers). The cards should be printed using the 
    ///         classical notation (like 5♠, A♥, 9♣ and K♦). The card faces should start from 
    ///         2 to A. Print each card face in its four possible suits: clubs, diamonds, 
    ///         hearts and spades. Use 2 nested for-loops and a switch-case statement.
    /// </summary>
    public class PrintDeckOfCards
    {
        public static void Main()
        {
            Console.Title = "Print cards from standard deck";
            Console.BackgroundColor = ConsoleColor.White;
            for (int card = 2; card < 15; card++)
            {
                for (int suit = 0; suit <= 3; suit++)
                {
                    string face = string.Empty;
                    switch (card)
                    {
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                        case 9:
                        case 10:
                            face = card.ToString(CultureInfo.InvariantCulture);
                            break;
                        case 11:
                            face = "J";
                            break;
                        case 12:
                            face = "Q";
                            break;
                        case 13:
                            face = "K";
                            break;
                        case 14:
                            face = "A";
                            break;
                    }

                    ConsoleColor cardColor;
                    if (suit == 0 || suit == 3)
                    {
                        cardColor = ConsoleColor.Black;
                        if (suit == 0)
                        {
                            face += '\u2663';
                        }
                        else
                        {
                            face += '\u2660';
                        }
                    }
                    else
                    {
                        cardColor = ConsoleColor.Red;
                        if (suit == 1)
                        {
                            face += '\u2666';
                        }
                        else
                        {
                            face += '\u2665';
                        }
                    }

                    Console.ForegroundColor = cardColor;
                    Console.Write("{0,3} ", face);
                }

                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ReadKey();
        }
    }
}