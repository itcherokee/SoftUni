
namespace TravelAgency.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Enums;


    [TestClass]
    public class TravelAgencyUnitTests
    {
        [TestMethod]
        public void ShouldAddAnAirTicket()
        {
            var catalog = new TicketCatalog();
            var flightNumber = "LZ001";
            var origin = "Sofia";
            var destination = "Marocco";
            string airline = "Balkan";
            var departureDate = new DateTime(2012, 01, 20, 10, 10, 10);
            decimal price = 100m;
            var airTicket = catalog.AddAirTicket(flightNumber, origin, destination, airline, departureDate, price);
            Assert.AreEqual(1, catalog.GetTicketsCount(TicketType.Air));
            string expectedReport = "[20.01.2012 10:10; air; 100.00]";
            Assert.AreEqual(expectedReport, catalog.FindTickets(origin, destination));
        }

        [TestMethod]
        public void ShouldAddAnBusTicket()
        {
            var catalog = new TicketCatalog();
            var origin = "Sofia";
            var destination = "Berlin";
            string travelCompany = "BioMed";
            var departureDate = new DateTime(2015, 01, 20, 10, 10, 10);
            decimal price = 100m;
            var busTicket = catalog.AddBusTicket(origin, destination, travelCompany, departureDate, price);
            Assert.AreEqual(1, catalog.GetTicketsCount(TicketType.Bus));
            string expectedReport = "[20.01.2015 10:10; bus; 100.00]";
            Assert.AreEqual(expectedReport, catalog.FindTickets(origin, destination));
        }

        [TestMethod]
        public void ShouldAddAnTrainTicket()
        {
            var catalog = new TicketCatalog();
            var origin = "Sofia";
            var destination = "Berlin";
            string travelCompany = "BioMed";
            var departureDate = new DateTime(2015, 01, 20, 10, 10, 10);
            decimal price = 100m;
            decimal studentPrice = 80m;
            var busTicket = catalog.AddTrainTicket(origin, destination, departureDate, price, studentPrice);
            Assert.AreEqual(1, catalog.GetTicketsCount(TicketType.Train));
            string expectedReport = "[20.01.2015 10:10; train; 100.00]";
            Assert.AreEqual(expectedReport, catalog.FindTickets(origin, destination));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TryAddAnTrainTicketWithNegativePriceShouldThrowException()
        {
            var catalog = new TicketCatalog();
            var origin = "Sofia";
            var destination = "Berlin";
            string travelCompany = "BioMed";
            var departureDate = new DateTime(2015, 01, 20, 10, 10, 10);
            decimal price = -100m;
            decimal studentPrice = 80m;
            var busTicket = catalog.AddTrainTicket(origin, destination, departureDate, price, studentPrice);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TryAddAnTrainTicketWithNegativeStudentPriceShouldThrowException()
        {
            var catalog = new TicketCatalog();
            var origin = "Sofia";
            var destination = "Berlin";
            string travelCompany = "BioMed";
            var departureDate = new DateTime(2015, 01, 20, 10, 10, 10);
            decimal price = 100m;
            decimal studentPrice = -80m;
            var busTicket = catalog.AddTrainTicket(origin, destination, departureDate, price, studentPrice);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TryAddAnTrainTicketWithBlankOriginShouldThrowException()
        {
            var catalog = new TicketCatalog();
            var origin = "";
            var destination = "Berlin";
            string travelCompany = "BDZ";
            var departureDate = new DateTime(2015, 01, 20, 10, 10, 10);
            decimal price = 100m;
            decimal studentPrice = 80m;
            var busTicket = catalog.AddTrainTicket(origin, destination, departureDate, price, studentPrice);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TryAddAnTrainTicketWithBlankDestinationShouldThrowException()
        {
            var catalog = new TicketCatalog();
            var origin = "Sofia";
            var destination = "";
            string travelCompany = "BDZ";
            var departureDate = new DateTime(2015, 01, 20, 10, 10, 10);
            decimal price = 100m;
            decimal studentPrice = 80m;
            var busTicket = catalog.AddTrainTicket(origin, destination, departureDate, price, studentPrice);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TryAddAnAirTicketWithBlankAirlineShouldThrowException()
        {
            var catalog = new TicketCatalog();
            string flightNumber = null;
            var origin = "Sofia";
            var destination = "Marocco";
            string airline = "Balkan";
            var departureDate = new DateTime(2012, 01, 20, 10, 10, 10);
            decimal price = 100m;
            var airTicket = catalog.AddAirTicket(flightNumber, origin, destination, airline, departureDate, price);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TryAddAnAirTicketWithBlankflightNumberShouldThrowException()
        {
            var catalog = new TicketCatalog();
            string flightNumber = "LZ0112";
            var origin = "Sofia";
            var destination = "Marocco";
            string airline = "";
            var departureDate = new DateTime(2012, 01, 20, 10, 10, 10);
            decimal price = 100m;
            var airTicket = catalog.AddAirTicket(flightNumber, origin, destination, airline, departureDate, price);
        }

        [TestMethod]
        public void DeleteAnAirTicketShouldDeleteExisting()
        {
            var catalog = new TicketCatalog();
            var flightNumber = "LZ001";
            var origin = "Sofia";
            var destination = "Marocco";
            string airline = "Balkan";
            var departureDate = new DateTime(2012, 01, 20, 10, 10, 10);
            decimal price = 100m;
            var airTicket = catalog.AddAirTicket(flightNumber, origin, destination, airline, departureDate, price);
            Assert.AreEqual(1, catalog.GetTicketsCount(TicketType.Air));
            var actualMessage = catalog.DeleteAirTicket(flightNumber);
            string expectedMessage = "Ticket deleted";
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod]
        public void DeleteAnAirTicketThatDoNotExistShouldReturnMessage()
        {
            var catalog = new TicketCatalog();
            var flightNumber = "LZ001";
            var origin = "Sofia";
            var destination = "Marocco";
            string airline = "Balkan";
            var departureDate = new DateTime(2012, 01, 20, 10, 10, 10);
            decimal price = 100m;
            var airTicket = catalog.AddAirTicket(flightNumber, origin, destination, airline, departureDate, price);
            Assert.AreEqual(1, catalog.GetTicketsCount(TicketType.Air));
            var actualMessage = catalog.DeleteAirTicket("MH1001");
            string expectedMessage = "Ticket does not exist";
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod]
        public void TryToDuplicateAnAirTicketShouldReturnMessage()
        {
            var catalog = new TicketCatalog();
            var flightNumber = "LZ001";
            var origin = "Sofia";
            var destination = "Marocco";
            string airline = "Balkan";
            var departureDate = new DateTime(2012, 01, 20, 10, 10, 10);
            decimal price = 100m;
            var actualMessage = catalog.AddAirTicket(flightNumber, origin, destination, airline, departureDate, price);
            Assert.AreEqual("Ticket added", actualMessage);
            actualMessage = catalog.AddAirTicket(flightNumber, origin, destination, airline, departureDate, price);
            Assert.AreEqual("Duplicate ticket", actualMessage);
        }

        [TestMethod]
        public void TryToDuplicateAnBusTicketShouldReturnMessage()
        {
            var catalog = new TicketCatalog();
            var origin = "Sofia";
            var destination = "Berlin";
            string travelCompany = "BioMed";
            var departureDate = new DateTime(2015, 01, 20, 10, 10, 10);
            decimal price = 100m;
            var actualMessage = catalog.AddBusTicket(origin, destination, travelCompany, departureDate, price);
            Assert.AreEqual("Ticket added", actualMessage);
            actualMessage = catalog.AddBusTicket(origin, destination, travelCompany, departureDate, price);
            Assert.AreEqual("Duplicate ticket", actualMessage);
        }

        [TestMethod]
        public void DeleteExistingBusTicketShouldReturnMessage()
        {
            var catalog = new TicketCatalog();
            var origin = "Sofia";
            var destination = "Berlin";
            string travelCompany = "BioMed";
            var departureDate = new DateTime(2015, 01, 20, 10, 10, 10);
            decimal price = 100m;
            var actualMessage = catalog.AddBusTicket(origin, destination, travelCompany, departureDate, price);
            Assert.AreEqual("Ticket added", actualMessage);
            actualMessage = catalog.DeleteBusTicket(origin, destination, travelCompany, departureDate);
            Assert.AreEqual("Ticket deleted", actualMessage);

        }

        [TestMethod]
        public void DeleteAnBusTicketThatDoNotExistShouldReturnMessage()
        {
            var catalog = new TicketCatalog();
            var origin = "Sofia";
            var destination = "Berlin";
            string travelCompany = "BioMed";
            var departureDate = new DateTime(2015, 01, 20, 10, 10, 10);
            decimal price = 100m;
            var actualMessage = catalog.AddBusTicket(origin, destination, travelCompany, departureDate, price);
            actualMessage = catalog.DeleteBusTicket(origin, destination, "MontanaBus", departureDate);
            string expectedMessage = "Ticket does not exist";
            Assert.AreEqual(expectedMessage, actualMessage);
        }


        [TestMethod]
        public void DeleteAnTrainTicketThatDoNotExistShouldReturnMessage()
        {
            var catalog = new TicketCatalog();
            var origin = "Sofia";
            var destination = "Berlin";
            string travelCompany = "BioMed";
            var departureDate = new DateTime(2015, 01, 20, 10, 10, 10);
            decimal price = 100m;
            decimal studentPrice = 80m;
            var actualMessage = catalog.AddTrainTicket(origin, destination, departureDate, price, studentPrice);
            actualMessage = catalog.DeleteTrainTicket("Budapest", destination, departureDate);
            string expectedMessage = "Ticket does not exist";
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod]
        public void DeleteAnTrainTicketThatExistShouldReturnMessage()
        {
            var catalog = new TicketCatalog();
            var origin = "Sofia";
            var destination = "Berlin";
            string travelCompany = "BioMed";
            var departureDate = new DateTime(2015, 01, 20, 10, 10, 10);
            decimal price = 100m;
            decimal studentPrice = 80m;
            var actualMessage = catalog.AddTrainTicket(origin, destination, departureDate, price, studentPrice);
            actualMessage = catalog.DeleteTrainTicket(origin, destination, departureDate);
            string expectedMessage = "Ticket deleted";
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod]
        public void FindAllNonExistingTicketsShouldReturnMessage()
        {
            var catalog = new TicketCatalog();
            var origin = "Sofia";
            var destination = "Berlin";
            string travelCompany = "BioMed";
            var departureDate = new DateTime(2015, 01, 20, 10, 10, 10);
            decimal price = 100m;
            decimal studentPrice = 80m;
            var actualMessage = catalog.AddTrainTicket(origin, destination, departureDate, price, studentPrice);
            actualMessage = catalog.FindTickets("Barcelona", "Sofia");
            string expectedMessage = "Not found";
            Assert.AreEqual(expectedMessage, actualMessage);
        }


        [TestMethod]
        public void FindAllTicketsInIntervalShouldReturnMessage()
        {
            var catalog = new TicketCatalog();
            var destination = "Berlin";
            string travelCompany = "BioMed";
            var departureDateOne = new DateTime(2015, 01, 20, 10, 10, 10);
            var departureDateTwo = new DateTime(2015, 01, 20, 10, 20, 10);
            decimal price = 100m;
            decimal studentPrice = 80m;
            catalog.AddTrainTicket("Sofia", destination, departureDateOne, price, studentPrice);
            catalog.AddTrainTicket("Barcelona", destination, departureDateTwo, price, studentPrice);
            var actualMessage = catalog.FindTicketsInInterval(new DateTime(2015, 01, 01), new DateTime(2016, 01, 01));
            var expectedMessage = "[20.01.2015 10:10; train; 100.00] [20.01.2015 10:20; train; 100.00]";
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod]
        public void FindAllNonExisitngTicketsInIntervalShouldReturnMessage()
        {
            var catalog = new TicketCatalog();
            var destination = "Berlin";
            string travelCompany = "BioMed";
            var departureDateOne = new DateTime(2015, 01, 20, 10, 10, 10);
            var departureDateTwo = new DateTime(2015, 01, 20, 10, 20, 10);
            decimal price = 100m;
            decimal studentPrice = 80m;
            catalog.AddTrainTicket("Sofia", destination, departureDateOne, price, studentPrice);
            catalog.AddTrainTicket("Barcelona", destination, departureDateTwo, price, studentPrice);
            var actualMessage = catalog.FindTicketsInInterval(new DateTime(2011, 01, 01), new DateTime(2012, 01, 01));
            var expectedMessage = "Not found";
            Assert.AreEqual(expectedMessage, actualMessage);
        }
    }
}
