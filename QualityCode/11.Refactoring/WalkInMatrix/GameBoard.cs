namespace Game
{
    using System;
    using System.Text;

    public class GameBoard
    {
        private const int LowerRowBorder = 1;
        private const int UpperRowBorder = 100;
        private readonly int[] directionX = { 1, 1, 1, 0, -1, -1, -1, 0 };
        private readonly int[] directionY = { 1, 0, -1, -1, -1, 0, 1, 1 };

        // private readonly int boardSize;
        private int[,] board;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameBoard" /> class.
        /// </summary>
        /// <param name="gameBoardSize">Size of the board to be constructed.</param>
        public GameBoard(int gameBoardSize)
        {
            if (gameBoardSize >= 0)
            {
                this.Board = new int[gameBoardSize, gameBoardSize];
            }
            else
            {
                throw new ArgumentException("Array cannot be of negative size!");
            }
        }

        /// <summary>
        /// Gets the game board.
        /// </summary>
        /// <value>The game board1.</value>
        public int[,] Board
        {
            get
            {
                return this.board;
            }

            private set
            {
                if (value.GetLength(0) >= LowerRowBorder &&
                    value.GetLength(0) <= UpperRowBorder &&
                    value.GetLength(0) == value.GetLength(1))
                {
                    this.board = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(string.Format("Invalid game board size ({0}) provided!", value));
                }
            }
        }

        /// <summary>
        /// Indexer for of the <see cref="Board"/>.
        /// </summary>
        /// <param name="indexRow">Row index.</param>
        /// <param name="indexColumn">Column index.</param>
        /// <returns>Value at the cell where indexes points.</returns>
        public int this[int indexRow, int indexColumn]
        {
            get
            {
                return this.board[indexRow, indexColumn];
            }

            set
            {
                this.board[indexRow, indexColumn] = value;
            }
        }

        /// <summary>
        /// Changes direction of pointer move.
        /// </summary>
        /// <param name="currentDirectionX">Current direction - row.</param>
        /// <param name="currentDirectionY">Current direction - column.</param>
        /// <returns>A new Directions by row & column.</returns>
        public Tuple<int, int> ChangeDirection(int currentDirectionX, int currentDirectionY)
        {
            int currentDirection = 0;
            for (int index = 0; index < this.directionX.Length; index++)
            {
                if (this.directionX[index] == currentDirectionX && this.directionY[index] == currentDirectionY)
                {
                    currentDirection = index;
                    break;
                }
            }

            return currentDirection == this.directionX.Length - 1
                ? new Tuple<int, int>(this.directionX[0], this.directionY[0])
                : new Tuple<int, int>(this.directionX[currentDirection + 1], this.directionY[currentDirection + 1]);
        }

        /// <summary>
        /// Find next empty cell - not yet filled up.
        /// </summary>
        /// <returns>First empty coordinates by row and column.</returns>
        public Tuple<int, int> FindEmptyCell()
        {
            for (int row = 0; row < this.Board.GetLength(0); row++)
            {
                for (int column = 0; column < this.Board.GetLength(1); column++)
                {
                    if (this.IsEmptyCell(row, column))
                    {
                        var emptyCell = new Tuple<int, int>(row, column);
                        return emptyCell;
                    }
                }
            }

            // no more empty cells
            return new Tuple<int, int>(-1, -1);
        }

        /// <summary>
        /// Checks does current cell is within boundaries of the board and is it empty (value of zero).
        /// </summary>
        /// <param name="row">Cell row.</param>
        /// <param name="column">Cell column.</param>
        /// <returns>True if cell is empty and within boundaries else returns False.</returns>
        public bool IsCellValid(int row, int column)
        {
            return this.IsWithinBorders(row, column) && this.IsEmptyCell(row, column);
        }

        /// <summary>
        /// Returns formatted matrix of the board's cell values.
        /// </summary>
        /// <returns>Game board converted to string representation.</returns>
        public override string ToString()
        {
            var output = new StringBuilder();

            for (int row = 0; row < this.Board.GetLength(0); row++)
            {
                for (int column = 0; column < this.Board.GetLength(1); column++)
                {
                    output.Append(string.Format("{0,3}", this.board[row, column]));
                }

                output.Append(Environment.NewLine);
            }

            return output.ToString();
        }

        /// <summary>
        /// Checks does current cell is empty (value of zero).
        /// </summary>
        /// <param name="row">Current row.</param>
        /// <param name="column">Current column</param>
        /// <returns>True if cell value is zero, else returns False.</returns>
        private bool IsEmptyCell(int row, int column)
        {
            return this.Board[row, column] == 0;
        }

        /// <summary>
        /// Checks does current cell is within the boundaries of the board.
        /// </summary>
        /// <param name="row">Cell row.</param>
        /// <param name="column">Cell column.</param>
        /// <returns>True if cell within the boundaries, else returns False.</returns>
        private bool IsWithinBorders(int row, int column)
        {
            bool isInRowBorders = row >= 0 && row < this.board.GetLength(0);
            bool isInColumnBorders = column >= 0 && column < this.board.GetLength(1);
            return isInRowBorders && isInColumnBorders;
        }
    }
}
