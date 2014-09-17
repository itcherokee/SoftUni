namespace Learn
{
    public class GraduateStudent : Student
    {
        /// <summary>
        /// Initialize an instance of <see cref="GraduateStudent"/> class.
        /// </summary>
        /// <param name="fname">First name of the student.</param>
        /// <param name="lname">Second name of the student.</param>
        /// <param name="age">Current age of the student.</param>
        /// <param name="studentNumber">Student number.</param>
        /// <param name="averageGrade">Current average grade of student.</param>
        public GraduateStudent(string fname, string lname, int age, int studentNumber, double averageGrade = 0)
            : base(fname, lname, age, studentNumber, averageGrade)
        {
        }
    }
}
