namespace ConsoleInOut
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    /// <summary>
    /// Task 12: Implement the "Falling Rocks" game in the text console. A small dwarf stays at the bottom 
    ///          of the screen and can move left and right (by the arrows keys). A number of rocks of different 
    ///          sizes and forms constantly fall down and you need to avoid a crash. Rocks are the 
    ///          symbols ^, @, *, &, +, %, $, #, !, ., ;, - distributed with appropriate density. The dwarf is (O).
    ///          Ensure a constant game speed by Thread.Sleep(150). Implement collision detection and scoring system.
    /// </summary>
    public class FallingRocks
    {
        private static Pawn player = new Pawn();
        private static List<Pawn> rocks = new List<Pawn>();

        public static void Main()
        {
            char[] fallingRocksType = new char[11] { '^', '@', '*', '&', '+', '%', '$', '#', '!', '.', ';' };
            int maxRocksSize = 3;
            int maxRocks = 1;
            int lives = 5;
            int playerSize = 3;
            int score = 0;
            int lines = 0;
            Console.CursorVisible = false;
            Console.BufferWidth = Console.WindowWidth = 60;
            Console.BufferHeight = Console.WindowHeight = 20;
            InitializePlayer();
            Random generateRocks = new Random();

            // Main loop of game
            while (true)
            {
                // Generate rocks on first line + their size
                int rockSize = generateRocks.Next(1, maxRocksSize);
                int maxRocksPerLine = generateRocks.Next(1, maxRocks);
                for (int item = 0; item <= maxRocksPerLine; item++)
                {
                    Pawn rockItem = new Pawn();
                    char rockType = fallingRocksType[generateRocks.Next(0, 11)];
                    rockItem.X = generateRocks.Next(0, Console.WindowWidth);
                    rockItem.Y = 1;
                    rockItem.Color = (ConsoleColor)generateRocks.Next(2, 15);
                    if ((rockItem.X + rockSize) > Console.WindowWidth - 1)
                    {
                        rockSize -= Console.WindowWidth - 1 - rockItem.X;
                    }

                    rockItem.RockPrint = new string(rockType, rockSize);
                    rocks.Add(rockItem);
                }

                // Player control + Game exit
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                    while (Console.KeyAvailable)
                    {
                        Console.ReadKey(true);
                    }

                    if ((pressedKey.Key == ConsoleKey.LeftArrow) && (player.X > 0))
                    {
                        player.X--;
                    }

                    if ((pressedKey.Key == ConsoleKey.RightArrow) && (player.X < Console.WindowWidth - 3))
                    {
                        player.X++;
                    }

                    if (pressedKey.Key == ConsoleKey.Q)
                    {
                        Environment.Exit(0);
                    }
                }

                // Move rocks one position down (y+1)
                lines++;
                List<Pawn> movedRocks = new List<Pawn>();
                for (int item = 0; item <= rocks.Count - 1; item++)
                {
                    Pawn movedRock = new Pawn();
                    movedRock.X = rocks[item].X;
                    movedRock.Y = rocks[item].Y + 1;
                    movedRock.Color = rocks[item].Color;
                    movedRock.RockPrint = rocks[item].RockPrint;
                    if (movedRock.Y < Console.WindowHeight - 2)
                    {
                        movedRocks.Add(movedRock);
                    }

                    // Check for hit with player
                    if (movedRock.Y - 1 == player.Y)
                    {
                        if (((movedRock.X <= player.X) && (movedRock.X + movedRock.RockPrint.Length - 1 >= player.X)) ||
                        ((movedRock.X >= player.X) && (movedRock.X + movedRock.RockPrint.Length - 1 <= player.X + playerSize - 1)) ||
                        ((movedRock.X >= player.X) && (movedRock.X <= player.X + playerSize - 1)))
                        {
                            // Draw dead player
                            player.RockPrint = "[X]";
                            player.Color = ConsoleColor.Red;
                            DrawItemOnScreen(player);  // Draw hited player
                            rocks.Clear(); // clear all rocks 
                            InitializePlayer();
                            lives--;
                            if (lives < 1)
                            {
                                DrawMessageOnScreen("GAME OVER !");
                                return;
                            }
                            else
                            {
                                DrawMessageOnScreen("You have lost life!");
                                lines = 0;
                            }
                        }
                    }
                }

                rocks = movedRocks;
                Console.Clear();
                DrawPlayground();
                Console.SetCursorPosition((Console.WindowWidth - 7) / 2, 0);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Lives: {0}    Score: {1}", lives, score);
                Thread.Sleep(150);

                // increase score by 1 for each line of rocks that passed by player
                if (lines > 20)
                {
                    score++;
                }
            }
        }

        private static void DrawItemOnScreen(Pawn item)
        {
            Console.SetCursorPosition(item.X, item.Y);
            Console.ForegroundColor = item.Color;
            Console.Write(item.RockPrint);
        }

        private static void DrawMessageOnScreen(string message)
        {
            Console.SetCursorPosition((Console.WindowWidth - message.Length) / 2, (Console.WindowHeight / 2) - 1);
            Console.Write(message);
            Console.SetCursorPosition((Console.WindowWidth - 14) / 2, (Console.WindowHeight / 2) + 1);
            Console.Write("<press Enter>");
            Console.ReadLine();
        }

        private static void DrawPlayground()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 1);
            Console.WriteLine(new string('=', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.WindowHeight - 2);
            Console.Write(new string('=', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.WindowHeight - 1);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Press \"Q\" to exit");
            Console.ForegroundColor = ConsoleColor.White;
            DrawItemOnScreen(player);
            foreach (Pawn item in rocks)
            {
                DrawItemOnScreen(item);
            }
        }

        private static void InitializePlayer()
        {
            player.X = (Console.WindowWidth - 1) / 2;
            player.Y = Console.WindowHeight - 3;
            player.Color = ConsoleColor.Yellow;
            player.RockPrint = "(0)";
        }

        // Define properties of rocks and player
        private struct Pawn
        {
            public int X;
            public int Y;
            public ConsoleColor Color;
            public string RockPrint;
        }
    }
}