// **************************************************************
// <summary>Rectangle class</summary>
// <copyright file="Rectangle.cs" company="SoftUni">
// Copyright (c) 2014 SoftUni. All rights reserved.
// </copyright>
// **************************************************************
namespace Abstraction
{
    using System;

    /// <summary>
    /// Defines an representation of a Rectangle figure.
    /// </summary>
    public class Rectangle : Figure
    {
        private double width;
        private double height;

        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> class.
        /// </summary>
        /// <param name="width">Width of the object.</param>
        /// <param name="height">Height of the object.</param>
        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        /// <summary>
        /// Gets or sets the width of the current instance of <see cref="Rectangle"/> class.
        /// </summary>
        /// <value>Width of the current instance of <see cref="Rectangle"/> class.</value>
        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value < 0.0)
                {
                    throw new ArgumentOutOfRangeException("value", "Width cannot be of negative value!");
                }

                this.width = value;
            }
        }

        /// <summary>
        /// Gets or sets the height of the current instance of <see cref="Rectangle"/> class.
        /// </summary>
        /// <value>Height of the current instance of <see cref="Rectangle"/> class.</value>
        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value < 0.0)
                {
                    throw new ArgumentOutOfRangeException("value", "Height cannot be of negative value!");
                }

                this.height = value;
            }
        }

        /// <summary>
        /// Calculates the perimeter of current instance of <see cref="Rectangle"/> class.
        /// </summary>
        /// <returns>Calculated perimeter of the figure.</returns>
        public override double CalcPerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);

            return perimeter;
        }

        /// <summary>
        /// Calculates the area of current instance of <see cref="Rectangle"/> class.
        /// </summary>
        /// <returns>Calculated area of the figure as Double value.</returns>
        public override double CalcSurface()
        {
            double surface = this.Width * this.Height;

            return surface;
        }
    }
}
