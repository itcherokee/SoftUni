namespace Company
{
    using System;

    public class Sale : OperationalItem, ISale
    {
        private DateTime date;
        private decimal price;

        public Sale(string name, DateTime date, decimal price)
            : base(name)
        {
            this.Price = price;
            this.Date = date;
        }

        public DateTime Date
        {
            get
            {
                return this.date;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value", "Date of sale cannot be null.");
                }

                if (value > DateTime.Now)
                {
                    throw new ArgumentOutOfRangeException("value", "Date of sale cannot be in the future.");
                }

                this.date = value;
            }
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
                    throw new ArgumentException("Price of sale cannot be negative.");
                }

                this.price = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} sold on {1:d} for {2:C2}", this.Name, this.Date, this.Price);
        }
    }
}
