namespace ConditionalStatements
{
    using System;

    /// <summary>
    /// Task 4: Write a program that shows the sign (+, - or 0) of the product of three real numbers, 
    ///         without calculating it. Use a sequence of if operators.
    /// </summary>
    public class MultiplicationSign
    {
        public static void Main()
        {
            Console.Title = "Product sign of 3 real numbers without calculation";
            Console.WriteLine("Enter three different real numbers to discover their product sign.");
            decimal numberOne = EnterData("Number 1: ");
            decimal numberTwo = EnterData("Number 2: ");
            decimal numberThree = EnterData("Number 3: ");
            int numberOneEqualZero = decimal.Compare(numberOne, 0.0m);
            int numberTwoEqualZero = decimal.Compare(numberTwo, 0.0m);
            int numberThreeEqualZero = decimal.Compare(numberThree, 0.0m);
            byte? counter = 0;
            if ((numberOneEqualZero == 0) || (numberTwoEqualZero == 0) || (numberThreeEqualZero == 0))
            {
                counter = null;
            }
            else
            {
                if (numberOneEqualZero < 0)
                {
                    counter++;
                }

                if (numberTwoEqualZero < 0)
                {
                    counter++;
                }

                if (numberThreeEqualZero < 0)
                {
                    counter++;
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            switch (counter)
            {
                case 1:
                case 3:
                    Console.WriteLine("Product sign is negative (-).");
                    break;
                case 0:
                case 2:
                    Console.WriteLine("Product sign is positive (+).");
                    break;
                default:
                    Console.WriteLine("Product is zero (0).");
                    break;
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Here is the proof: {0} x {1} x {2} = {3}", numberOne, numberTwo, numberThree, numberOne * numberTwo * numberThree);
            Console.ReadKey();
        }

        private static decimal EnterData(string message)
        {
            bool isValidInput = default(bool);
            decimal enteredValue = default(decimal);
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(message);
                Console.ForegroundColor = ConsoleColor.Yellow;
                isValidInput = decimal.TryParse(Console.ReadLine(), out enteredValue);
                if (!isValidInput)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You have entered invalid number! Try again <press any key...>");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            while (!isValidInput);

            Console.ForegroundColor = ConsoleColor.White;
            return enteredValue;
        }
    } 
}