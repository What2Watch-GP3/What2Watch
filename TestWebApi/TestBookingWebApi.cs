using DataAccess.Model;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using StubsClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Controllers;
using WebApi.DTOs;

namespace TestBookingWebApi
{
    class TestBookingWebApi
    {
        private BookingDto _newBookingDto;
        private BookingController _testBookingWebApi;

        [SetUp]
        public async Task Setup()
        {
            _testBookingWebApi = new BookingController(new BookingStubs());
        }
        //GETALL
        [Test]
        public async Task TestGetAllBookingsAsync()
        {
            //ACT
            var bookings = await _testBookingWebApi.GetAllAsync();
            //ASSERT
            Assert.IsTrue(bookings.Value.Count() > 0, "Bookings weren't returned");
        }

        //GETBYID
        [Test]
        public async Task GetBookingById3Async()
        {
            var actionResult = (await _testBookingWebApi.GetByIdAsync(3)).Result;
            if (actionResult is ObjectResult objRes)
            {
                Assert.AreEqual(200, objRes.StatusCode, "Status code returned was not 200");
                BookingDto booking = (BookingDto) objRes.Value;

                Assert.AreEqual(booking.Id, 3, "Booking id 3 was not recieved");
            }
            else if (actionResult is StatusCodeResult scr)
            {
                Assert.AreEqual(200, scr.StatusCode);
            }

        }
        //POST
        [Test]
        public async Task CreateBookingAsync()
        {
            var idActionResult = (await _testBookingWebApi.PostAsync(_newBookingDto)).Result;
            if (idActionResult is ObjectResult objRes)
            {
                Assert.AreEqual(200, objRes.StatusCode, "Status code returned was not 200");
                int bookingId = (int) objRes.Value;

                Assert.AreEqual(bookingId, _newBookingDto.Id, "Booking wasn't created");

            }
            else if (idActionResult is StatusCodeResult scr)
            {
                Assert.AreEqual(200, scr.StatusCode);
            }
        }

        //DELETE
        [Test]
        public async Task DeleteBookingId3Async()
        {
            //ARRANGE done in setup

            //ACT
            var booking = await _testBookingWebApi.DeleteAsync(3);
            //ASSERT
            Assert.IsTrue(booking.Equals(3), "Bookings weren't deleted");
        }


    }
}
