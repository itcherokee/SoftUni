namespace DistanceInLabyrinth
{
    using System;
    using System.Collections.Generic;

    public class DistanceInLabyrinth
    {
        private const int Rows = 6;
        private const int Columns = Rows;

        //private MyNode[] labyrinth;
        

        public static void Main()
        {
            var input = new string[,] 
            {{"0","0","0","x","0","x"},
             {"0","x","0","x","0","x"},
             {"0","*","x","0","x","0"},
             {"0","x","0","0","0","0"},
             {"0","0","0","x","x","0"},
             {"0","0","0","x","0","x"}};

            var row = 2;
            var col = 1;
            var head = new MyListNode<string>(input[row, col]);
            var some = new LinkedList<MyListNode<string>>(new []{head});
            some.

            while (true)
            {
                // може ли в ляво
                if (col - 1 >= 0)
                {
                    
                }

                // може ли нагоре
                if (row - 1 >= 0)
                {

                }

                // може ли в дясно
                if (col + 1 < Columns)
                {

                }

                // може ли надолу
                if (row + 1 < Rows)
                {

                }
            }

            Print(input);


        }

        private static void BuildNodesGrid(string[,] labyrinth)
        {


        }

        private static void Print(string[,] source)
        {
            for (int row = 0; row < source.GetLength(0); row++)
            {
               // Console.WriteLine(new string('-', source.GetLength(1) * 2 + 1));
                for (int col = 0; col < source.GetLength(1); col++)
                {
                    Console.Write("|{0}", source[row,col]);
                }

                Console.WriteLine("|");
            }

            Console.WriteLine(new string('-', source.GetLength(1) * 2 + 1));
        }
    }
}
