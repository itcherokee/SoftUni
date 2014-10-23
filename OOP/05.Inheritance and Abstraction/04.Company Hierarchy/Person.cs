namespace Company
{
    using System;

    public abstract class Person : IPerson
    {
        private string firstName;
        private string lastName;

        protected Person(string firstName, string lastName, uint id)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public uint Id { get; set; }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("First name cannot be null, empty or white space.");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Last name cannot be null, empty or white space.");
                }

                this.lastName = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Name: {0} {1} (Id: {2})", this.FirstName, this.LastName, this.Id);
        }
    }
}
