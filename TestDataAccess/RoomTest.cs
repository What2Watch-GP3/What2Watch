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
    class RoomTest
    {
        private IRoomDataAccess _roomDataAccess;

        [OneTimeSetUp]
        public void SetUp()
        {
            _roomDataAccess = new RoomDataAccess(Configuration.CONNECTION_STRING_TEST);
        }

        [Test]
        public async Task GettingOneRoomById1ReturnsSeats()
        {
            //Arrange
            //Act
            var room = await _roomDataAccess.GetByIdAsync(1);

            //Assert
            Assert.IsNotNull(room, $"Room with id 1 was not found.");
        }
    }
}
