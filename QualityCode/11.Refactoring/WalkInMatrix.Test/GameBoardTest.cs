namespace WalkInMatrixTest
{
    using System;
    using Game;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// This is a test class for GameBoardTest and is intended
    /// to contain all GameBoardTest Unit Tests
    /// </summary>
    [TestClass]
    public class GameBoardTest
    {
        /// <summary>
        /// A test for GameBoard Constructor - 6x6
        /// </summary>
        [TestMethod]
        public void GameBoardConstructorSixBySix()
        {
            int gameBoardSize = 6;
            var target = new GameBoard(gameBoardSize);
            Assert.AreEqual(gameBoardSize, target.Board.GetLength(0));
        }

        /// <summary>
        /// A test for GameBoard Constructor - 20x20
        /// </summary>
        [TestMethod]
        public void GameBoardConstructorTwentyByTwenty()
        {
            int gameBoardSize = 20;
            var target = new GameBoard(gameBoardSize);
            Assert.AreEqual(gameBoardSize, target.Board.GetLength(0));
        }

        /// <summary>
        /// A test for GameBoard Constructor - Invalid size (negative)
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GameBoardConstructorInvalidSizeNegative()
        {
            var target = new GameBoard(-20);
        }

        /// <summary>
        /// A test for GameBoard Constructor - Invalid size (over 100)
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GameBoardConstructorInvalidSizeOverOneHundred()
        {
            int gameBoardSize = 101;
            var target = new GameBoard(gameBoardSize);
        }

        /// <summary>
        /// A test for GameBoard Constructor - Invalid size (zero)
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GameBoardConstructorInvalidSizeZero()
        {
            int gameBoardSize = 0;
            var target = new GameBoard(gameBoardSize);
        }

        /// <summary>
        /// A test for GameBoard ToString 6x6
        /// </summary>
        [TestMethod]
        public void GameBoardToStringSixBySix()
        {
            int gameBoardSize = 6;
            var target = new GameBoard(gameBoardSize);
            string expected = "  1 16 17 18 19 20\r\n 15  2 27 28 29 21\r\n 14 31  3 26 30 22\r\n 13 36 32  4 25 23\r\n 12 35 34 33  5 24\r\n 11 10  9  8  7  6\r\n";
            Engine engine = new Engine(gameBoardSize);
            var result = engine.Run();
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// A test for GameBoard ToString 2x2
        /// </summary>
        [TestMethod]
        public void GameBoardToStringTwoByTwo()
        {
            int gameBoardSize = 2;
            var target = new GameBoard(gameBoardSize);
            string expected = "  1  4\r\n  3  2\r\n";
            Engine engine = new Engine(gameBoardSize);
            var result = engine.Run();
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// A test for FindEmptyCell
        /// </summary>
        [TestMethod]
        public void GameBoardFindEmptyCellAllEmpty()
        {
            int gameBoardSize = 6;
            GameBoard target = new GameBoard(gameBoardSize);
            Tuple<int, int> expected = new Tuple<int, int>(0, 0);
            Tuple<int, int> actual = target.FindEmptyCell();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// A test for check cell content
        /// </summary>
        [TestMethod]
        public void GameBoardCellContent()
        {
            int gameBoardSize = 6;
            GameBoard target = new GameBoard(gameBoardSize);
            int expected = 0;
            int actual = target.Board[0, 0];
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// A test for ChangeDirection
        /// </summary>
        [TestMethod]
        public void GameBoardChangeDirectionCurrentDownAndRight()
        {
            int gameBoardSize = 6;
            GameBoard target = new GameBoard(gameBoardSize);
            int currentDirectionX = 1;
            int currentDirectionY = 1;
            Tuple<int, int> expected = new Tuple<int, int>(1, 0);
            Tuple<int, int> actual = target.ChangeDirection(currentDirectionX, currentDirectionY);
            Assert.AreEqual(expected, actual);
        }
    }
}
