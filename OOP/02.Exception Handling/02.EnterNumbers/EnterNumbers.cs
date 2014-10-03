// Task 2:  Write a method ReadNumber(int start, int end) that enters an integer number in given 
//          range [start…end]. If an invalid number or non-number text is entered, the method 
//          should throw an exception. Using this method write a program that enters 10 numbers: 
//          a1, a2, … a10, such that 1 < a1 < … < a10 < 100. If the user enters an invalid number, 
//          let the user to enter again.

namespace EnterNumbers
{
    using System;

    public class EnterNumbers
    {
        public static void Main()
        {
            const byte Limit = 10;
            const int Start = 1;
            const int End = 100;
            const string ReenterMessage = " You must re-enter the number!";

            var numbers = new int[Limit];
            for (int index = 0; index < Limit; index++)
            {
                bool isValidInput = false;
                do
                {
                    try
                    {
                        int currentNumber = ReadNumber(Start, End);
                        if (index > 0 && currentNumber <= numbers[index - 1])
                        {
                            throw new ArgumentException("The number must be bigger than previously entered one!");
                        }

                        numbers[index] = currentNumber;
                        isValidInput = true;
                    }
                    catch (ArgumentNullException)
                    {
                        Console.WriteLine("NULL value is not acceptable as input!" + ReenterMessage);
                        isValidInput = false;
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        Console.WriteLine(ex.Message + ReenterMessage);
                        isValidInput = false;
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message + ReenterMessage);
                        isValidInput = false;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid number format used for input!" + ReenterMessage);
                        isValidInput = false;
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("Entered number is above accepted boundaries for Integer type" + ReenterMessage);
                        isValidInput = false;
                    }
                }
                while (!isValidInput);
            }

            for (int i = 0; i < Limit; i++)
            {
                Console.WriteLine("Number {0} = {1}", i, numbers[i]);
            }

            Console.ReadKey();
        }

        private static int ReadNumber(int start, int end)
        {
            Console.Write("\nEnter number: ");

            int number = int.Parse(Console.ReadLine());
            if (number >= start && number <= end)
            {
                return number;
            }

            throw new ArgumentOutOfRangeException(
                    string.Format("Entered number is out of accepted boundaries. Must be in range [{0}..{1}]", start, end));
        }
    }
}
