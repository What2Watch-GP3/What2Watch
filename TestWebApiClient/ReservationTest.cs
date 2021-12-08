using NUnit.Framework;
using StubsClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiClient.DTOs;
using WebApiClient;

namespace TestWebApiClient
{
    class ReservationTest
    {
        private IWebApiClient _stubsClient;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _stubsClient = new WebApiClient.WebApiClient(new RestClientStub() { ResponseData = new List<int>() { 1, 2, 3 } });
        }

        [Test]
        public async Task CreatingReservationReturnsCorrectId()
        {
            //Arrange
            IEnumerable<ReservationDto> reservationDtos = new List<ReservationDto>()
            {
                new ReservationDto() { CreationTime = DateTime.Now, SeatId = 1, ShowId = 1, UserId = 1 },
                new ReservationDto() { CreationTime = DateTime.Now, SeatId = 2, ShowId = 1, UserId = 1 },
                new ReservationDto() { CreationTime = DateTime.Now, SeatId = 3, ShowId = 1, UserId = 1 }
            };
            //Act
            IEnumerable<int> reservationIds = await _stubsClient.CreateReservationAsync(reservationDtos);
            //Assert
            Assert.AreEqual(reservationIds.Count(), 3, $"Returned Ids were wrong. Returned Ids were {reservationIds}.");
            }
    }
}
