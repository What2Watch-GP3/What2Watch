using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System.Threading.Tasks;
using WebApi.Controllers;
using StubsClassLibrary;
using WebApi.DTOs;
using System.Linq;
using System;
using DataAccess.Models;
using System.Collections.Generic;

namespace TestWebApi
{
    class ReservationTest
    {

        ReservationsController _reservationController;
        ObjectResult _objectResult;

        [SetUp]
        public void SetUp()
        {
            _objectResult = null;
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _reservationController = new ReservationsController(new ReservationStub());
        }

        [Test]
        public async Task CreatingReservationReturnsId()
        {
            //Arrange
            IEnumerable<ReservationDto> reservationDtos = new List<ReservationDto>()
            {
                new ReservationDto() { CreationTime = DateTime.Now, SeatId = 1, ShowId = 1, UserId = 1 },
                new ReservationDto() { CreationTime = DateTime.Now, SeatId = 2, ShowId = 1, UserId = 1 },
                new ReservationDto() { CreationTime = DateTime.Now, SeatId = 3, ShowId = 1, UserId = 1 }
            };

            //Act
            var reservationResult = (await _reservationController.CreateAsync(reservationDtos)).Result;
            _objectResult = (ObjectResult)reservationResult;
            IEnumerable<int> reservationIds = (IEnumerable<int>)_objectResult.Value;

            //Assert
            Assert.AreEqual(200, _objectResult.StatusCode, "Status coda was not OK (200).");
            Assert.AreEqual(reservationIds.Count(), 3, $"Failed to create reservations. Returned ids were {reservationIds}");
        }

        [Test]
        public async Task CreatingReservationWithNullReservationDtoGivesBadRequestResponse()
        {
            //arrange
            IEnumerable<ReservationDto> reservations = null;
            //act
            var reservationResult = (await _reservationController.CreateAsync(reservations)).Result;
            StatusCodeResult statusCodeResult = (StatusCodeResult)reservationResult;
            //assert
            Assert.AreEqual(400, statusCodeResult.StatusCode, "Status coda was not BadRequest (400).");
        }
        
        
    }
}
