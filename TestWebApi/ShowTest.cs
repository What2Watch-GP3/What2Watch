using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using StubsClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Controllers;
using WebApi.DTOs;

namespace TestWebApi
{
    class ShowTest
    {
        ShowsController _showController;
        ObjectResult _objectResult;

        [SetUp]
        public void SetUp()
        {
            _objectResult = null;
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _showController = new ShowsController(new ShowStub());
        }

        [Test]
        public async Task GettingShowsByCinemaId1AndMovieId1ReturnsListOfShowsBiggerThan0()
        {
            //Arrange
            IEnumerable<ShowDto> shows;

            //Act
            var showResult = (await _showController.GetListByMovieAndCinemaIdAsync(1, 1)).Result;
            _objectResult = (ObjectResult)showResult;
            shows = (IEnumerable<ShowDto>)_objectResult.Value;

            //Assert
            Assert.AreEqual(200, _objectResult.StatusCode, "Status coda was not OK (200).");
            Assert.IsTrue(shows.Any(), "The List is empty.");
        }

        [Test]
        public async Task CreatingShowWithNullShowDtoGivesBadRequestResponse()
        {
            //arrange
            ShowDto show = null;
            //act
            var showResult = (await _showController.CreateShowAsync(show)).Result;
            StatusCodeResult statusCodeResult = (StatusCodeResult)showResult;
            //assert
            Assert.AreEqual(400, statusCodeResult.StatusCode, "Status coda was not BadRequest (400).");
        }

        [Test]
        public async Task CreatingShowGettingTheRightStatusCode()
        {
            //arrange
            ShowDto show = new() { StartTime = DateTime.Now, MovieId = 1, RoomId = 1 };
            //act
            var showResult = (await _showController.CreateShowAsync(show)).Result;
            _objectResult = (ObjectResult)showResult;
            int showId = (int)_objectResult.Value;
            //assert
            Assert.AreEqual(200, _objectResult.StatusCode, "Status coda was not OK (200).");
            Assert.IsTrue(showId > 0, $"Returned id was not more than 0. It was {showId}");
        }
    }
}
