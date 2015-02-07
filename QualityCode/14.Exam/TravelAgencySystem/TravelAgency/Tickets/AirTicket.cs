namespace TravelAgency.Tickets
{
    using System;

    internal class AirTicket : Ticket
    {
        private const string TicketType = "air";

        private string flightNumber;
        private string airline;

        public AirTicket(string flightNumber, string from, string to, string airline, DateTime dateAndTime, decimal price)
            : base(from, to, dateAndTime, price)
        {
            this.FlightNumber = flightNumber;
            this.Airline = airline;
        }

        public AirTicket(string flightNumber)
        {
            this.FlightNumber = flightNumber;
        }

        public string FlightNumber
        {
            get
            {
                return this.flightNumber;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException(
                        "value",
                        "No, blank or whitespce name specified for ticket 'FlightNumber' field (destination of route)");
                }

                this.flightNumber = value;
            }
        }

        public string Airline
        {
            get
            {
                return this.airline;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException(
                        "value",
                        "No, blank or whitespce name specified for ticket 'Airline' field (destination of route)");
                }

                this.airline = value;
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
                return this.Type + ";;" + this.FlightNumber;
            }
        }
    }
}
