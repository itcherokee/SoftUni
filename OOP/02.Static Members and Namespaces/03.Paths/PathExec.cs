// Task 3:  * Create a class Path3D to hold a sequence of points in the 3D space. 
//          Create a static class Storage with static methods to save and load 
//          paths from a text file. Use a file format of your choice. Learn how 
//          to read and write text files in Internet. Ensure you close correctly 
//          all files with the "using" statement.

namespace EuclidianSpace
{
    using System;
    
    public class PathExec
    {
        public static void Main()
        {
            var points = new Path3D()
            {
                new Point3D(1.3, 2, 5.8),
                new Point3D(4, 2, 8),
                new Point3D(34, 2, 43),
                new Point3D(-5, 2, -8),
                new Point3D(0, 10, 8),
                new Point3D(0, 0, -8),
                new Point3D(1, 6, 88),
                new Point3D(4, 22, -13),
            };

            Storage.Save(points);
            var a = Storage.Load();
            Console.WriteLine(a);
        }
    }
}
