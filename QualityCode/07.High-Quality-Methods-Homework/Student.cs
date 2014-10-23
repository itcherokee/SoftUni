// ********************************
// <copyright file="Student.cs" company="SoftUni">
// Copyright (c) 2014 SoftUni. All rights reserved.
// </copyright>
//
// ********************************
namespace Methods
{
    using System;

    /// <summary>
    /// Represents a Student object.
    /// </summary>
    public class Student
    {
        private string firstName;
        private string lastName;
        private string town;
        private DateTime birthday;
        private string notes;

        /// <summary>
        /// Initializes a new instance of the <see cref="Student"/> class.
        /// </summary>
        /// <param name="firstName">Student's first name.</param>
        /// <param name="lastName">Student's last name.</param>
        /// <param name="town">Student's home town.</param>
        /// <param name="birthday">Student's birthday.</param>
        /// <param name="notes">Additional information for the student.</param>
        public Student(string firstName, string lastName, string town, DateTime birthday, string notes = "")
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.town = town;
            this.birthday = birthday;
            this.notes = notes;
        }

        /// <summary>
        /// Gets or sets first name of the student.
        /// </summary>
        /// <exception cref="ArgumentException">Property is null, empty or white space.</exception>
        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("First name cannot be null, empty or white space.");
                }

                this.firstName = value;
            }
        }

        /// <summary>
        /// Gets or sets last name of the student.
        /// </summary>
        /// <exception cref="ArgumentException">Property is null, empty or white space.</exception>
        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Last name cannot be null, empty or white space.");
                }

                this.lastName = value;
            }
        }

        /// <summary>
        /// Gets or sets student's home town.
        /// </summary>
        /// <exception cref="ArgumentException">Property is null, empty or white space.</exception>
        public string HomeTown
        {
            get
            {
                return this.town;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Home town cannot be null, empty or white space.");
                }

                this.town = value;
            }
        }

        /// <summary>
        /// Gets or sets notes for current <see cref="Student"/> instance.
        /// </summary>\
        /// <exception cref="ArgumentNullException">Property is null.</exception>
        public string Notes
        {
            get
            {
                return this.notes;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value", "Notes cannot be null.");
                }

                this.notes = value;
            }
        }

        /// <summary>
        /// Gets or sets <see cref="Student"/> birthday.
        /// </summary>
        /// <exception cref="ArgumentException">When birthday is today or later.</exception>
        public DateTime Birthdate
        {
            get
            {
                return this.birthday;
            }

            set
            {
                if (value <= DateTime.Today)
                {
                    this.birthday = value;
                }
                else
                {
                    throw new ArgumentException("Birthday must be set appropriately - should be earlier than current moment!");
                }
            }
        }

        /// <summary>
        /// Finds out does age of current instance of <see cref="Student"/> is older then referenced one.
        /// </summary>
        /// <param name="otherStudent">Other referenced student.</param>
        /// <exception cref="ArgumentNullException">Thrown when null object provided to be compared or when one.</exception>
        /// <returns>True if current student is older else false.</returns>
        public bool IsOlderThan(Student otherStudent)
        {
            if (otherStudent != null)
            {
                TimeSpan difference = otherStudent.Birthdate.Date - this.Birthdate.Date;
                if (difference.TotalDays > 1)
                {
                    return true;
                }

                return false;
            }

            throw new ArgumentNullException("otherStudent", "Not a valid object provided to compare birthdays!");
        }
    }
}
