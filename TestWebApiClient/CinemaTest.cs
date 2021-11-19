using NUnit.Framework;
using StubsClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.DTOs;

namespace TestWebApiClient
{
    class CinemaTest
    {
        private IWhatToWatchApiClient _stubsClient;

        [OneTimeSetUp]
        public async Task OneTimeSetUp()
        {
            CinemaDto cinema = new CinemaDto() { Id = 1, Name = "Testema" };
            IEnumerable<CinemaDto> cinemaDtos = new List<CinemaDto>() { cinema };

            _stubsClient = new WhatToWatchApiClient(new RestClientStub() { ResponseData = cinemaDtos });
        }

        [Test]
        public async Task GettingCinemasBasedOnMovieIdReturnAListBiggerThan0()
        {
            //act
            var cinemas = await _stubsClient.GetCinemasByMovieIdAsync(1);

            //assert
            Assert.IsTrue(cinemas.Count() > 0, "The list of cinemas is empty.");
        }
    }
}
