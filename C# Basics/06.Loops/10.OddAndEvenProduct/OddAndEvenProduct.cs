namespace Loops
{
    using System;
    using System.Linq;

    /// <summary>
    /// Task 10: You are given n integers (given in a single line, separated by a space). 
    ///          Write a program that checks whether the product of the odd elements is 
    ///          equal to the product of the even elements. Elements are counted from 1 to n,
    ///          so the first element is odd, the second is even, etc. 
    /// </summary>
    public class OddAndEvenProduct
    {
        public static void Main()
        {
            Console.Title = "Compare Odd and even numbers product";
            int[] numbers = EnterElements();
            int oddProduct = 1;
            int evenProduct = 1;
            for (int index = 1; index <= numbers.Length; index++)
            {
                if (index % 2 == 0)
                {
                    evenProduct *= numbers[index - 1];
                }
                else
                {
                    oddProduct *= numbers[index - 1];
                }
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Product of Odd and Even numbers is equal? : ");
            bool equal = oddProduct == evenProduct;
            Console.ForegroundColor = equal ? ConsoleColor.Green : ConsoleColor.Red;
            Console.WriteLine(equal ? "Yes" : "No");
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (equal)
            {
                Console.Write("Product: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(oddProduct);
            }
            else
            {
                Console.Write("Odd product: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(oddProduct);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Even product: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(evenProduct);
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }

        // Handles user input of all numbers in one line 
        private static int[] EnterElements()
        {
            bool isValidInput = true;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Enter the numbers on one line separated by space (space is ommited).");
                Console.Write("Numbers: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                string[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    if (input.Length == 0)
                    {
                        throw new FormatException();
                    }

                    int[] numbers = input.Select(int.Parse).ToArray();
                    Console.ForegroundColor = ConsoleColor.White;
                    return numbers;
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You have entered invalid number! Try again <press any key...>");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadKey();
                    Console.Clear();
                    isValidInput = false;
                }
            }
            while (!isValidInput);

            return new int[0];
        }
    }
}
