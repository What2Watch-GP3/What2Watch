using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using StubsClassLibrary;
using WebApi.Controllers;
using WebApi.DTOs;

namespace TestWebApi
{
    public class RoomTest
    {
        RoomsController _roomController;
        ObjectResult _objectResult;

        [SetUp]
        public void SetUp()
        {
            _objectResult = null;
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _roomController = new RoomsController(new RoomStub(),new SeatStub(), new ShowStub(), new TicketStub(), new ReservationStub());
        }

        [Test]
        public async Task GettingRoomContainingSeatsBasedOnShowIdIsNotEmpty()
        {
            //Arrange
            RoomDto roomDto;

            //Act
            var roomResult = (await _roomController.GetByShowIdAsync(1)).Result;
            _objectResult = (ObjectResult)roomResult;
            roomDto = (RoomDto)_objectResult.Value;

            //Assert
            Assert.AreEqual(200, _objectResult.StatusCode, "Status code was not OK (200).");
            Assert.IsTrue(roomDto.Seats.Any(), "The List is empty.");
        }
    }
}
