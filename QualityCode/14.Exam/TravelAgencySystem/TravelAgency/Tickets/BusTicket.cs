namespace TravelAgency.Tickets
{
    using System;

    internal class BusTicket : Ticket
    {
        private const string TicketType = "bus";

        public BusTicket(string from, string to, string travelComany, DateTime dateAndTime, decimal price = 0)
            : base(from, to, dateAndTime, price)
        {
            this.Company = travelComany;
        }

        public string Company { get; set; }

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
                return this.Type + ";;" + this.From + ";" + this.To + ";" +
                    this.Company + this.DateAndTime + ";";
            }
        }
    }
}