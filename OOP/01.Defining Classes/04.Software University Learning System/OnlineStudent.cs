namespace Learn
{
    public class OnlineStudent : CurrentStudent
    {
        /// <summary>
        /// Initialize a new instance of <see cref="OnlineStudent"/> class.
        /// </summary>
        /// <param name="fname">First name of the student.</param>
        /// <param name="lname">Second name of the student.</param>
        /// <param name="age">Current age of the student.</param>
        /// <param name="studentNumber">Student number.</param>
        /// <param name="averageGrade">Current average grade of student.</param>
        /// <param name="currentCourse">Current course that student is enrolled.</param>
        public OnlineStudent(string fname, string lname, int age, int studentNumber, double averageGrade, string currentCourse)
            : base(fname, lname, age, studentNumber, averageGrade, currentCourse)
        {
        }
    }
}