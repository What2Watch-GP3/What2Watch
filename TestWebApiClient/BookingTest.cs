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

        private IWhatToWatchApiClient _webApiClient;

        [OneTimeSetUp]
        public async Task OneTimeSetUp()
        {
            BookingDto bookingDto = new BookingDto() { Id = 1, TotalPrice = 30, Date = new DateTime(2021, 6, 10) };
            _webApiClient = new WhatToWatchApiClient(new RestClientStub() { ResponseData = bookingDto });
        }

        [Test]
        public async Task TestGetBookingById1()
        {
            // Arrange - In OneTimeSetUp
            // Act
            BookingDto actualBookingDto = await _webApiClient.GetBookingByIdAsync(1);
            // Assert
            Assert.AreEqual(actualBookingDto.Id, 1, "Recieved booking wasn't with id 1");
        }

        [Test]
        public async Task TestCreateBooking()
        {
            // Arrange
            BookingDto bookingToCreate = new() { Id = 1, TotalPrice = 30, Date = new DateTime(2021, 6, 10) };
            // Act
            int actualId = await _webApiClient.CreateBookingAsync(bookingToCreate);
            // Assert
            Assert.AreEqual(actualId, 1, "Failed to create booking with id 1");
        }
    }
}
