// ********************************
// <copyright file="FileUtils.cs" company="SoftUni">
// Copyright (c) 2014 SoftUni. All rights reserved.
// </copyright>
//
// ********************************
namespace CohesionAndCoupling
{
    using System;

    /// <summary>
    /// Class containing methods to operate over file names.
    /// </summary>
    public static class FileUtils
    {
        /// <summary>
        /// Extracts file name extension.
        /// </summary>
        /// <param name="fileName">Initial file name string.</param>
        /// <returns>Only file name extension.</returns>
        public static string GetFileExtension(string fileName)
        {
            if (fileName != null)
            {
                int indexOfLastDot = fileName.LastIndexOf(".", StringComparison.Ordinal);
                if (indexOfLastDot == -1)
                {
                    return null;
                }

                string extension = fileName.Substring(indexOfLastDot + 1);
                return extension;
            }

            throw new ArgumentNullException("Null value provided as filename parameter!.");
        }

        /// <summary>
        /// Extracts file name without extension.
        /// </summary>
        /// <param name="fileName">Initial file name string.</param>
        /// <returns>Only file name without extension.</returns>
        public static string GetFileNameWithoutExtension(string fileName)
        {
            if (fileName != null)
            {
                int indexOfLastDot = fileName.LastIndexOf(".", System.StringComparison.Ordinal);
                if (indexOfLastDot == -1)
                {
                    return fileName;
                }

                string extension = fileName.Substring(0, indexOfLastDot);
                return extension;
            }

            throw new ArgumentNullException("Null value provided as filename parameter!.");
        }
    }
}
