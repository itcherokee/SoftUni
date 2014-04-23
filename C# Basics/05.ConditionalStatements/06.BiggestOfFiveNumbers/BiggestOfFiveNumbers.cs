namespace ConditionalStatements
{
    using System;

    /// <summary>
    /// Task 6: Write a program that finds the biggest of five numbers by using only five if statements.
    /// </summary>
    public class BiggestOfFiveNumbers
    {
        public static void Main()
        {
            Console.Title = "Find the biggest out of 5 numbers";
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Enter five different numbers and program will find the biggest one.");
            double numberOne = EnterData("Number 1: ");
            double numberTwo = EnterData("Number 2: ");
            double numberThree = EnterData("Number 3: ");
            double numberFour = EnterData("Number 4: ");
            double numberFive = EnterData("Number 5: ");
            double biggest = double.MinValue;
            if (biggest < numberOne)
            {
                biggest = numberOne;
            }

            if (biggest < numberTwo)
            {
                biggest = numberTwo;
            }

            if (biggest < numberThree)
            {
                biggest = numberThree;
            }

            if (biggest < numberFour)
            {
                biggest = numberFour;
            }

            if (biggest < numberFive)
            {
                biggest = numberFive;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Biggest: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(biggest);
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }

        private static double EnterData(string message)
        {
            bool isValidInput;
            double enteredValue;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(message);
                Console.ForegroundColor = ConsoleColor.Yellow;
                isValidInput = double.TryParse(Console.ReadLine(), out enteredValue);
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