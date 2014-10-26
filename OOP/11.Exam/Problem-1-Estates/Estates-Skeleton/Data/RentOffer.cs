namespace Estates.Data
{
    using System;
    using System.Text;
    using Interfaces;
    
    public class RentOffer : Offer, IRentOffer
    {
        private decimal pricePerMonth;

        public RentOffer()
            : base(OfferType.Rent)
        {
            this.PricePerMonth = 0;
        }

        public decimal PricePerMonth
        {
            get
            {
                return this.pricePerMonth;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Price per month can not be negative.");

                }

                this.pricePerMonth = value;
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendFormat(
                "{0}, Price = {1}",
                base.ToString(),
                this.PricePerMonth);

            return output.ToString();
        }
    }
}