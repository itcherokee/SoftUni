namespace Learn
{
    using System.Text;

    public abstract class Student : Person
    {
        private int studentNumber;
        private double averageGrade;

        /// <summary>
        /// Initialize a new instance of <see cref="Student"/> class.
        /// </summary>
        /// <param name="fname">First name of the student.</param>
        /// <param name="lname">Second name of the student.</param>
        /// <param name="age">Current age of the student.</param>
        /// <param name="studentNumber">Student number.</param>
        /// <param name="averageGrade">Current average grade of student.</param>
        protected Student(string fname, string lname, int age, int studentNumber, double averageGrade = 0.0)
            : base(fname, lname, age)
        {
            this.StudentNumber = studentNumber;
            this.AverageGrade = averageGrade;
        }

        /// <summary>
        /// Gets or sets the Student number.
        /// </summary>
        public int StudentNumber
        {
            get
            {
                return this.studentNumber;
            }

            set
            {
                Utils.ValidateNumericInput(value, "StudentNumber");
                this.studentNumber = value;
            }
        }

        /// <summary>
        /// Gets or sets current student's average grade.
        /// </summary>
        public double AverageGrade
        {
            get
            {
                return this.averageGrade;
            }

            set
            {
                Utils.ValidateNumericInput((decimal)value, "Average Grade");
                this.averageGrade = value;
            }
        }

        /// <summary>
        /// Converts the value of this instance to a string representation.
        /// </summary>
        /// <returns>Returns System.String.</returns>
        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendLine(base.ToString());
            output.AppendLine(string.Format("Student number: {0}", this.StudentNumber));
            output.AppendFormat("Average Grade: {0:N2}", this.AverageGrade);
            return output.ToString();
        }
    }
}
