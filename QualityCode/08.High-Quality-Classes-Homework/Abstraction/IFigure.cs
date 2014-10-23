// **************************************************************
// <summary>IFigure interface</summary>
// <copyright file="IFigure.cs" company="SoftUni">
// Copyright (c) 2014 SoftUni. All rights reserved.
// </copyright>
// **************************************************************
namespace Abstraction
{
    /// <summary>
    /// Represents an abstraction of figure API interface.
    /// </summary>
    public interface IFigure
    {
        /// <summary>
        /// Calculates the perimeter of the figure.
        /// </summary>
        /// <returns>Calculated perimeter of the figure as Double value.</returns>
        double CalcPerimeter();

        /// <summary>
        /// Calculates the area of the figure.
        /// </summary>
        /// <returns>Calculated area of the figure as Double value.</returns>
        double CalcSurface();
    }
}