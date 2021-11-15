using DataAccess.DataAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DataAccess.Interfaces;


namespace TestDataAccess
{
    class UserTest
    {
        private IUserDataAccess _userDataAccess;
        [SetUp]

        public void Setup()
        {
           //Arrange
            _userDataAccess = new UserDataAccess(Configuration.CONNECTION_STRING_TEST);
            //Console.WriteLine(BCrypt.Net.BCrypt.HashPassword("password1234", 13));
        }
        [Test]
        public async Task SuccessfulLoginUserWithID1()
        {
            //Act
            var userID = await _userDataAccess.LoginAsync(
                new User(){
                Email = "test@user.dk", Password = "password1234"
                });
            //Assert
            Assert.AreEqual(1, userID,"User ID was not found");

        }
        [Test]
        public async Task WrongPasswordLoginUser()
        {
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
