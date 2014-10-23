// **************************************************************
// <summary>Circle class</summary>
// <copyright file="Circle.cs" company="SoftUni">
// Copyright (c) 2014 SoftUni. All rights reserved.
// </copyright>
// **************************************************************
namespace Abstraction
{
    using System;

    /// <summary>
    /// Defines an representation of a Circle figure.
    /// </summary>
    public class Circle : Figure
    {
        private double radius;

        /// <summary>
        /// Initializes a new instance of the <see cref="Circle"/> class.
        /// </summary>
        /// <param name="radius">Initial radius of the circle object.</param>
        public Circle(double radius)
        {
            this.Radius = radius;
        }

        /// <summary>
        /// Gets or sets the radius of this instance. 
        /// </summary>
        /// <value>Radius of the current instance.</value>
        public double Radius
        {
            get
            {
                return this.radius;
            }

            set
            {
                if (value < 0.0)
                {
                    throw new ArgumentOutOfRangeException("value", "Radius cannot be of negative value!");
                }

                this.radius = value;
            }
        }

        /// <summary>
        /// Calculates the perimeter of current instance of <see cref="Circle"/> class.
        /// </summary>
        /// <returns>Calculated perimeter of the figure.</returns>
        public override double CalcPerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;

            return perimeter;
        }

        /// <summary>
        /// Calculates the area of current instance of <see cref="Circle"/> class.
        /// </summary>
        /// <returns>Calculated area of the figure as Double value.</returns>
        public override double CalcSurface()
        {
            double surface = Math.PI * this.Radius * this.Radius;

            return surface;
        }
    }
}
