using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Controllers;
using StubsClassLibrary;
using WebApi.DTOs;

namespace TestWebApi
{
    class CinemaTest
    {
        CinemaController _cinemaController = new CinemaController(new CinemaStub());
        ObjectResult _objectResult;

        [SetUp]
        public void Setup()
        {
            _objectResult = null;
        }

        [Test]
        public async Task GettingCinemasByMovieIdReturnsListBiggerThan0()
        {
            //arrange
            IEnumerable<CinemaDto> cinemas;

            //act
            var cinemaResult = (await _cinemaController.GetListByMovieIdAsync(1)).Result;
            _objectResult = (ObjectResult)cinemaResult;
            cinemas = (IEnumerable<CinemaDto>)_objectResult.Value;

            //assert
            Assert.AreEqual(200, _objectResult.StatusCode, "Status code was not OK(200)");
            Assert.IsTrue(cinemas.Count() > 0, "List is currently 0");
        }

        


    }
}
