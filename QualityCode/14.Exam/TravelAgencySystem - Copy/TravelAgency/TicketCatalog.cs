namespace TravelAgency
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Enums;
    using Tickets;
    using Wintellect.PowerCollections;

    public class TicketCatalog : ITicketCatalog
    {
        private readonly Dictionary<string, Ticket> allTickets;
        private readonly MultiDictionary<string, Ticket> allTicketsByRoute;
        private readonly OrderedMultiDictionary<DateTime, Ticket> allTicketsByDepartureDateTime;

        public TicketCatalog()
        {
            this.allTickets = new Dictionary<string, Ticket>();
            this.allTicketsByRoute = new MultiDictionary<string, Ticket>(true);
            this.allTicketsByDepartureDateTime = new OrderedMultiDictionary<DateTime, Ticket>(true);
            this.AirTicketsCount = 0;
            this.BusTicketsCount = 0;
            this.TrainTicketsCount = 0;
        }

        public int AirTicketsCount { get;  protected set; }

        public int BusTicketsCount { get; protected set; }

        public int TrainTicketsCount { get; protected set; }

        public int GetTicketsCount(TicketType ticketType)
        {
            int countOfTickets;
            switch (ticketType)
            {
                case TicketType.Air:
                    countOfTickets = this.AirTicketsCount;
                    break;
                case TicketType.Bus:
                    countOfTickets = this.BusTicketsCount;
                    break;
                case TicketType.Train:
                    countOfTickets = this.TrainTicketsCount;
                    break;
                default:
                    throw new ArgumentException("Non existing ticket type has been used", "ticketType");
            }

            return countOfTickets;
        }

        public string AddAirTicket(string flightNumber, string from, string to, string airline, DateTime dateTime, decimal price)
        {
            var ticket = new AirTicket(flightNumber, from, to, airline, dateTime, price);
            string operationResult = this.AddTicket(ticket);

            if (operationResult.Contains("added"))
            {
                this.AirTicketsCount++;
            }

            return operationResult;
        }

        public string DeleteAirTicket(string flightNumber)
        {
            var ticket = new AirTicket(flightNumber);
            string operationResult = this.DeleteTicket(ticket);
            if (operationResult.Contains("deleted"))
            {
                this.AirTicketsCount--;
            }

            return operationResult;
        }

        public string AddTrainTicket(string from, string to, DateTime dateTime, decimal price, decimal studentPrice)
        {
            var ticket = new TrainTicket(from, to, dateTime, price, studentPrice);
            string operationResult = this.AddTicket(ticket);
            if (operationResult.Contains("added"))
            {
                this.TrainTicketsCount++;
            }

            return operationResult;
        }

        public string DeleteTrainTicket(string from, string to, DateTime dateTime)
        {
            var ticket = new TrainTicket(from, to, dateTime);
            string result = this.DeleteTicket(ticket);
            if (result.Contains("deleted"))
            {
                this.TrainTicketsCount--;
            }

            return result;
        }

        public string AddBusTicket(string from, string to, string travelCompany, DateTime dateTime, decimal price)
        {
            var ticket = new BusTicket(from, to, travelCompany, dateTime, price);
            string operationResult = this.AddTicket(ticket);

            if (operationResult.Contains("added"))
            {
                this.BusTicketsCount++;
            }

            return operationResult;
        }

        public string DeleteBusTicket(string from, string to, string travelCompany, DateTime dateTime)
        {
            var ticket = new BusTicket(from, to, travelCompany, dateTime);
            string result = this.DeleteTicket(ticket);
            if (result.Contains("deleted"))
            {
                this.BusTicketsCount--;
            }

            return result;
        }
        
        public string FindTickets(string from, string to)
        {
            string route = from + "; " + to;
            if (this.allTicketsByRoute.ContainsKey(route))
            {
                var matchedTickets = this.allTicketsByRoute.Values.Where(ticket => ticket.RouteKey == route).ToList();
                matchedTickets.Sort();
                string requestedTickets = string.Join(" ", matchedTickets);

                return requestedTickets;
            }

            return "Not found";
        }

        public string FindTicketsInInterval(DateTime startDateTime, DateTime endDateTime)
        {
            var matchedTickets = this.allTicketsByDepartureDateTime.Range(startDateTime, true, endDateTime, true).Values.ToList();
            if (matchedTickets.Count > 0)
            {
                string requestedTickets = string.Join(" ", matchedTickets);

                return requestedTickets;
            }
            else
            {
                return "Not found";
            }
        }

        internal string AddTicket(Ticket ticket)
        {
            string key = ticket.UniqueKey;
            if (this.allTickets.ContainsKey(key))
            {
                return "Duplicate ticket";
            }
            else
            {
                this.allTickets.Add(key, ticket);
                string fromToKey = ticket.RouteKey;
                this.allTicketsByRoute.Add(fromToKey, ticket);
                this.allTicketsByDepartureDateTime.Add(ticket.DateAndTime, ticket);

                return "Ticket added";
            }
        }

        internal string DeleteTicket(Ticket ticket)
        {
            string key = ticket.UniqueKey;
            if (this.allTickets.ContainsKey(key))
            {
                this.allTickets.Remove(key);
                string routeKey = ticket.RouteKey;
                this.allTicketsByRoute.Remove(routeKey, ticket);
                this.allTicketsByDepartureDateTime.Remove(ticket.DateAndTime, ticket);

                return "Ticket deleted";
            }
            else
            {
                return "Ticket does not exist";
            }
        }
    }
}