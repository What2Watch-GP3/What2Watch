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
            var userID = await _userDataAccess.LoginAsync(
                new User(){
                Email = "test@user.dk", Password = "password1234"});

            //Assert
            Assert.AreEqual(1, userID,"User ID was not found");

        }

        [Test]
        public async Task WrongPasswordLoginUser()
        {
            //Arrange
            //Act
            var userID = await _userDataAccess.LoginAsync(
                new User()
                {
                    Email = "test@user.dk",
                    Password = "password12345"
               });
            //Assert
            Assert.AreEqual(-1, userID, "User ID was not -1");

        }

        [Test]
        public async Task WrongEmailLoginUser()
        {
            //Arrange
            //Act
            var userID = await _userDataAccess.LoginAsync(
                new User()
                {
                    Email = "tests@user.dk",
                    Password = "password1234"
                });
            //Assert
            Assert.AreEqual(-1, userID, "User ID was found");

        }

    }
}
