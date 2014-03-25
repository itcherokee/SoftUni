namespace OperatorsExpressionsStatements
{
    using System;
    using System.Globalization;

    /// <summary>
    /// Task 2: The gravitational field of the Moon is approximately 17% of that on the Earth. 
    ///         Write a program that calculates the weight of a man on the moon by a given weight on the Earth.
    /// </summary>
    public class WeightOnMoon
    {
        public static void Main()
        {
            Console.Title = "Calculate your weeight on the Moon";
            double weight = EnterData("What is your weight (kg.): ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Your weight (kg.) on Moon is: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(CalculateWeightOnMoon(weight));
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }

        private static double CalculateWeightOnMoon(double earthWeight)
        {
            const double MoonGravitationalPull = 0.17;
            double moonWeight = earthWeight * MoonGravitationalPull;
            return moonWeight;
        }

        private static double EnterData(string message)
        {
            bool isValidInput = default(bool);
            double enteredValue = default(int);
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(message);
                Console.ForegroundColor = ConsoleColor.Yellow;
                isValidInput = double.TryParse(Console.ReadLine(), System.Globalization.NumberStyles.Number, CultureInfo.InvariantCulture, out enteredValue);
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