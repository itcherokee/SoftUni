using System;

namespace Person
{
    public class Person
    {
        private string name;
        private int age;
        private string email;


        public Person(string name, int age, string email = "none")
        {
            this.Name = name;
            this.Age = age;
            this.Email = email;
        }

        public string Email
        {
            get
            {
                return this.email;
            }

            set
            {
                this.email = value;
            }
        }


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
                    throw new ArgumentOutOfRangeException("Name must be not null, empty or whitespace!");
                }

                this.name = value;
            }
        }

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
                    throw new ArgumentOutOfRangeException("Age cannot be a negative value!");
                }
                
                if (value > 100)
                {
                    throw new ArgumentOutOfRangeException("You are too old to be recorded in the system!");
                }

                this.age = value;
            }
        }

    }
}
