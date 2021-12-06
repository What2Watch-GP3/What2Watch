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
            _stubsClient = new WebApiClient.WebApiClient(new RestClientStub() { ResponseData = 1 });
        }

        [Test]
        public async Task CreatingReservationReturnsCorrectId()
        {
            //Arrange
            ReservationDto reservationDto = new ReservationDto() { TimeStamp = DateTime.Now, SeatId = 1, ShowId = 1, UserId = 1 };
            //Act
            int reservationId = await _stubsClient.CreateReservationAsync(reservationDto);
            //Assert
            Assert.IsTrue(reservationId > 0, $"Returned Id was wrong. Returned Id was {reservationId}.");
        }
    }
}
