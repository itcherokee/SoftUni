namespace MySchool
{
    using System;

    public abstract class Person : ICommentable
    {
        private string firstName;
        private string lastName;

        protected Person(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        /// <summary>
        /// Gets or sets first name of the person.
        /// </summary>
        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            private set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    this.firstName = value;
                }
                else
                {
                    throw new ArgumentException("First name can not be null, empty or whitespace!");
                }
            }
        }

        /// <summary>
        /// Gets or sets last name of the person.
        /// </summary>
        public string LastName
        {
            get
            {
                return this.lastName;
            }

            private set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    this.lastName = value;
                }
                else
                {
                    throw new ArgumentException("Last name can not be null, empty or whitespace!");
                }
            }
        }

        /// <summary>
        /// Gets full name: combination of First + Second names.
        /// `</summary>
        public string FullName
        {
            get
            {
                return this.FirstName + " " + this.LastName;
            }
        }

        /// <summary>
        /// Gets or sets details for the person.
        /// </summary>
        public string Details { get; set; }
    }
}