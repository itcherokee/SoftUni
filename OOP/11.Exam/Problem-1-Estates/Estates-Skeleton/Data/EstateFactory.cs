using Estates.Engine;
using Estates.Interfaces;
using System;

namespace Estates.Data
{
    public class EstateFactory
    {
        public static IEstateEngine CreateEstateEngine()
        {
            return new UpgradedEstateEngine();
        }

        public static IEstate CreateEstate(EstateType type)
        {
            switch (type)
            {
                case EstateType.Apartment:
                    return new Apartment();
                    break;
                case EstateType.Office:
                    return new Office();
                    break;
                case EstateType.House:
                    return new House();
                    break;
                case EstateType.Garage:
                    return new Garage();
                    break;
                default:
                    throw new ArgumentOutOfRangeException("type", "Invalid Estate type specified.");
            }
        }

        public static IOffer CreateOffer(OfferType type)
        {
            switch (type)
            {
                case OfferType.Sale:
                    return new SaleOffer();
                    break;
                case OfferType.Rent:
                    return new RentOffer();
                    break;
                default:
                    throw new ArgumentOutOfRangeException("type", "Invalid Offer type specified.");
            }
        }
    }
}
