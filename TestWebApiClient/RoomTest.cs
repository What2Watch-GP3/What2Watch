using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using StubsClassLibrary;
using WebApiClient.DTOs;
using WebApiClient;

namespace TestWebApiClient
{
    class RoomTest
    {
        private IWebApiClient _webApiClient;
        //private IWebApiClient _webApiIdClient;
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            //Arrange
            //IEnumerable<SeatDto> Seats = IEnumerable.Empty<SeatDto>();
            IEnumerable<SeatDto> Seats = new List<SeatDto>(){   new SeatDto() { Position = 1, RowNumber = 1, IsReserved = true },
                                                                new SeatDto() { Position = 3, RowNumber = 1, IsReserved = true },
                                                                new SeatDto() { Position = 5, RowNumber = 1, IsReserved = false }};
            RoomDto roomDto = new() { Id = 1, Name = "Room 1",Rows = 8, Columns = 10, Seats = Seats };
            _webApiClient = new WebApiClient.WebApiClient(new RestClientStub() { ResponseData = roomDto });
            //_webApiIdClient = new WebApiClient.WebApiClient(new RestClientStub() { ResponseData = 1 });
        }

        [Test]
        public async Task TestGetRoomByShowId1()
        {
            //Arrange - In OneTimeSetUp
            //Act
            RoomDto actualRoomDto = await _webApiClient.GetRoomByShowIdAsync(1);

            //Assert
            Assert.AreEqual(1, actualRoomDto.Id, "Recieved room wasn't with id 1");
        }

        [Test]
        public async Task TestCheckAvailabilitySeats()
        {
            //ARRANGE
            //Act
            RoomDto actualRoomDto = await _webApiClient.GetRoomByShowIdAsync(1);
            IEnumerable<SeatDto> actualSeats = actualRoomDto.Seats;

            //Assert
            Assert.AreEqual(true, actualSeats.ToList()[0].IsReserved, "Failed to check with id 1 | Availability failed");
            Assert.AreEqual(true, actualSeats.ToList()[1].IsReserved, "Failed to check with id 1 | Availability failed");
            Assert.AreEqual(false, actualSeats.ToList()[2].IsReserved, "Failed to check with id 1 | Availability failed");
        }
    }
}
