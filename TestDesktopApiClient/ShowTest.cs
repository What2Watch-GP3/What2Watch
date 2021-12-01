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
        private IDesktopApiClient _stubsClient;

        [OneTimeSetUp]
        public async Task OneTimeSetUp()
        {
            _stubsClient = new DesktopApiClient.DesktopApiClient(new RestClientStub() { ResponseData = 1 });
        }

        [Test]
        public async Task CreatedShowIdIsReturned()
        {
            //act
            ShowDto show = new ShowDto() { StartTime = DateTime.Now, RoomId = 1,MovieId = 1 };
            var showId = await _stubsClient.CreateShowAsync(show);

            //assert
            Assert.IsTrue(showId > 0, $"Wrong show id returned, was {showId}");
        }
    }
}
