namespace ConsoleInOut
{
    using System;

    /// <summary>
    /// Task 6: Write a program that reads the coefficients a, b and c of a quadratic 
    ///         equation ax2 + bx + c = 0 and solves it (prints its real roots). 
    /// </summary>
    public class QuadraticEquation
    {
        public static void Main()
        {
            Console.Title = "Program to solve quadratic equation ax" + '\u00B2' + "+bx+c=0";
            Console.WriteLine("Enter the three coefficients in order to find equation real roots.");
            double coefficientA = EnterData("Coefficient \"а\": ");
            double coefficientB = EnterData("Coefficient \"b\": ");
            double coefficientC = EnterData("Coefficient \"c\": ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            double roots = 0.0;
            if ((Math.Abs(coefficientA) < 0.000001) && (Math.Abs(coefficientB) < 0.000001) && (Math.Abs(coefficientC) < 0.000001))
            {
                Console.WriteLine("You have entered only 0 for all coefficients and the result is NaN (not a number) or in other words, there is no solution!");
            }
            else
            {
                if (Math.Abs(coefficientA) < 0.000001)
                {
                    roots = -(coefficientB / (2 * coefficientA));
                    Console.WriteLine("For \"a\" was entered 0, so equation is linear and solution is: {0}", -(coefficientC / coefficientB));
                }
                else
                {
                    double discriminant = Math.Pow(coefficientB, 2) - (4 * coefficientA * coefficientC);
                    if (Math.Abs(discriminant) < 0.000001)
                    {
                        roots = -(coefficientB / (2 * coefficientA));
                        Console.WriteLine("The equation has only one real root: {0}", -(coefficientB / (2 * coefficientA)));
                    }
                    else if (discriminant > 0)
                    {
                        Console.WriteLine("The equation has 2 real roots:");
                        Console.WriteLine("Root 1: {0}", ((-coefficientB) + Math.Sqrt(discriminant)) / (2 * coefficientA));
                        Console.WriteLine("Root 2: {0}", ((-coefficientB) - Math.Sqrt(discriminant)) / (2 * coefficientA));
                    }
                    else
                    {
                        Console.WriteLine("The equation has no real roots!");
                    }
                }
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