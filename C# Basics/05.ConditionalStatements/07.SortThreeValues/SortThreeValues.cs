namespace ConditionalStatements
{
    using System;

    /// <summary>
    /// Task 7: Write a program that enters 3 real numbers and prints them sorted in descending order. 
    ///         Use nested if statements. Don’t use arrays and the built-in sorting functionality. 
    /// </summary>
    public class SortThreeValues
    {
        public static void Main()
        {
            Console.Title = "Sorting 3 real numbers in descendant order";
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Enter three different real numbers to sort them in descending order.");
            decimal numberOne = EnterData("Number 1: ");
            decimal numberTwo = EnterData("Number 2: ");
            decimal numberThree = EnterData("Number 3: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Entered numbers ordered in descending order: ");
            Console.ForegroundColor = ConsoleColor.Green;
            if (decimal.Compare(numberOne, numberTwo) > 0)
            {
                if (decimal.Compare(numberOne, numberThree) > 0)
                {
                    Console.Write("{0} ", numberOne);
                    if (decimal.Compare(numberTwo, numberThree) > 0)
                    {
                        Console.WriteLine("{0} {1}", numberTwo, numberThree);
                    }
                    else
                    {
                        Console.WriteLine("{0} {1}", numberThree, numberTwo);
                    }
                }
                else
                {
                    Console.WriteLine("{0} {1} {2}", numberThree, numberOne, numberTwo);
                }
            }
            else if (decimal.Compare(numberTwo, numberThree) > 0)
            {
                Console.Write("{0} ", numberTwo);
                if (decimal.Compare(numberOne, numberThree) > 0)
                {
                    Console.WriteLine("{0} {1}", numberOne, numberThree);
                }
                else
                {
                    Console.WriteLine("{0} {1}", numberThree, numberOne);
                }
            }
            else
            {
                Console.WriteLine("{0} {1} {2}", numberThree, numberTwo, numberOne);
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }

        private static decimal EnterData(string message)
        {
            bool isValidInput;
            decimal enteredValue;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(message);
                Console.ForegroundColor = ConsoleColor.Yellow;
                isValidInput = decimal.TryParse(Console.ReadLine(), out enteredValue);
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