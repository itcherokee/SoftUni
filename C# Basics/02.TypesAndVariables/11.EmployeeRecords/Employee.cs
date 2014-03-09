namespace PrimitiveDataTypesAndVariables
{
    using System;

    /// <summary>
    /// Task:   11. A marketing company wants to keep record of its employees. Each record would have 
    ///         the following characteristics:
    ///         •	First name
    ///         •	Last name
    ///         •	Age (0...100)
    ///         •	Gender (m or f)
    ///         •	Personal ID number (e.g. 8306112507)
    ///         •	Unique employee number (27560000…27569999)
    ///         Declare the variables needed to keep the information for a single employee using appropriate 
    ///         primitive data types. Use descriptive names. Print the data at the console.
    /// </summary>
    public class Employee
    {
        private char gender;
        private int employeeId;
        private byte age;
        private string personalId;

        public char Gender
        {
            get
            {
                return this.gender;
            }

            set
            {
                if (value == 'm' || value == 'f')
                {
                    this.gender = value;
                }
                else
                {
                    throw new ArgumentException("Invalid value provided for Gender!");
                }
            }
        }

        public string FirstName { get; set; }

        public string FamilyName { get; set; }

        public byte Age
        {
            get
            {
                return this.age;
            }

            set
            {
                if (value <= 100) // range below 0 is checked by compiler as underlying type is byte
                {
                    this.age = value;
                }
                else
                {
                    throw new ArgumentException("Invalid value provided for Age!");
                }
            }
        }

        public string PersonalId
        {
            get
            {
                return this.personalId;
            }

            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    this.personalId = value;
                }
                else
                {
                    throw new ArgumentException("Invalid value provided for EmployeeID!");
                }
            }
        }

        public int EmployeeId
        {
            get
            {
                return this.employeeId;
            }

            set
            {
                if (value >= 27560000 && value <= 27569999)
                {
                    this.employeeId = value;
                }
                else
                {
                    throw new ArgumentException("Invalid value provided for EmployeeID!");
                }
            }
        }
    }

}