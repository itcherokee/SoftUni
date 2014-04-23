namespace ConditionalStatements
{
    using System;

    /// <summary>
    /// Task 5: Write a program that finds the biggest of three numbers.
    /// </summary>
    public class BiggestOfThreeNumbers
    {
        public static void Main()
        {
            Console.Title = "Find the biggest number out of three";
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Enter three different numbers and program will find the biggest one.");
            double numberOne = EnterData("Number 1: ");
            double numberTwo = EnterData("Number 2: ");
            double numberThree = EnterData("Number 3: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Biggest: ");
            Console.ForegroundColor = ConsoleColor.Green;
            if (numberOne > numberTwo)
            {
                Console.WriteLine(numberOne > numberThree ? numberOne : numberThree);
            }
            else if (numberTwo > numberThree)
            {
                Console.WriteLine(numberTwo);
            }
            else
            {
                Console.WriteLine(numberThree);
            }

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