namespace Shape
{
    using System;
    using System.Collections.Generic;

    public class ShapesTest
    {
        public static void Main()
        {
            var shapes = new List<IShape>()
            {
                new Circle(10.3),
                new Triangle(12.2, 13.4, 10.1),
                new Rectangle(23.1, 10),
                new Circle(20),
                new Triangle(12, 12, 5),
                new Rectangle(20, 10)
            };

            foreach (var shape in shapes)
            {
                Console.WriteLine(
                    "{0} - Area = {1:F3} cm2; Perimeter = {2:F3} cm",
                    shape.GetType().Name,
                    shape.CalculateArea(),
                    shape.CalculatePerimeter());
            }
        }
    }
}
