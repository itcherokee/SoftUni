namespace OperatorsExpressionsStatements
{
    using System;

    /// <summary>
    /// Task 4: Write an expression that calculates rectangle’s perimeter and area by given width and height.
    /// </summary>
    public class RectangleCalculations
    {
        public static void Main()
        {
            Console.Title = "Calculate Rectangle Area";
            double rectangleWidth = EnterValue("Width");
            double rectangleHeight = EnterValue("Height");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Rectangle Width  = {0,10:F2} cm.", rectangleWidth);
            Console.WriteLine("Rectangle Height = {0,10:F2} cm.", rectangleHeight);
            Console.ForegroundColor = ConsoleColor.Yellow;
            double area = CalculateArea(rectangleWidth, rectangleHeight);
            double perimeter = CalculatePerimeter(rectangleWidth, rectangleHeight);
            Console.WriteLine("\nRectangle Area   = {0,10:F2} square cm.", area);
            Console.WriteLine("\nRectangle Perimeter   = {0,10:F2}  cm.", perimeter);
            if (area >= double.MaxValue || perimeter >= double.MaxValue)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Calculated area and perimeter could be not correct as the calculations overflow the Max allowed value for double!");
            }

            Console.ReadKey();
        }

        private static double CalculateArea(double width, double height)
        {
            return width * height;
        }

        private static double CalculatePerimeter(double width, double height)
        {
            return (2 * width) + (2 * height);
        }

        private static double EnterValue(string value)
        {
            double result = 0.0;
            bool isValidInput = false;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Enter the {0} of Rectangle in cm: ", value);
                Console.ForegroundColor = ConsoleColor.Yellow;
                isValidInput = double.TryParse(Console.ReadLine(), out result);
                if (!isValidInput)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You have entered not a number! Try again (press a key).");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            while (!isValidInput);
            Console.Clear();
            return result;
        }
    }
}