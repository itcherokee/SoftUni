// ********************************
// <copyright file="UtilsExample.cs" company="SoftUni">
// Copyright (c) 2014 SoftUni. All rights reserved.
// </copyright>
//
// ********************************
namespace CohesionAndCoupling
{
    using System;

    public class UtilsExamples
    {
        public static void Main()
        {
            Console.WriteLine(FileUtils.GetFileExtension("example"));
            Console.WriteLine(FileUtils.GetFileExtension("example.pdf"));
            Console.WriteLine(FileUtils.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.new.pdf"));

            var pointOne2D = new Point2D(1, -2);
            var pointTwo2D = new Point2D(3, 4);
            Console.WriteLine("Distance in the 2D space = {0:f2}", GraphicUtils.CalculateDistance(pointOne2D, pointTwo2D));
            var pointOne3D = new Point3D(5, 2, -1);
            var pointTwo3D = new Point3D(3, -6, 4);
            Console.WriteLine("Distance in the 3D space = {0:f2}", GraphicUtils.CalculateDistance(pointOne3D, pointTwo3D));

            pointOne3D = new Point3D(0, 0, 0);
            pointTwo3D = new Point3D(1, 0, 0);
            var pointThree3D = new Point3D(0, 1, 0);
            var pointFour3D = new Point3D(0, 0, 1);
            var farPoint3D = new Point3D(1, 1, 1);

            Console.WriteLine("Volume = {0:f2}", GraphicUtils.CalcVolume(pointOne3D, pointTwo3D, pointThree3D, pointFour3D));
            Console.WriteLine("Diagonal XYZ = {0:f2}", GraphicUtils.CalcDistanceToCenter(farPoint3D));
            Console.WriteLine("Diagonal XY = {0:f2}", GraphicUtils.CalcDistanceToCenter(pointTwo3D));
            Console.WriteLine("Diagonal XZ = {0:f2}", GraphicUtils.CalcDistanceToCenter(pointFour3D));
            Console.WriteLine("Diagonal YZ = {0:f2}", GraphicUtils.CalculateDistance(pointThree3D, pointFour3D));
        }
    }
}
