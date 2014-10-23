// ********************************
// <copyright file="OffsiteCourse.cs" company="SoftUni">
// Copyright (c) 2014 SoftUni. All rights reserved.
// </copyright>
//
// ********************************
namespace InheritanceAndPolymorphism
{
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Represents a local course with additional information for town where the course take place.
    /// </summary>
    public class OffsiteCourse : Course
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OffsiteCourse"/> class.
        /// </summary>
        /// <param name="name">Course name.</param>
        /// <param name="town">Town where course take place.</param>
        public OffsiteCourse(string name, string town = null)
            : base(name)
        {
            this.Town = town;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OffsiteCourse"/> class.
        /// </summary>
        /// <param name="name">Course name.</param>
        /// <param name="teacherName">Course teacher.</param>
        /// <param name="town">Town where course take place.</param>
        public OffsiteCourse(string name, string teacherName, string town = null)
            : base(name, teacherName)
        {
            this.Town = town;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OffsiteCourse"/> class.
        /// </summary>
        /// <param name="name">Course name.</param>
        /// <param name="teacherName">Course teacher.</param>
        /// <param name="students">Students enrolled in course.</param>
        /// <param name="town">Town where course take place.</param>
        public OffsiteCourse(string name, string teacherName, IList<string> students, string town = null)
            : base(name, teacherName, students)
        {
            this.Town = town;
        }

        /// <summary>
        /// Gets or sets town where the course take place.
        /// </summary>
        public string Town { get; set; }

        /// <summary>
        /// Convert <see cref="OffsiteCourse"/> properties to System.String.
        /// </summary>
        /// <returns>System.String representing <see cref="OffsiteCourse"/> properties.</returns>
        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append("OffsiteCourse");
            result.Append(base.ToString());
            if (this.Town != null)
            {
                result.Append("; Town = ");
                result.Append(this.Town);
            }

            result.Append(" }");
            return result.ToString();
        }
    }
}
