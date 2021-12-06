using System;
using System.Threading.Tasks;
using DataAccess.Models;
using NUnit.Framework;
using DataAccess.DataAccess;

namespace TestDataAccess
{
    class BookingTest
    {
        private BookingDataAccess _bookingDataAccess;
        private int _leastCreatedBookingId;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _bookingDataAccess = new BookingDataAccess(Configuration.CONNECTION_STRING_TEST);
        }

        [OneTimeTearDown]
        public async Task OneTimeTearDown()
        {
            await _bookingDataAccess.DeleteAsync(_leastCreatedBookingId);
        }

        [Test]
        [Order(1)]
        public async Task TestConfirmBooking()
        {
            //Arrange
            Booking booking = new() { TotalPrice = 11.99M, Date = DateTime.Now };

            //Act
            booking.Id = await _bookingDataAccess.CreateAsync(booking);
            Booking newBooking = await _bookingDataAccess.GetByIdAsync(booking.Id);
            _leastCreatedBookingId = booking.Id;

            //Assert
            Assert.AreEqual(booking.Id, newBooking.Id, $"Booking doesn't correspond to the expected Id: {newBooking.Id}");
        }

        [Test]
        [Order(2)]
        public async Task GetBookingWithId1()
        {
            //Arrange
            //Act
            Booking newBooking = await _bookingDataAccess.GetByIdAsync(_leastCreatedBookingId);

            //Assert
            Assert.AreEqual(_leastCreatedBookingId, newBooking.Id, $"Booking doesn't correspond to the expected Id: {_leastCreatedBookingId}");
        }
    }
}
