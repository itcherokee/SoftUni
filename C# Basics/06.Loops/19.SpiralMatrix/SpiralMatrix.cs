namespace Loops
{
    using System;

    /// <summary>
    /// Task 19: Write a program that reads from the console a positive integer number n (1 ≤ n ≤ 20) 
    ///          and prints a matrix holding the numbers from 1 to n*n in the form of square spiral 
    ///          like in the examples below. 
    /// </summary>
    public class SpiralMatrix
    {
        public static void Main()
        {
            Console.Title = "Print numbers in Spiral";
            int numberInput = EnterData("Please enter a number [1..20]: ");
            int[,] spiralnumbers = new int[numberInput, numberInput];
            int col = -1, row = 0;
            int borderYLeft = 0, borderYRight = numberInput;
            int borderXUp = 0, borderXDown = numberInput;
            int totalNumbers = 1;
            while (totalNumbers <= (numberInput * numberInput))
            {
                col++;
                while (col < borderYRight)
                {
                    spiralnumbers[row, col] = totalNumbers;
                    col++;
                    totalNumbers++;
                }

                col--;
                borderYRight--;
                row++;
                while (row < borderXDown)
                {
                    spiralnumbers[row, col] = totalNumbers;
                    row++;
                    totalNumbers++;
                }

                row--;
                borderXDown--;
                col--;
                while (col >= borderYLeft)
                {
                    spiralnumbers[row, col] = totalNumbers;
                    col--;
                    totalNumbers++;
                }

                col++;
                borderYLeft++;
                row--;
                while (row > borderXUp)
                {
                    spiralnumbers[row, col] = totalNumbers;
                    row--;
                    totalNumbers++;
                }

                row++;
                borderXUp++;
            }

            // Ouput to Console
            Console.Clear();
            for (int i = 0; i <= numberInput - 1; i++)
            {
                for (int k = 0; k <= numberInput - 1; k++)
                {
                    Console.Write("{0,4}", spiralnumbers[i, k]);
                }

                Console.WriteLine();
            }

            Console.ReadKey();
        }

        // User data input
        private static int EnterData(string message)
        {
            bool isValidInput;
            int enteredValue;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(message);
                Console.ForegroundColor = ConsoleColor.Yellow;
                isValidInput = int.TryParse(Console.ReadLine(), out enteredValue);
                if (isValidInput && (enteredValue >= 1) && (enteredValue <= 20))
                {
                    continue;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You have entered invalid number! Try again <press any key...>");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                Console.Clear();
                isValidInput = false;
            }
            while (!isValidInput);

            Console.ForegroundColor = ConsoleColor.White;
            return enteredValue;
        }
    }
}