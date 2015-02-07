namespace TravelAgency.Contracts
{
    using System;
    using Enums;

    /// <summary>
    /// Interface define operations on creatiuon, deletion of tickets of different transportation, 
    /// search of issued tickets in specified time frame as well as tickets for certain
    /// orgin and destination of the route, as well as counting capabilities for different types of 
    /// already issued tickets.
    /// </summary>
    public interface ITicketCatalog
    {
        /// <summary>
        /// Creates an Air ticket and add it to the list of tickets.
        /// </summary>
        /// <param name="flightNumber">Flight number of that ticket.</param>
        /// <param name="from">Point of departure.</param>
        /// <param name="to">Destination of flight.</param>
        /// <param name="airline">Airline that operates that route and issued the ticket.</param>
        /// <param name="dateTime">Date and time of departure.</param>
        /// <param name="price">Total price of the ticket.</param>
        /// <returns>Returns "Ticket added" if ticket has been succesfully issued or "Duplicated ticket" if ticket already exists.</returns>
        string AddAirTicket(string flightNumber, string from, string to, string airline, DateTime dateTime, decimal price);

        string DeleteAirTicket(string flightNumber);

        string AddTrainTicket(string from, string to, DateTime dateTime, decimal price, decimal studentPrice);

        string DeleteTrainTicket(string from, string to, DateTime dateTime);

        string AddBusTicket(string from, string to, string travelCompany, DateTime dateTime, decimal price);

        /// <summary>
        /// Deletes a bus ticket form the list of tickets.
        /// </summary>
        /// <param name="from">Point of departure.</param>
        /// <param name="to">Destination of the route.</param>
        /// <param name="travelCompany">Travel comany that operates the route and issued the ticket.</param>
        /// <param name="dateTime">Date and time of the departure.</param>
        /// <returns>Returns "Ticket deleted" in case the ticket already exists and has been found,
        /// else if ticket has not been found, returns "Ticket does not exists</returns>
        string DeleteBusTicket(string from, string to, string travelCompany, DateTime dateTime);

        /// <summary>
        /// Finds all tickets that has been already issued and exists in the list with coresponding 
        /// <paramref name="from"/>- point of departure and <paramref name="to"/> - destination.
        /// </summary>
        /// <param name="from">Point of departure.</param>
        /// <param name="to">Destination of the route.</param>
        /// <returns>All found tickets with setup <paramref name="to"/> and <paramref name="from"/> parameters. 
        /// In case there is no any tickets that corespond to these parameters - returns "Not found"</returns>
        string FindTickets(string from, string to);

        /// <summary>
        /// Finds all tickets which exists in the list and are 
        /// issued between <paramref name="startDateTime"/> and <paramref name="endDateTime"/> time frame.</summary>
        /// <param name="startDateTime">Start date of time the frame.</param>
        /// <param name="endDateTime">End date and time of the time frame.</param>
        /// <returns>All found tickets in specified time frame. If no ticket is found in that time frame,
        /// returns "Not found"</returns>
        string FindTicketsInInterval(DateTime startDateTime, DateTime endDateTime);

        int GetTicketsCount(TicketType type);
    }
}