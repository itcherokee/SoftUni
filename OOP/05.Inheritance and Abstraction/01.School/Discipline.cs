namespace MySchool
{
    using System;
    using System.Text;

    public class Discipline : ICommentable
    {
        private string name;

        /// <summary>
        /// Instantiates an object of type Discipline.
        /// </summary>
        /// <param name="name">Name of the discipline.</param>
        /// <param name="numberOfLectures">Number of Lectures in that discipline.</param>
        /// <param name="numberOfExercises">Number of Excersizes in that discipline.</param>
        public Discipline(string name, int numberOfLectures = 0, int numberOfExercises = 0)
        {
            this.Name = name;
            this.NumberOfLectures = numberOfLectures;
            this.NumberOfExercises = numberOfExercises;
        }

        /// <summary>
        /// Gets or sets discipline name.
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    this.name = value;
                }
                else
                {
                    throw new ArgumentNullException("value", "Discipline name cannot be null, empty or whitespace!");
                }
            }
        }

        /// <summary>
        /// Gets or sets discipline number of lectures.
        /// </summary>
        public int NumberOfLectures { get; private set; }

        /// <summary>
        /// Gets or sets discipline number of students.
        /// </summary>
        public int NumberOfExercises { get; private set; }

        /// <summary>
        /// Gets or sets additional details for discipline.
        /// </summary>
        public string Details { get; set; }

        /// <summary>
        /// Converts the Discipline instance to a string representation.
        /// </summary>
        /// <returns>String value</returns>
        public override string ToString()
        {
            var output = new StringBuilder();
            output.Append(this.Name);
            output.Append(" (Lectures:");
            output.Append(this.NumberOfLectures);
            output.Append(", Exercises:");
            output.Append(this.NumberOfExercises);
            output.Append(")");
            return output.ToString();
        }
    }
}