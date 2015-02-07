namespace TravelAgency
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Enums;
    using Tickets;

    public class TravelAgency
    {
        private const string AddAirTicketCommand = "AddAir";
        private const string DeleteAirTicketCommand = "DeleteAir";
        private const string AddTrainTicketCommand = "AddTrain";
        private const string DeleteTrainTicketCommand = "DeleteTrain";
        private const string AddBusTicketCommand = "AddBus";
        private const string DeleteBusTicketCommand = "DeleteBus";
        private const string FindTicketsCommand = "FindTickets";
        private const string FindTicketsInIntervalCommand = "FindTicketsInInterval";

        private static readonly ITicketCatalog ticketCatalog = new TicketCatalog();

        public static void Main()
        {
            while (true)
            {
                string commandLine = Console.ReadLine();
                if (commandLine == null)
                {
                    break;
                }

                commandLine = commandLine.Trim();
                string commandResult = ProcessInput(commandLine);

                if (commandResult != null)
                {
                    Console.WriteLine(commandResult);
                }
            }
        }

        private static string ProcessInput(string line)
        {
            if (line == string.Empty)
            {
                return null;
            }

            int firstSpaceIndex = line.IndexOf(' ');

            if (firstSpaceIndex == -1)
            {
                throw new InvalidOperationException("Invalid command: Missing sperators between command and parameters");
            }

            string command = line.Substring(0, firstSpaceIndex);
            string commandParams = line.Substring(firstSpaceIndex + 1);
            string commandResult;
            switch (command)
            {
                case AddAirTicketCommand:
                    commandResult = ExecuteCommand(Commands.AddAir, commandParams);
                    break;
                case DeleteAirTicketCommand:
                    commandResult = ExecuteCommand(Commands.DeleteAir, commandParams);
                    break;
                case AddTrainTicketCommand:
                    commandResult = ExecuteCommand(Commands.AddTrain, commandParams);
                    break;
                case DeleteTrainTicketCommand:
                    commandResult = ExecuteCommand(Commands.DeleteTrain, commandParams);
                    break;
                case AddBusTicketCommand:
                    commandResult = ExecuteCommand(Commands.AddBus, commandParams);
                    break;
                case DeleteBusTicketCommand:
                    commandResult = ExecuteCommand(Commands.DeleteBus, commandParams);
                    break;
                case FindTicketsCommand:
                    commandResult = ExecuteCommand(Commands.FindTickets, commandParams);
                    break;
                case FindTicketsInIntervalCommand:
                    commandResult = ExecuteCommand(Commands.FindTicketsInInterval, commandParams);
                    break;
                default:
                    throw new InvalidOperationException("Invalid command: non exiiting command");
            }

            return commandResult;
        }

        private static string ExecuteCommand(Commands command, string commandParameters)
        {
            var parameters = commandParameters
                .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(p => p.Trim())
                .ToList();
            string commandResult;
            switch (command)
            {
                case Commands.AddAir:
                    commandResult = ExecuteAddAirCommand(parameters);
                    break;
                case Commands.DeleteAir:
                    commandResult = ExecuteDeleteAirCommand(parameters);
                    break;
                case Commands.AddTrain:
                    commandResult = ExecuteAddTrainCommand(parameters);
                    break;
                case Commands.DeleteTrain:
                    commandResult = ExecuteDeleteTrainCommand(parameters);
                    break;
                case Commands.AddBus:
                    commandResult = ExecuteAddBusCommand(parameters);
                    break;
                case Commands.DeleteBus:
                    commandResult = ExecuteDeleteBusCommand(parameters);
                    break;
                case Commands.FindTickets:
                    commandResult = ExecuteFindTicketsCommand(parameters);
                    break;
                case Commands.FindTicketsInInterval:
                    commandResult = ExecuteFindTicketsInIntervalCommand(parameters);
                    break;
                default:
                    throw new InvalidOperationException("Invalid command provided for execution");
            }

            return commandResult;
        }
        
        private static string ExecuteAddAirCommand(IList<string> parameters)
        {
            var flightNumber = parameters[0];
            var fromAirport = parameters[1];
            var toAirport = parameters[2];
            var airline = parameters[3];
            var dateAndTimeOfDeparture = Ticket.ParseDateTime(parameters[4]);
            var price = decimal.Parse(parameters[5]);

            return ticketCatalog.AddAirTicket(flightNumber, fromAirport, toAirport, airline, dateAndTimeOfDeparture, price);
        }

        private static string ExecuteDeleteAirCommand(IList<string> parameters)
        {
            var flightNumber = parameters[0];

            return ticketCatalog.DeleteAirTicket(flightNumber);
        }

        private static string ExecuteAddTrainCommand(IList<string> parameters)
        {
            var fromTown = parameters[0];
            var toTown = parameters[1];
            var dateAndTimeOfDeparture = Ticket.ParseDateTime(parameters[2]);
            var price = decimal.Parse(parameters[3]);
            var studentPrice = decimal.Parse(parameters[4]);

            return ticketCatalog.AddTrainTicket(fromTown, toTown, dateAndTimeOfDeparture, price, studentPrice);
        }

        private static string ExecuteDeleteTrainCommand(IList<string> parameters)
        {
            var fromTown = parameters[0];
            var toTown = parameters[1];
            var dateAndTimeOfDeparture = Ticket.ParseDateTime(parameters[2]);

            return ticketCatalog.DeleteTrainTicket(fromTown, toTown, dateAndTimeOfDeparture);
        }

        private static string ExecuteAddBusCommand(IList<string> parameters)
        {
            var fromTown = parameters[0];
            var toTown = parameters[1];
            var travelCompany = parameters[2];
            var dateAndTimeOfDeparture = Ticket.ParseDateTime(parameters[3]);
            var price = decimal.Parse(parameters[4]);

            return ticketCatalog.AddBusTicket(fromTown, toTown, travelCompany, dateAndTimeOfDeparture, price);
        }

        private static string ExecuteDeleteBusCommand(IList<string> parameters)
        {
            var fromTown = parameters[0];
            var toTown = parameters[1];
            var travelCompany = parameters[2];
            var dateAndTimeOfDeparture = Ticket.ParseDateTime(parameters[3]);

            return ticketCatalog.DeleteBusTicket(fromTown, toTown, travelCompany, dateAndTimeOfDeparture);
        }

        private static string ExecuteFindTicketsCommand(IList<string> parameters)
        {
            var fromOrigin = parameters[0];
            var toDestination = parameters[1];

            return ticketCatalog.FindTickets(fromOrigin, toDestination);
        }

        private static string ExecuteFindTicketsInIntervalCommand(IList<string> parameters)
        {
            var startDateAndTime = Ticket.ParseDateTime(parameters[0]);
            var endDateAndTime = Ticket.ParseDateTime(parameters[1]);

            return ticketCatalog.FindTicketsInInterval(startDateAndTime, endDateAndTime);
        }
    }
}
