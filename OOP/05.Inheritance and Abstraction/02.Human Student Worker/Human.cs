namespace People
{
    using System;
    using System.Text;

    public abstract class Human
    {
        private string firstName;
        private string lastName;

        protected Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

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

        public override string ToString()
        {
            var output = new StringBuilder();
            output.Append(this.FirstName);
            output.Append(" ");
            output.Append(this.LastName);
            return output.ToString();
        }
    }
}
