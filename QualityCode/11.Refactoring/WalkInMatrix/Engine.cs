namespace Game
{
    public class Engine
    {
        private readonly GameBoard board;
        private readonly int gameBoardSize;
        private int counter = 1;
        private int row = 0;
        private int column = 0;
        private int directionX = 1;
        private int directionY = 1;

        /// <summary>
        /// Initializes a new instance of the <see cref="Engine" /> class.
        /// </summary>
        /// <param name="gameBoardSize">Size of the board.</param>
        public Engine(int gameBoardSize)
        {
            this.board = new GameBoard(gameBoardSize);
            this.gameBoardSize = gameBoardSize;
        }

        /// <summary>
        /// Fills the board according to the rules of the game.
        /// </summary>
        /// <returns>Filled up matrix of the board as a string.</returns>
        public string Run()
        {
            int countDirectionLoop = 1;
            this.board[this.row, this.column] = this.counter++;
            int numberOfElements = this.gameBoardSize * this.gameBoardSize;
            while (this.counter <= numberOfElements)
            {
                int currentRow = this.row + this.directionX;
                int currentColumn = this.column + this.directionY;
                if (this.board.IsCellValid(currentRow, currentColumn))
                {
                    this.row = currentRow;
                    this.column = currentColumn;
                    this.board[this.row, this.column] = this.counter++;
                    countDirectionLoop = 1;
                }
                else
                {
                    countDirectionLoop++;
                    if (countDirectionLoop > 8)
                    {
                        countDirectionLoop = 1;
                        var emptyCell = this.board.FindEmptyCell();
                        this.row = emptyCell.Item1 - 1;
                        this.column = emptyCell.Item2 - 1;
                        this.directionX = 1;
                        this.directionY = 1;
                    }
                    else
                    {
                        var direction = this.board.ChangeDirection(this.directionX, this.directionY);
                        this.directionX = direction.Item1;
                        this.directionY = direction.Item2;
                    }
                }
            }

            return this.board.ToString();
        }
    }
}
