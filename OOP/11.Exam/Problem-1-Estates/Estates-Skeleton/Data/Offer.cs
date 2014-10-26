namespace Estates.Data
{
    using System;
    using System.Text;
    using Interfaces;

    public abstract class Offer : IOffer
    {
        private OfferType type;

        protected Offer(OfferType type)
        {
            this.Estate = null;
            this.Type = type;
        }

        public OfferType Type
        {
            get
            {
                return this.type;
            }

            set
            {
                if (!Enum.IsDefined(typeof(OfferType), value))
                {
                    throw new ArgumentException("Invalid offer type provided.");
                }

                this.type = value;
            }
        }

        public IEstate Estate { get; set; }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendFormat(
                "{0}: Estate = {1}, Location = {2}",
                this.Type,
                this.Estate.Name,
                this.Estate.Location);

            return output.ToString();
        }
    }
}