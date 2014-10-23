// **************************************************************
// <summary>FiguresExample program</summary>
// <copyright file="FiguresExample.cs" company="SoftUni">
// Copyright (c) 2014 SoftUni. All rights reserved.
// </copyright>
// **************************************************************
namespace Abstraction
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Figures example test program.
    /// </summary>
    public class FiguresExample
    {
        /// <summary>
        /// Main program execution entry point.
        /// </summary>
        public static void Main()
        {
            var figures = new List<IFigure>
            {
                new Circle(5),
                new Rectangle(2, 3)
            };

            foreach (IFigure figure in figures)
            {
                Console.WriteLine(
                    "I am a {0}. My perimeter is {1:f2}. My surface is {2:f2}.",
                    figure.GetType().Name,
                    figure.CalcPerimeter(),
                    figure.CalcSurface());
            }
        }
    }
}
