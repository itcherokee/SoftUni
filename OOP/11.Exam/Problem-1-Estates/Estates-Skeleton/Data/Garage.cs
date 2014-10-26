namespace Estates.Data
{
    using System;
    using System.Text;
    using Interfaces;

    public class Garage : Estate, IGarage
    {
        private const int GarageWidthLowerBorder = 0;
        private const int GarageWidthUpperBorder = 500;
        private const int GarageHeightLowerBorder = 0;
        private const int GarageHeightUpperBorder = 500;
        private int width;
        private int height;

        public Garage()
            : base(EstateType.Garage)
        {
            this.Width = GarageWidthLowerBorder;
            this.Height = GarageHeightLowerBorder;
        }

        public int Width
        {
            get
            {
                return this.width;
            }
            set
            {
                if (value < GarageWidthLowerBorder || value > GarageWidthUpperBorder)
                {
                    throw new ArgumentOutOfRangeException(
                        "value", string.Format("Garage width must be in the range [{0}...{1}]", GarageWidthLowerBorder, GarageWidthUpperBorder));
                }

                this.width = value;
            }
        }

        public int Height
        {
            get
            {
                return this.height;
            }
            set
            {
                if (value < GarageHeightLowerBorder || value > GarageHeightUpperBorder)
                {
                    throw new ArgumentOutOfRangeException(
                        "value", string.Format("Garage height must be in the range [{0}...{1}]", GarageHeightLowerBorder, GarageHeightUpperBorder));
                }

                this.height = value;
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendFormat(
                "{0}, Width: {1}, Height: {2}",
                base.ToString(),
                this.Width,
                this.Height);

            return output.ToString();
        }
    }
}