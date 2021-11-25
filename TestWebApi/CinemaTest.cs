using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Controllers;
using StubsClassLibrary;
using WebApi.DTOs;

namespace TestWebApi
{
    class CinemaTest
    {
        CinemasController _cinemaController; 
        ObjectResult _objectResult;

        [SetUp]
        public void SetUp()
        {
            _objectResult = null;
        }

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _cinemaController = new CinemasController(new CinemaStub());
        }

        [Test]
        public async Task GettingCinemasByMovieIdReturnsListBiggerThan0()
        {
            //Arrange
            IEnumerable<CinemaDto> cinemas;

            //Act
            var cinemaResult = (await _cinemaController.GetListByMovieIdAsync(1)).Result;
            _objectResult = (ObjectResult)cinemaResult;
            cinemas = (IEnumerable<CinemaDto>)_objectResult.Value;

            //Assert
            Assert.AreEqual(200, _objectResult.StatusCode, "Status code was not OK(200)");
            Assert.IsTrue(cinemas.Any(), "List is currently 0");
        }
    }
}
