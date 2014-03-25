namespace OperatorsExpressionsStatements
{
    using System;

    /// <summary>
    /// Task 10: Write an expression that checks for given point (x, y) if it is within the circle K({1, 1}, 1.5) 
    ///          and out of the rectangle R(top=1, left=-1, width=6, height=2).
    /// </summary>
    public class PointCircleRectangle
    {
        public static void Main()
        {
            Console.Title = "Check a Point is within a circle and outside rectangle";
            Console.WriteLine("Settings by task definition:");
            Console.ForegroundColor = ConsoleColor.White;

            // creates circle
            Console.WriteLine("Circle coordinates K((1,1),3).");
            Circle circle = new Circle(radius: 1.5d, x: 1.0d, y: 1.0d);

            // creates rectangle
            Console.WriteLine("Rectangle coordinates LU(-1,1) and RB(5,-1).\n");
            Rectangle rectangle = new Rectangle(leftUpX: -1.0d, leftUpY: 1.0d, rightDownX: 5.0d, rightDownY: -1.0d);

            // creates 2D-Point
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Enter 2D-Point coordinates.");
            Point point = new Point(x: EnterData("X"), y: EnterData("Y"));

            // check point position against Circle
            bool checkAgainsCircle = (((point.X - circle.X) * (point.X - circle.X)) + ((point.Y - circle.Y) * (point.Y - circle.Y)))
                <= (circle.Radius * circle.Radius);

            // ccheck point position against Rectangle
            bool checkAgainstRectangle = (point.X < rectangle.LeftUp.X) || (point.X > rectangle.RightDown.X) ||
                (point.Y > rectangle.LeftUp.Y) || (point.Y < rectangle.RightDown.Y);
            bool result = checkAgainsCircle && checkAgainstRectangle;

            Console.WriteLine("2D-Point is within a circle and outside rectangle - {0}", result.ToString());
            Console.ReadKey();
        }

        private static double EnterData(string pointCoordinate)
        {
            bool isValidInput = false;
            double enteredValue = 0.0d;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\"{0}\" coordinate value: ", pointCoordinate);
                Console.ForegroundColor = ConsoleColor.Yellow;
                isValidInput = double.TryParse(Console.ReadLine(), out enteredValue);
                if (!isValidInput)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You have entered incorrect number or symbol(s). Try again (press key).");
                    Console.ReadKey();
                }
            }
            while (!isValidInput);

            return enteredValue;
        }
    } 
}