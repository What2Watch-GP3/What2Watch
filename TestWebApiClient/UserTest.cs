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
        private UserDto userDto;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            //Arrange
            userDto = new UserDto() { Email = "test@user.dk", Password = "password1234" };
            int responseUserId = 1;
            _webApiClient = new WebApiClient.WebApiClient(new RestClientStub() { ResponseData = responseUserId });
        }

        [Test]
        public async Task TestLoginUserDtoGetsAnId()
        {
            //Arrange
            //Act
           var userDtoId = await _webApiClient.LoginAsync(this.userDto);

            //Assert
            //Assert.That(userDto, Is.InstanceOf<UserDto>(), "User object was not from instance userDto");
            Assert.AreEqual(1, userDtoId);
        }
    }
}
