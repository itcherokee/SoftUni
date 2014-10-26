namespace Estates.Data
{
    using Interfaces;

    public class Apartment : BuildingEstate, IApartment
    {
        public Apartment()
            : base(EstateType.Apartment)
        {
        }
    }
}