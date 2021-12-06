using DataAccess.DataAccess;
using DataAccess.Interfaces;
using DataAccess.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDataAccess
{
    class ReservationTest
    {
        private IReservationDataAccess _reservationDataAccess;

        [OneTimeSetUp]
        public void SetUp()
        {
            _reservationDataAccess = new ReservationDataAccess(Configuration.CONNECTION_STRING_TEST);
        }

        [Test]
        public async Task CreatingAReservationReturnsItsId()
        {
            //Arrange
            Reservation reservation = new() { TimeStamp = DateTime.Now, SeatId = 1, ShowId = 1, UserId = 1 };
            //Act
            int reservationId = await _reservationDataAccess.CreateAsync(reservation);
            //Assert
            Assert.IsTrue(reservationId > 0, $"Reservation wasn't created. Returned id was {reservationId}");
        }
    }
}
