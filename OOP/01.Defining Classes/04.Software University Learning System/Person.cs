namespace Learn
{
    using System.Text;

    public abstract class Person
    {
        private string firstName;
        private string lastName;
        private int age;

        /// <summary>
        /// Initialize an instance of the <see cref="Person"/> class.
        /// </summary>
        /// <param name="fname">First name of the person.</param>
        /// <param name="lname">Second name of the person.</param>
        /// <param name="age">Current age of the person.</param>
        protected Person(string fname, string lname, int age)
        {
            this.FirstName = fname;
            this.LastName = lname;
            this.Age = age;
        }

        /// <summary>
        /// Gets or sets First Name.
        /// </summary>
        protected string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                Utils.ValidateStringInput(value, "Name");
                this.firstName = value;
            }
        }

        /// <summary>
        /// Gets or sets Last Name.
        /// </summary>
        protected string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                Utils.ValidateStringInput(value, "Name");
                this.lastName = value;
            }
        }

        /// <summary>
        /// Gets or sets Age.
        /// </summary>
        protected int Age
        {
            get
            {
                return this.age;
            }

            set
            {
                Utils.ValidateNumericInput(value, "Name");
                this.age = value;
            }
        }

        /// <summary>
        /// Gets full name of the person.
        /// </summary>
        protected string FullName
        {
            get
            {
                return string.Format("{0} {1}", this.FirstName, this.LastName);
            }
        }

        /// <summary>
        /// Converts the value of this instance to a string representation.
        /// </summary>
        /// <returns>Returns System.String.</returns>
        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendLine(string.Format("Name: {0}", this.FullName));
            output.AppendFormat("Age: {0}", this.Age);
            return output.ToString();
        }
    }
}
