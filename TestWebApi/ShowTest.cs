using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using StubsClassLibrary;
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
    }
}
