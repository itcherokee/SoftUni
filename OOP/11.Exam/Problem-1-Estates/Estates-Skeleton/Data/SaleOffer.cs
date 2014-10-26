namespace Estates.Data
{
    using System;
    using System.Text;
    using Interfaces;

    public class SaleOffer : Offer, ISaleOffer
    {
        private decimal price
            ;

        public SaleOffer()
            : base(OfferType.Sale)
        {
            this.price = 0;
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Price can not be negative.");

                }

                this.price = value;
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendFormat(
                "{0}, Price = {1}",
                base.ToString(),
                this.Price);

            return output.ToString();
        }
    }
}