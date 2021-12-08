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
        public async Task GettingOneShowById1ReturnsAShow()
        {
            //Arrange
            //Act
            var seats = await _seatDataAccess.GetByIdAsync(1);

            //Assert
            Assert.NotNull(show, $"No Show found by the id 1");
        }
    }
}
