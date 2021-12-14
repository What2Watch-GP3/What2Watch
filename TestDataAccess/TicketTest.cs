using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DataAccess;
using DataAccess.Interfaces;
using NUnit.Framework;

namespace TestDataAccess
{
    class TicketTest
    {
        private ITicketDataAccess _ticketDataAccess;

        [OneTimeSetUp]

        public void SetUp()
        {
            _ticketDataAccess = new TicketDataAccess(Configuration.CONNECTION_STRING_TEST);
        }

        [Test]
        public async Task GetTicketsBasedOnShowId()
        {
            //Arrange
            //Act
            var tickets = await _ticketDataAccess.GetTicketsByShowIdAsync(1);

            //Assert
            Assert.IsNotEmpty(tickets, $"The list of seats based on show id 1 was empty.");
            Assert.AreEqual(3, tickets.Count(), $"The amount of tickets recieved its not expected (3 were expected).{tickets.Count()}");
        }
    }
}
