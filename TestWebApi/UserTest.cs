using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using StubsClassLibrary;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Controllers;
using WebApi.DTOs;

namespace TestWebApi
{
    class UserTest
    {
        LoginController _loginController;
        UserDto _userDto;
        ObjectResult _objectResult;

        [OneTimeSetUp]
        public void Setup()
        {
            _objectResult = null;
            _userDto = new UserDto() { Email = "test@user.dk", Password = "password1234" };
            _loginController = new(null, new UserStub());
        }

        [Test]
        public async Task GettingUserIdBasedOnLoginInfo()
        {
            //Arrange
            var userResult = (await _loginController.PostAsync(_userDto)).Result;

            //Assert
            //Assert.That(userResult, Is.TypeOf<ObjectResult>(),"User result was not from type object result");
            Assert.That(userResult, Is.InstanceOf<ObjectResult>(), "User was not found based on ObjectResult");
            ObjectResult objRes = (ObjectResult)userResult;
            Assert.AreEqual(1, ((UserDto)objRes.Value).Id, "User result was not 1");
        }
    }
}
