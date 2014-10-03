// Task 01: Create a class Point3D to hold a 3D-coordinate {X, Y, Z} in the Euclidian 3D space. 
//          Create appropriate constructors. Implement the ToString() to enable printing a 3D point.
//          Add a private static read-only field in the Point3D class to hold the start of 
//          the coordinate system – the point StartingPoint {0, 0, 0}. Add a static property 
//          to return the starting point.

namespace EuclidianSpace
{
    using System;

    public class Point3DExec
    {
        public static void Main()
        {
            var center = Point3D.StartingPoint;
            Console.WriteLine("Ceneter coordinates: {0}", center);

            var pointA = new Point3D(10, 20, 30);
            Console.WriteLine("PointA coordinates: {0}", pointA);

            Console.ReadKey();
        }
    }
}
