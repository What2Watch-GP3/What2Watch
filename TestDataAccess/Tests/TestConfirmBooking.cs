using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;
using NUnit.Framework;
using DataAccess.BookingDataAccess;

namespace TestDataAccess.Tests
{
    class TestConfirmBooking
    {
        private BookingDataAccess _bookingDataAccess;
        [SetUp]
        public void Setup()
        {
            _bookingDataAccess = new BookingDataAccess();


        }

        [Test]
        public async Task ConfirmBooking()
        {
            decimal totalPrice = 11.99M;
            var dateString = "5/1/2021 8:30:52 AM";
            DateTime date = DateTime.Parse(dateString, System.Globalization.CultureInfo.InvariantCulture);
            Booking booking1 = new Booking(totalPrice, date);


            // Act
            int actual = await _bookingDataAccess.CreateAsync(booking1);
            Booking newBooking = await _bookingDataAccess.GetAsync(actual);


            // Assert
            Assert.AreEqual(newBooking.Id, actual, $"Booking doesn't correspond to the expected Id: {newBooking.Id}");
        }
    }
}
