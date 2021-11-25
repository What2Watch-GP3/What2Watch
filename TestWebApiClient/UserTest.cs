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
    class UserTest
    {
        private WhatToWatchApiClient _webApiClient;
        private UserDto userDto;

        [OneTimeSetUp]
        public async Task OneTimeSetUp()
        {
            //arrange
            userDto = new UserDto() { Email = "test@user.dk", Password = "password1234" };
            int responseUserId = 1;
            _webApiClient = new WhatToWatchApiClient(new RestClientStub() { ResponseData = responseUserId });
        }

        [Test]
        public async Task TestLoginUserDtoGetsAnId()
        {
            //act
           var userDto = await _webApiClient.LoginAsync(this.userDto);

            //assert
            Assert.That(userDto, Is.InstanceOf<UserDto>(), "User object was not from instance userDto");
            Assert.AreEqual(1, userDto.Id);
        }
    }
}
