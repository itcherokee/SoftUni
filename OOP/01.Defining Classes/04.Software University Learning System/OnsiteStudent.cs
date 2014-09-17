namespace Learn
{
    using System;
    using System.Text;

    public class OnsiteStudent : CurrentStudent
    {
        private int numberOfVisits;

        /// <summary>
        /// Initialize a new instance of <see cref="OnlineStudent"/> class.
        /// </summary>
        /// <param name="fname">First name of the student.</param>
        /// <param name="lname">Second name of the student.</param>
        /// <param name="age">Current age of the student.</param>
        /// <param name="studentNumber">Student number.</param>
        /// <param name="averageGrade">Current average grade of student.</param>
        /// <param name="numberOfVisits">Number of visits on site by student.</param>
        /// <param name="currentCourse">Current course that student is enrolled.</param>
        public OnsiteStudent(string fname, string lname, int age, int studentNumber, double averageGrade, int numberOfVisits, string currentCourse)
            : base(fname, lname, age, studentNumber, averageGrade, currentCourse)
        {
            this.NumberOfVisits = numberOfVisits;
        }

        /// <summary>
        /// Gets or sets the number of visits in Univercity.
        /// </summary>
        public int NumberOfVisits
        {
            get
            {
                return this.numberOfVisits;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("It is not allowed to have negative visits.");
                }

                this.numberOfVisits = value;
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
            output.AppendFormat("Number of visits: {0}", this.NumberOfVisits);
            return output.ToString();
        }
    }
}
