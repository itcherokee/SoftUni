namespace Estates.Data
{
    using System;
    using System.Text;
    using Interfaces;

    public abstract class BuildingEstate : Estate, IBuildingEstate
    {
        private const int BuildingEstateRoomsLowerBorder = 0;
        private const int BuildingEstateRoomsUpperBorder = 20;
        private int rooms;

        protected BuildingEstate(EstateType type)
            : base(type)
        {
            this.Rooms = BuildingEstateRoomsLowerBorder;
            this.HasElevator = false;
        }

        public int Rooms
        {
            get
            {
                return this.rooms;
            }
            set
            {
                if (value < BuildingEstateRoomsLowerBorder || value > BuildingEstateRoomsUpperBorder)
                {
                    throw new ArgumentOutOfRangeException(
                        "value", string.Format("Building's room count must be in the range [{0}...{1}]", BuildingEstateRoomsLowerBorder, BuildingEstateRoomsUpperBorder));
                }

                this.rooms = value;
            }
        }

        public bool HasElevator { get; set; }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendFormat(
                "{0}, Rooms: {1}, Elevator: {2}",
                base.ToString(),
                this.Rooms,
                this.HasElevator ? "Yes" : "No");

            return output.ToString();
        }
    }
}