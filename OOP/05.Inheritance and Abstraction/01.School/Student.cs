namespace MySchool
{
    using System.Globalization;
    using System.Text;

    public class Student : Person
    {
        /// <summary>
        /// Instantiate an Student object.
        /// </summary>
        /// <param name="firstName">String value holding Student first name.</param>
        /// <param name="lastName">String value holding Student last name.</param>
        /// <param name="classNumber">Integer value holding unique Student identifier in the class.</param>
        public Student(string firstName, string lastName, uint classNumber)
            : base(firstName, lastName)
        {
            this.ClassNumber = classNumber;
        }

        /// <summary>
        /// Gets or sets student's unique class number.
        /// </summary>
        public uint ClassNumber { get; private set; }

        /// <summary>
        /// Converts the Student instance to a string representation.
        /// </summary>
        /// <returns>String value.</returns>
        public override string ToString()
        {
            var output = new StringBuilder();
            output.Append("Student: ");
            output.Append(this.FullName);
            output.Append(" (Number in the class: ");
            output.Append(this.ClassNumber.ToString(CultureInfo.InvariantCulture));
            output.Append(")");
            return output.ToString();
        }
    }
}