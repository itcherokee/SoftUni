namespace Minesweeper
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    public class Minesweeper
    {
        private const int Rows = 5;
        private const int Columns = 10;
        private const int NumberOfMines = 15;
        private const int TotalSafeCells = (Rows * Columns) - NumberOfMines;
        private const int MaxPlayersToLog = 5;

        private static void Main()
        {
            string command = "error";
            char[,] playground = InitializeBoard();
            char[,] mines = PlaceBombs();
            var players = new List<Player>(MaxPlayersToLog + 1);
            int row = 0;
            int column = 0;
            int points = 0;
            bool showHeader = true;
            bool isBlownup = false;
            bool isWinner = false;

            do
            {
                if (showHeader)
                {
                    Console.WriteLine("Let's play Minesweeper. Try your luck to find cells without mines.");
                    Console.WriteLine("Commands: 'top' - Score-board, 'restart' - New game, 'exit' - Quit");
                    ShowBoard(playground);
                    showHeader = false;
                }

                Console.Write("Enter - Row, Column: ");
                var input = Console.ReadLine().Trim().Split(new[] { ',', '.' }, StringSplitOptions.RemoveEmptyEntries);
                if (input.Length == 2)
                {
                    var isRowValid = int.TryParse(input[0].ToString(CultureInfo.InvariantCulture), out row);
                    var isColumnValid = int.TryParse(input[1].ToString(CultureInfo.InvariantCulture), out column);
                    if (isRowValid && isColumnValid && row < playground.GetLength(0) && column < playground.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        ShowScoreBoard(players);
                        break;
                    case "restart":
                        playground = InitializeBoard();
                        mines = PlaceBombs();
                        ShowBoard(playground);
                        isBlownup = false;
                        showHeader = false;
                        break;
                    case "exit":
                        Console.WriteLine("Bye, bye!");
                        break;
                    case "turn":
                        if (mines[row, column] != '*')
                        {
                            if (mines[row, column] == '-')
                            {
                                SaveNumberOfMinesAroundCell(playground, mines, row, column);
                                points++;
                            }

                            if (TotalSafeCells == points)
                            {
                                isWinner = true;
                            }
                            else
                            {
                                ShowBoard(playground);
                            }
                        }
                        else
                        {
                            isBlownup = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nInvalid command! Try again.\n");
                        break;
                }

                if (isBlownup)
                {
                    ShowBoard(mines);
                    Console.WriteLine("\nHrrrrrr! You are dead with total of {0} points.", points);
                    Console.Write("Enter your name: ");
                    var player = new Player(Console.ReadLine(), points);
                    if (players.Count < MaxPlayersToLog)
                    {
                        players.Add(player);
                    }
                    else
                    {
                        for (int index = 0; index < players.Count; index++)
                        {
                            if (players[index].Points < player.Points)
                            {
                                players.Insert(index, player);
                                players.RemoveAt(players.Count - 1);
                                break;
                            }
                        }
                    }

                    players.Sort((playerOne, playerTwo) => string.Compare(playerTwo.Name, playerOne.Name, StringComparison.Ordinal));
                    ShowScoreBoard(players);

                    playground = InitializeBoard();
                    mines = PlaceBombs();
                    points = 0;
                    isBlownup = false;
                    showHeader = true;
                }

                if (isWinner)
                {
                    Console.WriteLine("\nWelldone! You opened all {0} cells withou a drop of blood.", TotalSafeCells);
                    ShowBoard(mines);
                    Console.WriteLine("Enter your name: ");
                    players.Add(new Player(Console.ReadLine(), points));
                    ShowScoreBoard(players);
                    playground = InitializeBoard();
                    mines = PlaceBombs();
                    points = 0;
                    isWinner = false;
                    showHeader = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
            Console.Read();
        }

        private static void ShowScoreBoard(IList<Player> players)
        {
            Console.WriteLine("\nPoints:");
            if (players.Count > 0)
            {
                for (int index = 0; index < players.Count; index++)
                {
                    Console.WriteLine("{0}. {1} --> {2} cells", index + 1, players[index].Name, players[index].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Empty Score-board!\n");
            }
        }

        private static void SaveNumberOfMinesAroundCell(char[,] board, char[,] mines, int row, int column)
        {
            char minesAraund = CountMinesAroundCell(mines, row, column);
            mines[row, column] = minesAraund;
            board[row, column] = minesAraund;
        }

        private static void ShowBoard(char[,] board)
        {
            int rows = board.GetLength(0);
            int columns = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int row = 0; row < rows; row++)
            {
                Console.Write("{0} | ", row);
                for (int column = 0; column < columns; column++)
                {
                    Console.Write("{0} ", board[row, column]);
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] InitializeBoard()
        {
            var board = new char[Rows, Columns];
            for (int row = 0; row < Rows; row++)
            {
                for (int column = 0; column < Columns; column++)
                {
                    board[row, column] = '?';
                }
            }

            return board;
        }

        private static char[,] PlaceBombs()
        {
            var board = new char[Rows, Columns];

            for (int row = 0; row < Rows; row++)
            {
                for (int column = 0; column < Columns; column++)
                {
                    board[row, column] = '-';
                }
            }

            var mines = new List<int>();
            while (mines.Count < NumberOfMines)
            {
                var random = new Random();
                int bomb = random.Next(Rows * Columns);
                if (!mines.Contains(bomb))
                {
                    mines.Add(bomb);
                }
            }

            foreach (int mine in mines)
            {
                int row = mine / Columns;
                int column = mine % Columns;
                if (column == 0 && mine != 0)
                {
                    row--;
                    column = Columns;
                }
                else
                {
                    column++;
                }

                board[row, column - 1] = '*';
            }

            return board;
        }

        private static char CountMinesAroundCell(char[,] board, int row, int column)
        {
            int minesCount = 0;
            int rows = board.GetLength(0);
            int columns = board.GetLength(1);

            if (row - 1 >= 0)
            {
                if (board[row - 1, column] == '*')
                {
                    minesCount++;
                }
            }

            if (row + 1 < rows)
            {
                if (board[row + 1, column] == '*')
                {
                    minesCount++;
                }
            }

            if (column - 1 >= 0)
            {
                if (board[row, column - 1] == '*')
                {
                    minesCount++;
                }
            }

            if (column + 1 < columns)
            {
                if (board[row, column + 1] == '*')
                {
                    minesCount++;
                }
            }

            if ((row - 1 >= 0) && (column - 1 >= 0))
            {
                if (board[row - 1, column - 1] == '*')
                {
                    minesCount++;
                }
            }

            if ((row - 1 >= 0) && (column + 1 < columns))
            {
                if (board[row - 1, column + 1] == '*')
                {
                    minesCount++;
                }
            }

            if ((row + 1 < rows) && (column - 1 >= 0))
            {
                if (board[row + 1, column - 1] == '*')
                {
                    minesCount++;
                }
            }

            if ((row + 1 < rows) && (column + 1 < columns))
            {
                if (board[row + 1, column + 1] == '*')
                {
                    minesCount++;
                }
            }

            return char.Parse(minesCount.ToString());
        }
    }
}