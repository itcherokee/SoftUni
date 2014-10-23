// ********************************
// <copyright file="GraphicUtils.cs" company="SoftUni">
// Copyright (c) 2014 SoftUni. All rights reserved.
// </copyright>
//
// ********************************
namespace Methods
{
    using System;

    /// <summary>
    /// Contains utils for working in 2D graphic space with points and objects.
    /// </summary>
    public class GraphicUtils
    {
        /// <summary>
        /// Represents delta difference in floating-point calculations.
        /// </summary>
        private const double Difference = 0.0000000000000001;

        /// <summary>
        /// Calculates area of a triangle by Heron's formula.
        /// </summary>
        /// <param name="sideA">Side 'a' of the triangle.</param>
        /// <param name="sideB">Side 'b' of the triangle.</param>
        /// <param name="sideC">Side 'c' of the triangle.</param>
        /// <exception cref="ArgumentException">Thrown when invalid arguments' values are provided (non positive or can not form a triangle).</exception>
        /// <returns>Calculated area of the triangle.</returns>
        public static double CalcTriangleArea(double sideA, double sideB, double sideC)
        {
            if (sideA > 0 && sideB > 0 && sideC > 0)
            {
                if (sideA + sideB > sideC && sideB + sideC > sideA && sideA + sideC > sideB)
                {
                    double semiparameter = (sideA + sideB + sideC) / 2;
                    double semiSideA = semiparameter - sideA;
                    double semiSideB = semiparameter - sideB;
                    double semiSideC = semiparameter - sideC;
                    double area = Math.Sqrt(semiparameter * semiSideA * semiSideB * semiSideC);
                    return area;
                }

                throw new ArgumentException("Invalid arguments' values provided - cannot form a triangle!");
            }

            throw new ArgumentException("Invalid arguments' value provided - all values must be positive.");
        }

        /// <summary>
        /// Calculates distance between two points in 2D space.
        /// </summary>
        /// <param name="x1">X coordinate of point One.</param>
        /// <param name="y1">Y coordinate of point One.</param>
        /// <param name="x2">X coordinate of point Two.</param>
        /// <param name="y2">Y coordinate of point Two.</param>
        /// <returns>Distance between two points.</returns>
        public static double CalculateDistance(double x1, double y1, double x2, double y2)
        {
            double deltaX = x2 - x1;
            double deltaY = y2 - y1;
            double distance = Math.Sqrt((deltaX * deltaX) + (deltaY * deltaY));
            return distance;
        }

        /// <summary>
        /// Checks does two points are horizontal to each other with precision of 0.0000000000000001.
        /// </summary>
        /// <param name="y1">Y coordinate of point One.</param>
        /// <param name="y2">Y coordinate of point Two.</param>
        /// <returns>True or false.</returns>
        public static bool IsHorizontal(double y1, double y2)
        {
            bool isHorizontal = Math.Abs(y1 - y2) < Difference;
            return isHorizontal;
        }

        /// <summary>
        /// Checks does two points are vertical to each other with precision of 0.0000000000000001.
        /// </summary>
        /// <param name="x1">X coordinate of point One.</param>
        /// <param name="x2">X coordinate of point Two.</param>
        /// <returns>True or false.</returns>
        public static bool IsVertical(double x1, double x2)
        {
            bool isVertical = Math.Abs(x1 - x2) < Difference;
            return isVertical;
        }
    }
}
