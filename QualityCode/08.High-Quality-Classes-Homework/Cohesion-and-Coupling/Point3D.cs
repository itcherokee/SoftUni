// ********************************
// <copyright file="Point.cs" company="SoftUni">
// Copyright (c) 2014 SoftUni. All rights reserved.
// </copyright>
//
// ********************************
namespace CohesionAndCoupling
{
    /// <summary>
    /// Represents a point in 3D space.
    /// </summary>
    public class Point3D : Point2D
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Point3D"/> class in 3D space.
        /// </summary>
        /// <param name="coordinateX">Coordinate X of the point.</param>
        /// <param name="coordinateY">Coordinate Y of the point.</param>
        /// <param name="coordinateZ">Coordinate Z of the point.</param>
        public Point3D(double coordinateX, double coordinateY, double coordinateZ)
            : base(coordinateX, coordinateY)
        {
            this.CoordinateZ = coordinateZ;
        }

        /// <summary>
        /// Gets or sets coordinate Z of the <see cref="Point3D"/>.
        /// </summary>
        public double CoordinateZ { get; set; }
    }
}
