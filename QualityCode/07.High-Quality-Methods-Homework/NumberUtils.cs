// ********************************
// <copyright file="NumberUtils.cs" company="SoftUni">
// Copyright (c) 2014 SoftUni. All rights reserved.
// </copyright>
//
// ********************************
namespace Methods
{
    using System;

    /// <summary>
    /// Contains utils to manipulate numbers.
    /// </summary>
    public static class NumberUtils
    {
        /// <summary>
        /// Represents different output formats.
        /// </summary>
        public enum OutputFormat
        {
            Float,
            Percentage,
            Normal
        }

        /// <summary>
        /// Returns name in english of single digit. 
        /// </summary>
        /// <param name="inputNumber">Single digit.</param>
        /// <exception cref="ArgumentException">Thrown if argument provided is not a single digit.</exception>
        /// <returns>English word of the provided digit.</returns>
        public static string ConvertSingleDigitToWord(int inputNumber)
        {
            if ((int)(Math.Log10(inputNumber) + 1) < 2)
            {
                string[] words = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
                if (inputNumber < 0)
                {
                    return "minus " + words[Math.Abs(inputNumber)];
                }

                return words[inputNumber];
            }

            throw new ArgumentException("Argument provided is not a single digit.");
        }

        /// <summary>
        /// Find maximal number in provided range of numbers.
        /// </summary>
        /// <param name="numbers">Range of integer elements.</param>
        /// <exception cref="ArgumentException">Thrown if there is no arguments provided (null or empty collection).</exception>
        /// <returns>Maximal element in provided range.</returns>
        public static int FindMaxNumber(params int[] numbers)
        {
            if (numbers != null && numbers.Length != 0)
            {
                var workingElements = new int[numbers.Length];
                numbers.CopyTo(workingElements, 0);
                int maxElement = workingElements[0];
                for (int i = 1; i < numbers.Length; i++)
                {
                    if (workingElements[i] > maxElement)
                    {
                        maxElement = numbers[i];
                    }
                }

                return maxElement;
            }

            throw new ArgumentException("No arguments provided.");
        }

        /// <summary>
        /// Formats number as requested by <paramref name="outputFormat"/>.
        /// </summary>
        /// <param name="number">Number to be formatted.</param>
        /// <param name="outputFormat">Format to be applied.</param>
        /// <exception cref="ArgumentNullException">Thrown when no number parameter is provided.</exception>
        /// <exception cref="ArgumentException">Thrown when invalid format parameted is provided.</exception>
        /// <returns>Formatted number as string.</returns>
        public static string FormatNumber(object number, OutputFormat outputFormat)
        {
            double parsedNumber;
            if (number != null && double.TryParse(number.ToString(), out parsedNumber))
            {
                if (Enum.IsDefined(typeof(OutputFormat), outputFormat))
                {
                    string result;
                    switch (outputFormat)
                    {
                        case OutputFormat.Float:
                            result = string.Format("{0:f2}", number);
                            break;
                        case OutputFormat.Percentage:
                            result = string.Format("{0:p0}", number);
                            break;
                        case OutputFormat.Normal:
                            result = string.Format("{0,8}", number);
                            break;
                        default:
                            throw new ArgumentException("Illegal format parameter provided!");
                    }

                    return result;
                }

                throw new ArgumentException("Invalid format argument provided!");
            }

            throw new ArgumentNullException("number", "No number provided to be formated!");
        }
    }
}
