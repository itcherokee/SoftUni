namespace Learn
{
    using System.Text;

    public class DropoutStudent : Student
    {
        private string dropoutReason;

        /// <summary>
        /// Initialize a new instance of <see cref="DropoutStudent"/> class.
        /// </summary>
        /// <param name="fname">First name of the student.</param>
        /// <param name="lname">Last name of the student.</param>
        /// <param name="age">Current age of the student.</param>
        /// <param name="studentNumber">Student number.</param>
        /// <param name="averageGrade">Current average grade of the student.</param>
        /// <param name="dropoutReason">Reason for dropout.</param>
        public DropoutStudent(string fname, string lname, int age, int studentNumber, double averageGrade, string dropoutReason)
            : base(fname, lname, age, studentNumber, averageGrade)
        {
            this.DropoutReason = dropoutReason;
        }

        /// <summary>
        /// Gets or sets a dropout reason.
        /// </summary>
        public string DropoutReason
        {
            get
            {
                return this.dropoutReason;
            }

            set
            {
                Utils.ValidateStringInput(value, "Dropout Reason");
                this.dropoutReason = value;
            }
        }

        /// <summary>
        /// Prints all information about a student
        /// </summary>
        /// <returns>String.string.</returns>
        public string Reapply()
        {
            return this.ToString();
        }

        /// <summary>
        /// Converts the value of this instance to a string representation.
        /// </summary>
        /// <returns>Returns System.String.</returns>
        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendLine(base.ToString());
            output.AppendFormat("Dropout reason: {0}", this.DropoutReason);
            return output.ToString();
        }
    }
}
