using DataAccess.DataAccess;
using DataAccess.Models;
using System.Threading.Tasks;
using NUnit.Framework;
using DataAccess.Interfaces;

namespace TestDataAccess
{
    class UserTest
    {
        private IUserDataAccess _userDataAccess;

        [OneTimeSetUp]
        public void Setup()
        {
           //Arrange
            _userDataAccess = new UserDataAccess(Configuration.CONNECTION_STRING_TEST);
        }

        [Test]
        public async Task SuccessfulLoginUserWithID1()
        {
            //Arrange
            //Act
            var user = await _userDataAccess.LoginAsync(
                new User(){
                Email = "test@user.dk", Password = "password1234"});

            //Assert
            Assert.AreEqual(1, user.Id,"User ID was not found");

        }

        [Test]
        public async Task WrongPasswordLoginUser()
        {
            //Arrange
            //Act
            var user = await _userDataAccess.LoginAsync(
                new User()
                {
                    Email = "test@user.dk",
                    Password = "password12345"
               });
            //Assert
            Assert.IsNull(user, "User was not not null");

        }

        [Test]
        public async Task WrongEmailLoginUser()
        {
            //Arrange
            //Act
            var userDto = await _userDataAccess.LoginAsync(
                new User()
                {
                    Email = "tests@user.dk",
                    Password = "password1234"
                });
            //Assert
            Assert.IsNull(userDto, "User ID was found");

        }

    }
}
