namespace Estates.Data
{
    using System;
    using System.Text;
    using Interfaces;
    
    public abstract class Estate : IEstate
    {
        protected const string UnknownYet = "Unknown";
        private const double AreaLowerBorder = 0;
        private const double AreaUpperBorder = 10000;
        private double area;
        private string name;
        private EstateType type;
        private string location;


        protected Estate(EstateType type)
        {
            this.Name = UnknownYet;
            this.Area = AreaLowerBorder;
            this.Location = UnknownYet;
            this.IsFurnished = false;
            this.Type = type;
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
                    throw new ArgumentException("Estate name cannot be null, empty or white space.");
                }

                this.name = value;
            }
        }

        public EstateType Type
        {
            get
            {
                return this.type;
            }

            set
            {
                if (!Enum.IsDefined(typeof(EstateType), value))
                {
                    throw new ArgumentException("Invalid type of estate nas been specified.");
                }

                this.type = value;
            }

        }

        public double Area
        {
            get
            {
                return this.area;
            }

            set
            {
                if (value < AreaLowerBorder || value > AreaUpperBorder)
                {
                    throw new ArgumentOutOfRangeException(
                        "value", string.Format("Area must be in the range [{0}...{1}]", AreaUpperBorder, AreaUpperBorder));
                }

                this.area = value;
            }

        }

        public string Location
        {
            get
            {
                return this.location;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Estate location cannot be null, empty or white space.");
                }

                this.location = value;
            }
        }

        public bool IsFurnished { get; set; }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendFormat(
                "{0}: Name = {1}, Area = {2}, Location = {3}, Furnitured = {4}",
                this.Type,
                this.Name,
                this.Area,
                this.Location,
                this.IsFurnished ? "Yes" : "No");

            return output.ToString();
        }
    }
}