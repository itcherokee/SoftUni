// ********************************
// <copyright file="LocalCourse.cs" company="SoftUni">
// Copyright (c) 2014 SoftUni. All rights reserved.
// </copyright>
//
// ********************************
namespace InheritanceAndPolymorphism
{
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Represents a local course with additional information for laboratory where the course take place.
    /// </summary>
    public class LocalCourse : Course
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LocalCourse"/> class.
        /// </summary>
        /// <param name="name">Course name.</param>
        /// <param name="lab">Laboratory where the course take place.</param>
        public LocalCourse(string name, string lab = null)
            : base(name)
        {
            this.Lab = lab;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalCourse"/> class.
        /// </summary>
        /// <param name="name">Course name.</param>
        /// <param name="teacherName">Course teacher.</param>
        /// <param name="lab">Laboratory where the course take place.</param>
        public LocalCourse(string name, string teacherName, string lab = null)
            : base(name, teacherName)
        {
            this.Lab = lab;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalCourse"/> class.
        /// </summary>
        /// <param name="name">Course name.</param>
        /// <param name="teacherName">Course teacher.</param>
        /// <param name="students">Students enrolled in course.</param>
        /// <param name="lab">Laboratory where the course take place.</param>
        public LocalCourse(string name, string teacherName, IList<string> students, string lab = null)
            : base(name, teacherName, students)
        {
            this.Lab = lab;
        }

        /// <summary>
        /// Gets or sets Laboratory where the course to take place.
        /// </summary>
        public string Lab { get; set; }

        /// <summary>
        /// Convert <see cref="LocalCourse"/> properties to System.String.
        /// </summary>
        /// <returns>System.String representing <see cref="LocalCourse"/> properties.</returns>
        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append("LocalCourse");
            result.Append(base.ToString());
            if (this.Lab != null)
            {
                result.Append("; Lab = ");
                result.Append(this.Lab);
            }

            result.Append(" }");
            return result.ToString();
        }
    }
}
