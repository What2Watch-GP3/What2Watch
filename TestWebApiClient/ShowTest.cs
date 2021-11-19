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
    class ShowTest
    {
        private IWhatToWatchApiClient _stubsClient;

        [OneTimeSetUp]
        public async Task OneTimeSetUp()
        {
            ShowDto show = new ShowDto() { Id = 1, StartTime = DateTime.Now };
            IEnumerable<ShowDto> showDtos = new List<ShowDto>() { show };

            _stubsClient = new WhatToWatchApiClient(new RestClientStub() { ResponseData = showDtos });
        }

        [Test]
        public async Task GettingShowsBasedOnMovieIdAndCinemaIdReturnsListOfShowsBiggerThan0()
        {
            //act
            var shows = await _stubsClient.GetShowsByMovieAndCinemaIdAsync(1, 1);

            //assert
            Assert.IsTrue(shows.Count() > 0, "The list of shows is empty.");
        }
    }
}
