namespace Loops
{
    using System;

    /// <summary>
    /// Task 4: Write a program that generates and prints all possible cards from a standard 
    ///         deck of 52 cards (without the jokers). The cards should be printed using the 
    ///         classical notation (like 5♠, A♥, 9♣ and K♦). The card faces should start from 
    ///         2 to A. Print each card face in its four possible suits: clubs, diamonds, 
    ///         hearts and spades. Use 2 nested for-loops and a switch-case statement.
    /// </summary>
    public class PrintDeckOfCards
    {
        private static readonly ConsoleColor[] DeckColor = new ConsoleColor[4] { ConsoleColor.Black, ConsoleColor.Red, ConsoleColor.Red, ConsoleColor.Black };
        private static readonly char[] Symbol = new char[4] { '\u2663', '\u2666', '\u2665', '\u2660' };
        private static readonly string[] Suits = new string[4] { "clubs", "diamonds", "hearts", "spades" };
        private static readonly string[,] Cards = new string[13, 2] 
                                        {
                                           { "Two", "2" }, { "Three", "3" }, { "Four", "4" }, 
                                           { "Five", "5" }, { "Six", "6" }, { "Seven", "7" }, 
                                           { "Eight", "8" }, { "Nine", "9" }, { "Ten", "10" }, 
                                           { "Jack", "J" }, { "Queen", "Q" }, { "King", "K" }, { "Ace", "A" } 
                                        };

        public static void Main()
        {
            Console.Title = "Print cards from standard deck";
            Console.SetWindowSize(100, 15);
            string formatString = string.Empty;
            for (int k = 0; k <= 12; k++)
            {
                int offset = 0;
                for (int i = 0; i <= 3; i++)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    formatString = "{0,2}{1,-2}";
                    PrintOnScreenSymbol(offset, k, i, DeckColor[i], formatString, Cards[k, 1], Symbol[i]);
                    offset += 25;
                    formatString = " {0} of {1}";
                    PrintOnScreenText(k, formatString, Cards[k, 0], Suits[i]);
                }
            }

            Console.WriteLine();
            Console.ReadKey();
        }

        private static void PrintOnScreenSymbol(int offset, int row, int deck, ConsoleColor color, string formating, string card, char symbol)
        {
            Console.ForegroundColor = color;
            Console.BackgroundColor = ConsoleColor.White;
            Console.SetCursorPosition(offset, row);
            Console.Write(formating, card, symbol);
        }

        private static void PrintOnScreenText(int row, string formating, string card, string suit)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(formating, card, suit);
        }
    }
}