namespace ConsoleInOut
{
    using System;

    /// <summary>
    /// Task 11: Write a program that reads two positive integer numbers and prints how many 
    ///          numbers p exist between them such that the reminder of the division by 5 is 0. 
    /// </summary>
    public class DividableByGivenNumber
    {
        public static void Main()
        {
            Console.Title = "Numbers between dividable by 5";
            int numberOne = EnterData("Enter first number (sequence start): ");
            int numberTwo = EnterData("Enter second number (sequence end): ");
            if (numberOne > numberTwo)
            {
                numberOne ^= numberTwo;
                numberTwo ^= numberOne;
                numberOne ^= numberTwo;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Numbers: ");
            Console.ForegroundColor = ConsoleColor.Green;
            int counter = 0;
            for (int index = numberOne; index <= numberTwo; index++)
            {
                if (index % 5 == 0)
                {
                    Console.Write(index);
                    counter++;
                    if (index < numberTwo - 1)
                    {
                        Console.Write(", ");
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\nTotal numbers (p): ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(counter);
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }

        private static int EnterData(string message)
        {
            bool isValidInput = default(bool);
            int enteredValue = default(int);
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(message);
                Console.ForegroundColor = ConsoleColor.Yellow;
                isValidInput = int.TryParse(Console.ReadLine(), out enteredValue);
                if (isValidInput)
                {
                    continue;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You have entered invalid number! Try again <press any key...>");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                Console.Clear();
            }
            while (!isValidInput);

            Console.ForegroundColor = ConsoleColor.White;
            return enteredValue;
        }
    }
}
