namespace Estates.Data
{
    using System.Linq;
    using Engine;
    using Interfaces;

    class UpgradedEstateEngine : EstateEngine
    {
        public override string ExecuteCommand(string cmdName, string[] cmdArgs)
        {
            switch (cmdName)
            {
                case "find-rents-by-location":
                    return this.ExecuteFindRentsByLocationCommand(cmdArgs[0]);
                    break;
                case "find-rents-by-price":
                    return this.ExecuteFindRentsByPriceCommand(cmdArgs[0], cmdArgs[1]);
                    break;
                default:
                    return base.ExecuteCommand(cmdName, cmdArgs);
                    break;
            }
        }

        private string ExecuteFindRentsByLocationCommand(string location)
        {
            //	find-rents-by-location location – finds and prints all rent offers for 
            // the specified location (case-sensitively), ordered by name, 
            // in the format like in the sample output below.

            var offers = this.Offers
                        .Where(o => o.Estate.Location == location && o.Type == OfferType.Rent)
                        .OrderBy(o => o.Estate.Name);

            return FormatQueryResults(offers);
        }

        private string ExecuteFindRentsByPriceCommand(string minPrice, string maxPrice)
        {
            // find-rents-by-price minPrice maxPrice – prints all rent offers within the specified 
            // price range (inclusively), ordered by price and by name (as second criteria), in the 
            // format like in the sample below.

            decimal startPrice = decimal.Parse(minPrice);
            decimal endPrice = decimal.Parse(maxPrice);

            var offers = this.Offers
                        .Where(o => o.Type == OfferType.Rent)
                        .Cast<RentOffer>()
                        .Where(o => o.PricePerMonth >= startPrice && o.PricePerMonth <= endPrice)
                        .OrderBy(o => o.PricePerMonth)
                        .ThenBy(o => o.Estate.Name);

            return FormatQueryResults(offers);
        }
    }
}