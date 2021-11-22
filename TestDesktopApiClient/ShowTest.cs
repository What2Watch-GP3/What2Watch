using DesktopApiClient;
using DesktopApiClient.DTOs;
using NUnit.Framework;
using StubsClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDesktopApiClient
{
    class ShowTest
    {
        private IWhatToWatchApiClient _stubsClient;

        [OneTimeSetUp]
        public async Task OneTimeSetUp()
        {
            _stubsClient = new WhatToWatchApiClient(new RestClientStub() { ResponseData = 1 });
        }

        [Test]
        public async Task CreatedShowIdIsReturned()
        {
            //act
            ShowDto show = new ShowDto() { Id = 1, StartTime = DateTime.Now };
            var showId = await _stubsClient.CreateShowAsync(show);

            //assert
            Assert.AreEqual(1, showId, "Returned Show id was not the same");
        }
    }
}
