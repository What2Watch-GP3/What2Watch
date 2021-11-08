using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;
using NUnit.Framework;
using DataAccess.DataAccess;
using System.Globalization;

namespace TestDataAccess.Tests
{
    class TestConfirmBooking
    {
        private BookingDataAccess _bookingDataAccess;
        [SetUp]
        public void Setup()
        {
            //TODO Change to configuration with hildur
            _bookingDataAccess = new BookingDataAccess(@"Data Source=DESKTOP-HU2QTEB\SQLEXPRESS;Initial Catalog=What2Watch;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        [Test]
        public async Task ConfirmBooking()
        {
            // Arrange
            Booking booking = new() { TotalPrice=11.99M, Date=DateTime.Parse("5/1/2021 8:30:52 AM", CultureInfo.InvariantCulture) };

            // Act
            booking.Id = await _bookingDataAccess.CreateAsync(booking);
            Booking newBooking = await _bookingDataAccess.GetByIdAsync(booking.Id);

            // Assert
            Assert.AreEqual(newBooking.Id, booking.Id, $"Booking doesn't correspond to the expected Id: {newBooking.Id}");
        }
    }
}
