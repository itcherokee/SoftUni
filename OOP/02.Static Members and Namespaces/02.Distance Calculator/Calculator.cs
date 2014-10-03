// Task 2:  Write a static class DistanceCalculator with a static method to calculate 
//          the distance between two points in the 3D space. 

namespace EuclidianSpace
{
    using System;
    
    public class Calculator
    {
        public static void Main()
        {
            var pointA = new Point3D(2, 4, 6);
            var pointB = new Point3D(10, 20, 30);
            Console.WriteLine("Distance between:");
            Console.WriteLine(" - pointA ({0})", pointA.ToString());
            Console.WriteLine(" - pointB ({0})", pointB.ToString());
            Console.WriteLine("is: {0}", DistanceCalculator.Distance(pointA, pointB));
            Console.ReadKey();
        }
    }
}
