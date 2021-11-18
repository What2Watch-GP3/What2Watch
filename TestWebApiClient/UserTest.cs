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
        private UserDto responseUserDto;
        [OneTimeSetUp]
        public async Task OneTimeSetUp()
        {
            //arrange
            userDto = new UserDto() { Email = "test@user.dk", Password = "password1234" };
            responseUserDto = new UserDto() {Id = 1, Email = "test@user.dk", Password = "password1234" };
            _webApiClient = new WhatToWatchApiClient(new RestClientStub() { ResponseData = responseUserDto });
        }

        [Test]
        public async Task TestLoginUserDtoGetsAnId()
        {
            //act

           var userDtoId = await _webApiClient.LoginAsync(userDto);

            //assert
            Assert.That(userDtoId, Is.InstanceOf<UserDto>(), "User object was not from instance userDto");
            Assert.AreEqual(1, userDtoId.Id);
        }
    }
}
