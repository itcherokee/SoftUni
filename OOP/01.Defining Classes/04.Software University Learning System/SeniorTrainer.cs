namespace Learn
{
    public class SeniorTrainer : Trainer
    {
        /// <summary>
        /// Initialize an instance of <see cref="SeniorTrainer"/> class.
        /// </summary>
        /// <param name="fname">First name of the trainer.</param>
        /// <param name="lname">Last name of the trainer.</param>
        /// <param name="age">Current age of the trainer.</param>
        public SeniorTrainer(string fname, string lname, int age)
            : base(fname, lname, age)
        {
        }

        // method DeleteCourse([courseName]) that prints that the course has been deleted

        /// <summary>
        /// Delete an existing course.
        /// </summary>
        /// <param name="courseName">Name of the course to be deleted.</param>
        /// <returns>String.string.</returns>
        public string DeleteCourse(string courseName)
        {
            return string.Format("Course \"{0}\" has been deleted.", courseName);
        }
    }
}
