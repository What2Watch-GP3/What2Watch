using DataAccess.Model;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using StubsClassLibrary;
using System.Threading.Tasks;
using WebApi.Controllers;
using WebApi.DTOs;

namespace TestBookingWebApi
{
    class BookingTest
    {
        private BookingsController _testBookingWebApi;

        [OneTimeSetUp]
        public async Task OneTimeSetUp()
        {
            _testBookingWebApi = new BookingsController(new BookingStubs());
        }

        [Test]
        public async Task GetBookingById3Async()
        {
            // Arrange - In OneTimeSetUp
            // Act
            var actionResult = (await _testBookingWebApi.GetByIdAsync(3)).Result;
            if (actionResult is ObjectResult objRes)
            {
                // Assert
                Assert.AreEqual(200, objRes.StatusCode, "Status code returned was not 200");

                Booking booking = (Booking)objRes.Value;
                Assert.AreEqual(booking.Id, 3, "Booking id 3 was not recieved");
            }
            else if (actionResult is StatusCodeResult scr)
            {
                // Assert
                Assert.AreEqual(200, scr.StatusCode);
            }
        }

        [Test]
        public async Task CreateBookingAsync()
        {
            // Arrange - In OneTimeSetUp
            // Act
            BookingDto newBooking = new() { Id = 2 };
            var idActionResult = (await _testBookingWebApi.PostAsync(newBooking)).Result;
            if (idActionResult is ObjectResult objRes)
            {
                // Assert
                Assert.AreEqual(200, objRes.StatusCode, "Status code returned was not 200");

                int bookingId = (int) objRes.Value;
                Assert.AreEqual(bookingId, newBooking.Id, "Booking wasn't created");

            }
            else if (idActionResult is StatusCodeResult scr)
            {
                // Assert
                Assert.AreEqual(200, scr.StatusCode);
            }
        }
    }
}
