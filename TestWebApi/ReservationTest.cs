using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System.Threading.Tasks;
using WebApi.Controllers;
using StubsClassLibrary;
using WebApi.DTOs;
using System;
using DataAccess.Models;

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
            ReservationDto reservationDto = new ReservationDto() { TimeStamp = DateTime.Now, SeatId = 1, ShowId = 1, UserId = 1 };

            //Act
            var reservationResult = (await _reservationController.CreateAsync(reservationDto)).Result;
            _objectResult = (ObjectResult)reservationResult;
            int reservationId = (int)_objectResult.Value;

            //Assert
            Assert.AreEqual(200, _objectResult.StatusCode, "Status coda was not OK (200).");
            Assert.IsTrue(reservationId > 0, $"Failed to create reservation. Returned id was {reservationId}");
        }

        [Test]
        public async Task CreatingReservationWithNullReservationDtoGivesBadRequestResponse()
        {
            //arrange
            ReservationDto reservation = null;
            //act
            var reservationResult = (await _reservationController.CreateAsync(reservation)).Result;
            StatusCodeResult statusCodeResult = (StatusCodeResult)reservationResult;
            //assert
            Assert.AreEqual(400, statusCodeResult.StatusCode, "Status coda was not BadRequest (400).");
        }
    }
}
