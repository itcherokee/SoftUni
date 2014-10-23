// **************************************************************
// <summary>Figure class</summary>
// <copyright file="Figure.cs" company="SoftUni">
// Copyright (c) 2014 SoftUni. All rights reserved.
// </copyright>
// **************************************************************
namespace Abstraction
{
    /// <summary>
    /// Represents an abstraction of figure object.
    /// </summary>
    public abstract class Figure : IFigure
    {
        /// <summary>
        /// Calculates the perimeter of the figure.
        /// </summary>
        /// <returns>Perimeter calculated as Double value.</returns>
        public abstract double CalcPerimeter();

        /// <summary>
        /// Calculates the area of the figure.
        /// </summary>
        /// <returns>Area calculated as Double value.</returns>
        public abstract double CalcSurface();
    }
}
