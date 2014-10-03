// Task 01: Define a class Person that has name, age and email. The name and age are mandatory. 
//          The email is optional. Define properties that accept non-empty name and age in
//          the range [1...100]. In case of invalid argument, throw an exception. Define 
//          a property for the email that accepts either null or non-empty string containing '@'. 
//          Define two constructors. The first constructor should take name, age and email. 
//          The second constructor should take name and age only and call the first constructor. 
//          Implement the ToString() method to enable printing persons at the console.

namespace Person
{
    using System;
    using System.Text;

    public class Person
    {
        private string name;
        private int age;
        private string email;

        /// <summary>
        /// Initialize an instance of <see cref="Person"/> class.
        /// </summary>
        /// <param name="name">Person's name.</param>
        /// <param name="age">Person's age.</param>
        public Person(string name, int age)
            : this(name, age, null)
        {
        }

        /// <summary>
        /// Initialize an instance of <see cref="Person"/> class.
        /// </summary>
        /// <param name="name">Person's name.</param>
        /// <param name="age">Person's age.</param>
        /// <param name="email">Person's email (optional).</param>
        public Person(string name, int age, string email)
        {
            this.Name = name;
            this.Age = age;
            this.Email = email;
        }

        /// <summary>
        /// Gets or sets person's email.
        /// </summary>
        public string Email
        {
            get
            {
                return this.email;
            }

            set
            {
                if (value == null || value.IndexOf('@') >= 0)
                {
                    this.email = value;
                }

                throw new ArgumentOutOfRangeException("Email", "Email could only be NULL or valid e-mail!");
            }
        }

        /// <summary>
        /// Gets or sets person's name.
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException("Name", "Name must be not null, empty or whitespace!");
                }

                this.name = value;
            }
        }

        /// <summary>
        /// Gets or sets person's age.
        /// </summary>
        public int Age
        {
            get
            {
                return this.age;
            }

            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("Age", message: "Age cannot be a negative value!");
                }

                if (value > 100)
                {
                    throw new ArgumentOutOfRangeException("Age", "You are too old to be recorded in the system!");
                }

                this.age = value;
            }
        }

        /// <summary>
        /// Converts the value of this instance to a string representation.
        /// </summary>
        /// <returns>Returns System.String.</returns>
        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendLine(string.Format("Name: {0}", this.Name));
            if (this.Email != null)
            {
                output.AppendLine(string.Format("Age: {0}", this.Age));
                output.Append(string.Format("Email: {0}", this.Email));
            }
            else
            {
                output.AppendFormat("Age: {0}", this.Age);
            }

            return output.ToString();
        }
    }
}
