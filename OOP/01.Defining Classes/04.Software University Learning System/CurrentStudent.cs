namespace Learn
{
    using System.Text;

    public abstract class CurrentStudent : Student
    {
        private string currentCourse;

        /// <summary>
        /// Initialize a new instance of <see cref="OnlineStudent"/> class.
        /// </summary>
        /// <param name="fname">First name of the student.</param>
        /// <param name="lname">Second name of the student.</param>
        /// <param name="age">Current age of the student.</param>
        /// <param name="studentNumber">Student number.</param>
        /// <param name="averageGrade">Current average grade of student.</param>
        /// <param name="currentCourse">Current course that student is enrolled.</param>
        protected CurrentStudent(string fname, string lname, int age, int studentNumber, double averageGrade, string currentCourse)
            : base(fname, lname, age, studentNumber, averageGrade)
        {
            this.CurrentCourse = currentCourse;
        }

        /// <summary>
        /// Gets or sets the current enrolled course.
        /// </summary>
        public string CurrentCourse
        {
            get
            {
                return this.currentCourse;
            }

            set
            {
                Utils.ValidateStringInput(value, "Current Course");
                this.currentCourse = value;
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
            output.AppendFormat("CurrentCourse: {0}", this.CurrentCourse);
            return output.ToString();
        }
    }
}
