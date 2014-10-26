using System;
namespace FurnitureManufacturer.Models
{
    using System.Text;
    using Interfaces;

    public class Table : Furniture, ITable
    {
        private decimal length;
        private decimal width;

        public Table(string model, string material, decimal price, decimal height, decimal length, decimal width)
            : base(model, material, price, height)
        {
            this.Length = length;
            this.Width = width;
        }

        public decimal Length
        {
            get
            {
                return this.length;

            }

            private set
            {
                if (value <= 0.0m)
                {
                    throw new ArgumentException("Length cannot be zero or less than zero.");
                }

                this.length = value;
            }
        }

        public decimal Width
        {
            get
            {
                return this.width;

            }

            private set
            {
                if (value <= 0.0m)
                {
                    throw new ArgumentException("Width cannot be zero or less than zero.");
                }

                this.width = value;
            }
        }

        public decimal Area
        {
            get
            {
                return this.Length * this.Width;
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.Append(base.ToString());
            output.AppendFormat(", Length: {0}, Width: {1}, Area: {2}", this.Length, this.Width, this.Area);

            return output.ToString();
        }
    }
}
