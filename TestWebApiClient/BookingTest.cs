using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;
using StubsClassLibrary;
using WebApi.DTOs.Converters;
using DataAccess.Model;
using WebApiClient.DTOs;

namespace TestWebApiClient
{
    class BookingTest
    {
        private IWhatToWatchApiClient _webApiClient;

        [SetUp]
        public async Task Setup()
        {
            BookingDto bookingDto = new BookingDto() { Id = 3, TotalPrice = 30, Date = new DateTime(2021, 6, 10) };
            _webApiClient = new WhatToWatchApiClient(new RestClientStub() { ResponseData = bookingDto });
        }

        [Test]
        public async Task TestGetBookingById3()
        {
            BookingDto booking = await _webApiClient.GetBookingByIdAsync(3);
            Assert.AreEqual(booking.Id, 3, "Recieved booking wasn't with id 3");
        }

        [Test]
        public async Task TestCreateBooking()
        {
            Assert.Fail("Not implemented");
        }
    }
}
