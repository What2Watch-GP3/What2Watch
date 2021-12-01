using NUnit.Framework;
using System;
using System.Threading.Tasks;
using WebApiClient;
using StubsClassLibrary;
using WebApiClient.DTOs;

namespace TestWebApiClient
{
    class BookingTest
    {
        private IWebApiClient _webApiClient;
        private IWebApiClient _webApiIdClient;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            BookingDto bookingDto = new() { Id = 1, TotalPrice = 30, Date = new DateTime(2021, 6, 10) };
            _webApiClient = new WebApiClient.WebApiClient(new RestClientStub() { ResponseData = bookingDto });
            _webApiIdClient = new WebApiClient.WebApiClient(new RestClientStub() { ResponseData = 1 });
        }

        [Test]
        public async Task TestGetBookingById1()
        {
            //Arrange - In OneTimeSetUp
            //Act
            BookingDto actualBookingDto = await _webApiClient.GetBookingByIdAsync(1);

            //Assert
            Assert.AreEqual(1, actualBookingDto.Id, "Recieved booking wasn't with id 1");
        }

        [Test]
        public async Task TestCreateBooking()
        {
            //Arrange
            BookingDto bookingToCreate = new() { Id = 1, TotalPrice = 30, Date = new DateTime(2021, 6, 10) };

            //Act
            int actualId = await _webApiIdClient.ConfirmBookingAsync(bookingToCreate);

            //Assert
            Assert.AreEqual(1, actualId, "Failed to create booking with id 1");
        }
    }
}
