// ********************************
// <copyright file="GraphicsUtils.cs" company="SoftUni">
// Copyright (c) 2014 SoftUni. All rights reserved.
// </copyright>
//
// ********************************
namespace CohesionAndCoupling
{
    using System;

    /// <summary>
    /// Class containing utils for calculations in 2D and 3D space.
    /// </summary>
    public static class GraphicUtils
    {
        /// <summary>
        /// Calculates distance between two Points in space (2D or 3D).  
        /// Accepts both <see cref="Point2D"/> or <see cref="Point3D"/> and  
        /// calculation is done in 2D space or in 3D space. In one call to method,
        /// both parameters need to be from one and the same type, otherwise an 
        /// <see cref="ArgumentException"/> is thrown.
        /// </summary>
        /// <param name="pointOne">Coordinates of the first Point.</param>
        /// <param name="pointTwo">Coordinates of the second Point.</param>
        /// <exception cref="ArgumentNullException">Thrown when one or both of the provided arguments is/are null.</exception>
        /// <exception cref="ArgumentException">Thrown when provided parameters are not from one and the same type.</exception>
        /// <returns>Distance between two Points.</returns>
        public static double CalculateDistance(Point2D pointOne, Point2D pointTwo)
        {
            if (pointOne != null && pointTwo != null)
            {
                if (pointOne.GetType().Name == pointTwo.GetType().Name)
                {
                    double distance;
                    double deltaX = pointTwo.CoordinateX - pointOne.CoordinateX;
                    double deltaY = pointTwo.CoordinateY - pointOne.CoordinateY;
                    if (pointOne.GetType() == typeof(Point3D))
                    {
                        var pointOne3D = pointOne as Point3D;
                        var pointTwo3D = pointTwo as Point3D;
                        double deltaZ = pointTwo3D.CoordinateZ - pointOne3D.CoordinateZ;
                        distance = Math.Sqrt((deltaX * deltaX) + (deltaY * deltaY) + (deltaZ * deltaZ));
                    }
                    else
                    {
                        distance = Math.Sqrt((deltaX * deltaX) + (deltaY * deltaY));
                    }

                    return distance;
                }

                throw new ArgumentException("Both points need to be from one and the saame type!");
            }

            throw new ArgumentNullException("Point(s) cannot be null!");
        }

        /// <summary>
        /// Calculates the volume of square shape by using coordinates of the four <see cref="Point3D"/>s.
        /// </summary>
        /// <param name="pointOne">Coordinates of the first <see cref="Point3D"/>.</param>
        /// <param name="pointTwo">Coordinates of the second <see cref="Point3D"/>.</param>
        /// <param name="pointThree">Coordinates of the third <see cref="Point3D"/>.</param>
        /// <param name="pointFour">Coordinates of the fourth <see cref="Point3D"/>.</param>
        /// <returns>Returns the volume of square shape.</returns>
        public static double CalcVolume(Point3D pointOne, Point3D pointTwo, Point3D pointThree, Point3D pointFour)
        {
            double sideA = CalculateDistance(pointOne, pointTwo);
            double sideB = CalculateDistance(pointOne, pointThree);
            double sideC = CalculateDistance(pointOne, pointFour);
            double volume = sideA * sideB * sideC;
            return volume;
        }

        /// <summary>
        /// Calculates distance between Point (2D or 3D) and center of coordinate system.
        /// </summary>
        /// <param name="point">Coordinates of the point.</param>
        /// <returns>Distance between the point and coordinate system center.</returns>
        public static double CalcDistanceToCenter(Point2D point)
        {
            if (point != null)
            {
                var center = point.GetType() == typeof(Point3D) ? new Point3D(0, 0, 0) : new Point2D(0, 0);
                double distance = CalculateDistance(center, point);
                return distance;
            }

            throw new ArgumentNullException("Point can not be with a null value!");
        }
    }
}
