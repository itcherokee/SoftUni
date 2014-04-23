using System.Collections.Generic;

namespace ConditionalStatements
{
    using System;

    /// <summary>
    /// Task 12: We are given 5 integer numbers. Write a program that finds all subsets of these numbers 
    ///          whose sum is 0. Assume that repeating the same subset several times is not a problem.
    /// </summary>
    public class ZeroSubSet
    {
        public static void Main()
        {
            Console.Title = "Find subset in 5 integers row equal to 0";
            Console.WriteLine("Enter five integers in one line splited by space (0 is not allowed).");
            int[] numbers = new int[5];
            Console.Write("Numbers: ");
            var line = Console.ReadLine();
            if (line != null)
            {
                string[] numbersInput = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i <= numbers.Length - 1; i++)
                {
                    bool isValidInput = int.TryParse(numbersInput[i], out numbers[i]);
                    if (!isValidInput || numbers[i] == 0)
                    {
                        Console.WriteLine("You have entered 0, invalid number or symbol. Press key to exit!");
                        Console.ReadKey();
                        return;
                    }
                }
            }

            bool found = false;
            Array.Sort(numbers);
            int sum = 0;
            int tempSum = 0;
            var winners = new List<string>();
            // two nodes
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[i] + numbers[j] == 0)
                    {
                        winners.Add(numbers[i] + " + " + numbers[j] + " = 0");
                    }
                }
            }


            for (int i = 0; i <= numbers.Length - 2; i++)
            {
                tempSum = 0;
                sum = tempSum;
                for (int k = i; k <= numbers.Length - 1; k++)
                {
                    tempSum += numbers[k];
                    if (tempSum == 0)
                    {
                        found = true;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("We have a winner (sub set is equal to 0): ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        for (int iterate = i; iterate <= k; iterate++)
                        {
                            Console.Write("{0}", numbers[iterate]);
                            if (iterate != k)
                            {
                                switch (numbers[iterate + 1] < 0)
                                {
                                    case true:
                                        break;
                                    case false:
                                        Console.Write("+");
                                        break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("={0}", tempSum);
                            }
                        }

                        tempSum = sum;
                    }
                }
            }

            if (!found)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("No zero subset!");
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Press <Enter> to exit...");
            Console.ReadKey();
        }
    }
}