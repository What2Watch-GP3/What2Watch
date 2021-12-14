using NUnit.Framework;
using StubsClassLibrary;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.DTOs;

namespace TestWebApiClient
{
    class UserTest
    {
        private IWebApiClient _webApiClient;
        private UserDto _userDto;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            //Arrange
            _userDto = new UserDto() { Id = 1, Email = "test@user.dk", Password = "password1234" };
            _webApiClient = new WebApiClient.WebApiClient(new RestClientStub() { ResponseData = _userDto });
        }

        [Test]
        public async Task TestLoginUserDtoGetsAnId()
        {
            //Arrange
            //Act
           var userDto = await _webApiClient.LoginAsync(_userDto);

            //Assert
            Assert.That(userDto, Is.InstanceOf<UserDto>(), "User was not from instance userDto");
            Assert.AreEqual(1, userDto.Id, "Returned id was not 1");
        }
    }
}
