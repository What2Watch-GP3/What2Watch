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
            IEnumerable<Reservation> reservations = new List<Reservation>()
            {
                new Reservation() { TimeStamp = DateTime.Now, SeatId = 1, ShowId = 1, UserId = 1 },
                new Reservation() { TimeStamp = DateTime.Now, SeatId = 2, ShowId = 1, UserId = 1 },
                new Reservation() { TimeStamp = DateTime.Now, SeatId = 3, ShowId = 1, UserId = 1 }
            };
            //Act
            IEnumerable<int> reservationIds = await _reservationDataAccess.CreateAsync(reservations);
            //Assert
            Assert.AreEqual(reservationIds.Count(), 3, $"Reservations weren't created. Returned ids were {reservationIds}");
        }
    }
}
