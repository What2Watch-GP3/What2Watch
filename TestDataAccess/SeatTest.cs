using DataAccess.DataAccess;
using DataAccess.Interfaces;
using DataAccess.Models;
using NUnit.Framework;
using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace TestDataAccess
{
    class SeatTest
    {
        private ISeatDataAccess _seatDataAccess;

        [OneTimeSetUp]

        public void SetUp()
        {
            _seatDataAccess = new SeatDataAccess(Configuration.CONNECTION_STRING_TEST);
        }

        [Test]
        public async Task GettingSeatsByRoomIdReturnsAListOfSeatsBiggerThan0()
        {
            //Arrange
            //Act
            var seats = await _seatDataAccess.GetByIdAsync(1);

            //Assert
            Assert.IsNotEmpty(seats, $"The list of seats based on the room id 1 was empty.");
        }
    }
}
