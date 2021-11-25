using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using StubsClassLibrary;
using System.Threading.Tasks;
using WebApi.Controllers;
using WebApi.DTOs;

namespace TestWebApi
{
    class UserTest
    {
        LoginController _loginController = new LoginController(new UserStub());
        UserDto _userDto;
        ObjectResult _objectResult;

        [SetUp]
        public void Setup()
        {
            _objectResult = null;
            _userDto = new UserDto() { Email = "test@user.dk", Password = "password1234" };
        }

        [Test]
        public async Task GettingUserIdBasedOnLoginInfo()
        {
            //Arrange
            var userResult = (await _loginController.PostAsync(_userDto)).Result;

            //Assert
            //Assert.That(userResult, Is.TypeOf<ObjectResult>(),"User result was not from type object result");
            Assert.That(userResult, Is.InstanceOf<ObjectResult>(), "User result was not from type object result");
            ObjectResult objRes = (ObjectResult)userResult;
            Assert.AreEqual(1, objRes.Value, "User result was not 1");
        }
    }
}
