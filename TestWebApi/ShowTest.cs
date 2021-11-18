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

namespace TestWebApi
{
    class ShowTest
    {
        ShowsController _showController = new ShowsController(new ShowStub());
        ObjectResult _objectResult;

        [SetUp]
        public void Setup()
        {
            _objectResult = null;
        }

        [Test]
        public async Task GettingShowsByCinemaId1AndMovieId1ReturnsListOfShowsBiggerThan0()
        {
            //arrange
            IEnumerable<ShowDto> shows;

            //act
            var showResult = (await _showController.GetListByMovieAndCinemaIdAsync(1, 1)).Result;
            _objectResult = (ObjectResult)showResult;
            shows = (IEnumerable<ShowDto>)_objectResult.Value;

            //assert
            Assert.AreEqual(200, _objectResult.StatusCode, "Status coda was not OK (200).");
            Assert.IsTrue(shows.Count() > 0, "The List is empty.");
        }
    }
}
