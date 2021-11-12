using DataAccess.Model;
using NUnit.Framework;
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
        private Booking _newBooking;
        private BookingDto _newBookingDto;
        private BookingController _testBookingWebApi;

        [SetUp]
        public async Task Setup()
        {

            _newBooking = new Booking() { TotalPrice = 23, Date = DateTime.Now };
        }
        //GETALL
        [Test]
        public async Task TestGetAllBookingsAsync()
        {
            //ARRANGE

            //ACT
            var bookings = await _testBookingWebApi.GetAllAsync();
            //ASSERT
            Assert.IsTrue(bookings.Value.Count() > 0, "Bookings weren't returned");
        }

        //GETBYID
        [Test]
        public async Task GetBookingByIdAsync()
        {
            //ARRANGE
            //ACT
            var booking = await _testBookingWebApi.GetByIdAsync(3);
            //ASSERT
            Assert.IsTrue(booking.Value.Equals(1) , "Bookings weren't returned");
        }
        //POST
        [Test]
        public async Task CreateBlogPostAsync()
        {
            //ARRANGE & ACT done in setup
            var booking = await _testBookingWebApi.PostAsync(_newBookingDto);
            //ASSERT
            Assert.IsTrue(booking.Equals(0), "Bookings weren't created");
        }

        //DELETE
        [Test]
        public async Task DeleteBookingAsync()
        {
            //ARRANGE done in setup

            //ACT
            var booking = await _testBookingWebApi.DeleteAsync(1);
            //ASSERT
            Assert.IsTrue(booking.Equals(0), "Bookings weren't deleted");
        }


    }
}
