namespace ConsoleInOut
{
    using System;

    /// <summary>
    /// Task 3: Write a program that reads the radius r of a circle and prints its perimeter and area 
    ///         formatted with 2 digits after the decimal point.
    /// </summary>
    public class CirclePerimeterAndArea
    {
        public static void Main()
        {
            Console.Title = "Perimeter and Area of a circle";
            Console.ForegroundColor = ConsoleColor.White;
            double radius = EnterData("Enter the circle radius in order to calculate area and perimeter (cm): ");
            double perimeter = 2d * Math.PI * radius;
            double area = Math.PI * radius * radius;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The Perimeter is: {0:F2} cm.", perimeter);
            Console.WriteLine("The Area is: {0:F2} square cm.", area);
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }

        private static double EnterData(string message)
        {
            bool isValidInput;
            double enteredValue;
            do
            {
                Console.Write(message);
                Console.ForegroundColor = ConsoleColor.Yellow;
                isValidInput = double.TryParse(Console.ReadLine(), out enteredValue);
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