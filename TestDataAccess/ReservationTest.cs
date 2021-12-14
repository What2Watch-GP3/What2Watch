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
        private IEnumerable<Reservation> reservations = null;

        [OneTimeSetUp]
        public void SetUp()
        {
            _reservationDataAccess = new ReservationDataAccess(Configuration.CONNECTION_STRING_TEST);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _reservationDataAccess.DeleteByShowAndSeatIdAsync(2, 1);
            _reservationDataAccess.DeleteByShowAndSeatIdAsync(3, 1);
            _reservationDataAccess.DeleteByShowAndSeatIdAsync(1, 1);
        }


        //[Test]
        //[Order(1)]
        public async Task CreatingAReservationReturnsItsId()
        {
            //Arrange
            IEnumerable<Reservation> reservations = new List<Reservation>()
            {
                new Reservation() { CreationTime= DateTime.Now, SeatId = 1, ShowId = 1, UserId = 1 },
                new Reservation() { CreationTime = DateTime.Now, SeatId = 2, ShowId = 1, UserId = 1 },
                new Reservation() { CreationTime = DateTime.Now, SeatId = 3, ShowId = 1, UserId = 1 }
            };
            //Act
            bool isCreated = await _reservationDataAccess.CreateAsync(reservations);
            //Assert
            Assert.IsTrue(isCreated, $"Reservations weren't created.");
        }
        
        [Test]
        [Order(2)]
        public async Task GetReservationsByShowId1()
        {
            //act
            reservations = await _reservationDataAccess.GetReservationsByShowIdAsync(1);

            //ASSERT
            Assert.IsNotEmpty(reservations, $"No reservations returned. Show id was 1");
        }
    }
}
