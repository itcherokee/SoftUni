namespace Estates.Data
{
    using System;
    using System.Text;
    using Interfaces;

    public class House : Estate, IHouse
    {
        private const int HouseFloorLowerBorder = 0;
        private const int HouseFloorUpperBorder = 10;
        private int floors;


        public House()
            : base(EstateType.House)
        {
            this.Floors = HouseFloorLowerBorder;
        }

        public int Floors
        {
            get
            {
                return this.floors;
            }
            set
            {
                if (value < HouseFloorLowerBorder || value > HouseFloorUpperBorder)
                {
                    throw new ArgumentOutOfRangeException(
                        "value", string.Format("House floors must be in the range [{0}...{1}]", HouseFloorLowerBorder, HouseFloorUpperBorder));
                }

                this.floors = value;
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendFormat(
                "{0}, Floors: {1}",
                base.ToString(),
                this.Floors);

            return output.ToString();
        }
    }
}