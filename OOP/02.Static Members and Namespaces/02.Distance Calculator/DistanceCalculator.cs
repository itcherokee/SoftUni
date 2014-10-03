namespace EuclidianSpace
{
    using System;

    public static class DistanceCalculator
    {
        /// <summary>
        /// Calculates distance between two points in 3D space using separate values for each coordinate.
        /// </summary>
        /// <param name="x1">Point A - X coordinate</param>
        /// <param name="y1">Point A - Y coordinate</param>
        /// <param name="z1">Point A - Z coordinate</param>
        /// <param name="x2">Point B - X coordinate</param>
        /// <param name="y2">Point B - Y coordinate</param>
        /// <param name="z2">Point B - Z coordinate</param>
        /// <returns></returns>
        public static double Distance(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            // return Math.Sqrt(Math.Pow((x1 - x2), 2) + Math.Pow((y1 - y2), 2) + Math.Pow((z1 - z2), 2));
            return Math.Sqrt(((x1 - x2) * (x1 - x2)) + ((y1 - y2) * (y1 - y2)) + ((z1 - z2) * (z1 - z2)));
        }

        /// <summary>
        /// Calculates distance between two points in 3D space using <see cref="Point3D"/> type coordinates.
        /// </summary>
        /// <param name="pointA">Point A coordinates.</param>
        /// <param name="pointB">Point B coordinates</param>
        /// <returns></returns>
        public static double Distance(Point3D pointA, Point3D pointB)
        {
            double axisXDistance = pointA.X - pointB.X;
            double axisYDistance = pointA.Y - pointB.Y;
            double axisZDistance = pointA.Z - pointB.Z;
            return Math.Sqrt((axisXDistance * axisXDistance) + (axisYDistance * axisYDistance) + (axisZDistance * axisZDistance));
        }
    }
}
