namespace OperatorsExpressionsStatements
{
    using System;

    /// <summary>
    /// Task 7: Write an expression that checks if given point (x,  y) is inside a circle K({0, 0}, 2).
    /// </summary>
    public class PointWithinCircle
    {
        public static void Main()
        {
            Console.Title = "Point within a circle?";
            Console.WriteLine("Circle coordinates are set as (0,0) with radius of 2 by definition.");
            Circle circle = new Circle(2);
            Console.WriteLine("Let set the coordinates of the point:");
            Point point = new Point
                              {
                                  X = InputData("X"),
                                  Y = InputData("Y")
                              };
            string result = (point.X * point.X) + (point.Y * point.Y) <= (circle.Radius * circle.Radius) ? "WITHIN" : "OUTSIDE";
            Console.WriteLine("Point with coordinates ({0},{1}) is {2} a given circle [(0,0),2].", point.X, point.Y, result);
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }

        private static double InputData(string message)
        {
            bool isValidInput = false;
            double inputValue = 0;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Please enter integer value for \"{0}\": ", message);
                Console.ForegroundColor = ConsoleColor.Yellow;
                isValidInput = double.TryParse(Console.ReadLine(), out inputValue);
                if (isValidInput)
                {
                    isValidInput = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You have entered incorrect number (not integer) or symbol(s). Try again (press key).");
                    Console.ReadKey();
                }
            }
            while (!isValidInput);

            return inputValue;
        }
    }
}
