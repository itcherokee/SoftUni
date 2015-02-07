namespace TravelAgency.Tickets
{
    using System;

    internal class TrainTicket : Ticket
    {
        private const string TicketType = "train";

        private decimal studentPrice;

        public TrainTicket(string from, string to, DateTime dateAndTime, decimal price, decimal studentPrice)
            : base(from, to, dateAndTime, price)
        {
            this.StudentPrice = studentPrice;
        }

        public TrainTicket(string from, string to, DateTime dateAndTime)
            : base(from, to, dateAndTime)
        {
        }

        public decimal StudentPrice
        {
            get
            {
                return this.studentPrice;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "A negative amount for ticket student price has been specified");
                }

                this.studentPrice = value;
            }
        }

        public override string Type
        {
            get
            {
                return TicketType;
            }
        }

        public override string UniqueKey
        {
            get
            {
                return this.Type + ";;" + this.From + ";" + this.To + ";" + this.DateAndTime + ";";
            }
        }
    }
}