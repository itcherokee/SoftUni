namespace FurnitureManufacturer.Models
{
    using System;
    using System.Text;
    using Interfaces;

    public class Chair : Furniture, IChair
    {
        private int numberOfLegs;

        public Chair(string model, string material, decimal price, decimal height, int numberOfLegs)
            : base(model, material, price, height)
        {
            this.NumberOfLegs = numberOfLegs;
        }

        public int NumberOfLegs
        {
            get
            {
                return this.numberOfLegs;

            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Number of chair's legs cannot be zero or less (negaitve).");
                }

                this.numberOfLegs = value;
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.Append(base.ToString());
            output.AppendFormat(", Legs: {0}", this.NumberOfLegs);

            return output.ToString();
        }
    }
}
