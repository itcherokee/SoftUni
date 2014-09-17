namespace Learn
{
    public abstract class Trainer : Person
    {
        /// <summary>
        /// Initialize a new instance of <see cref="Trainer"/> class.
        /// </summary>
        /// <param name="fname">First name of the trainer.</param>
        /// <param name="lname">Last name of the trainer.</param>
        /// <param name="age">Current age of the trainer.</param>
        protected Trainer(string fname, string lname, int age)
            : base(fname, lname, age)
        {
        }

        /// <summary>
        /// Create a new instance of Course class.
        /// </summary>
        /// <param name="courseName">Name of the course.</param>
        /// <returns>Newely created instance of Course.</returns>
        protected string CreateCourse(string courseName)
        {
            return string.Format("Course \"{0}\" has been successfuly created.", courseName);
        }
    }
}
