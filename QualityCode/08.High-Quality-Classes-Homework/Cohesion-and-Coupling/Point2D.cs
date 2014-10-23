// ********************************
// <copyright file="Point.cs" company="SoftUni">
// Copyright (c) 2014 SoftUni. All rights reserved.
// </copyright>
//
// ********************************
namespace CohesionAndCoupling
{
    /// <summary>
    /// Represents a point in 2D space.
    /// </summary>
    public class Point2D
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Point2D"/> class in 2D space.
        /// </summary>
        /// <param name="coordinateX">Coordinate X of the point.</param>
        /// <param name="coordinateY">Coordinate Y of the point.</param>
        public Point2D(double coordinateX, double coordinateY)
        {
            this.CoordinateX = coordinateX;
            this.CoordinateY = coordinateY;
        }

        /// <summary>
        /// Gets or sets coordinate X of the <see cref="Point2D"/>.
        /// </summary>
        public double CoordinateX { get; set; }

        /// <summary>
        /// Gets or sets coordinate Y of the <see cref="Point2D"/>.
        /// </summary>
        public double CoordinateY { get; set; }
    }
}
