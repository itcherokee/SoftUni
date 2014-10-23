namespace People
{
    using System;
    using System.Text;

    public class Student : Human
    {
        private string facultyNumber;

        /// <summary>
        /// Initializes a new instance of the <see cref="Student"/> class.
        /// </summary>
        /// <param name="firstName">First name of the student.</param>
        /// <param name="lastName">Last name of the student.</param>
        /// <param name="facultyNumber">Faculty number of the student.</param>
        public Student(string firstName, string lastName, string facultyNumber)
            : base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        /// <summary>
        /// Gets or sets Faculty number.
        /// </summary>
        public string FacultyNumber
        {
            get
            {
                return this.facultyNumber;
            }

            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    if (value.Length >= 5 || value.Length <= 10)
                    {
                        this.facultyNumber = value;
                    }
                    else
                    {
                        throw new ArgumentException("Not valid grade score provided!");
                    }
                }
                else
                {
                    throw new ArgumentNullException("value", "Faculty number cannot be null, empty or white space!");
                }
            }
        }

        /// <summary>
        /// Converts this instance to string representation.
        /// </summary>
        /// <returns>string.String.</returns>
        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendFormat("{0} (Faculty number: {1})", base.ToString(), this.FacultyNumber);

            return output.ToString();
        }
    }
}
