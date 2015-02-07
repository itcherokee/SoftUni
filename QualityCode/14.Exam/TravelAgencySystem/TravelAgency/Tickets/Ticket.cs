namespace TravelAgency.Tickets
{
    using System;
    using System.Globalization;
    using System.Text;

    internal abstract class Ticket : IComparable<Ticket>
    {
        private decimal price;
        private string from;
        private string to;

        protected Ticket(string fromTown, string toTown, DateTime dateAndTime, decimal price = 0)
        {
            this.From = fromTown;
            this.To = toTown;
            this.DateAndTime = dateAndTime;
            this.Price = price;
        }

        protected Ticket()
        {
        }

        public abstract string Type { get; }

        public virtual string From
        {
            get
            {
                return this.from;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException(
                        "value", 
                        "No, blank or whitespce name specified for ticket 'From' field (origin of route)");
                }

                this.from = value;
            }
        }

        public virtual string To
        {
            get
            {
                return this.to;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException(
                        "value",
                        "No, blank or whitespce name specified for ticket 'To' field (destination of route)");
                }

                this.to = value;
            }
        }

        public virtual DateTime DateAndTime { get; set; }

        public virtual decimal Price
        {
            get
            {
                return this.price;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "A negative amount for ticket price has been specified");
                }

                this.price = value;
            }
        }

        public abstract string UniqueKey { get; }

        public string RouteKey
        {
            get
            {
                return this.From + "; " + this.To;
            }
        }

        public static DateTime ParseDateTime(string dateTime)
        {
            var result = DateTime.ParseExact(dateTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            return result;
        }

        public override string ToString()
        {
            const int MaxReportSizeInSymbols = 32;
            var output = new StringBuilder(MaxReportSizeInSymbols);
            output.AppendFormat(
                "[{0}; {1}; {2}]",
                this.DateAndTime.ToString("dd.MM.yyyy HH:mm"),
                this.Type,
                string.Format("{0:f2}", this.Price));

            return output.ToString();
        }

        public int CompareTo(Ticket otherTicket)
        {
            int result = DateTime.Compare(this.DateAndTime, otherTicket.DateAndTime);

            if (result == 0)
            {
                result = string.Compare(this.Type, otherTicket.Type, StringComparison.OrdinalIgnoreCase);
            }

            if (result == 0)
            {
                result = decimal.Compare(this.Price, otherTicket.Price);
            }

            return result;
        }
    }
}