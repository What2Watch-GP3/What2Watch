using NUnit.Framework;
using StubsClassLibrary;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.DTOs;

namespace TestWebApiClient
{
    class CinemaTest
    {
        private IWhatToWatchApiClient _stubsClient;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            CinemaDto cinema = new CinemaDto() { Id = 1, Name = "Testema" };
            IEnumerable<CinemaDto> cinemaDtos = new List<CinemaDto>() { cinema };

            _stubsClient = new WhatToWatchApiClient(new RestClientStub() { ResponseData = cinemaDtos });
        }

        [Test]
        public async Task GettingCinemasBasedOnMovieIdReturnAListBiggerThan0()
        {
            //Arrange
            //Act
            var cinemas = await _stubsClient.GetCinemasByMovieIdAsync(1);

            //Assert
            Assert.IsTrue(cinemas.Any(), "The list of cinemas is empty.");
        }
    }
}
