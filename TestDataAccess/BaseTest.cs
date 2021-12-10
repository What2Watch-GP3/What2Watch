using DataAccess.DataAccess;
using DataAccess.Interfaces;
using DataAccess.Models;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace TestDataAccess
{
    class BaseTest
    {
        private IBookingDataAccess _randomDataAccess;
        private int _lastCreatedId;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _randomDataAccess = new BookingDataAccess(Configuration.CONNECTION_STRING_TEST);
        }
             
        [Test]
        [Order(1)]
        public async Task CreateAnObject()
        {
            //Arrange
            Booking randomObject = new Booking() { TotalPrice = 190M, Date = DateTime.Now, UserId = 1};

            //Act
            _lastCreatedId = await _randomDataAccess.CreateAsync(randomObject);

            //Assert
            Assert.IsTrue(_lastCreatedId > 0, "The booking was not created.");
        }

        [Test]
        [Order(2)]
        public async Task GetAnObject()
        {
            //Arrange
            //Act
            Booking randomObject = await _randomDataAccess.GetByIdAsync(_lastCreatedId);

            //Assert
            Assert.IsNotNull(randomObject, $"Could not find a booking with id: {_lastCreatedId}.");
        }

        [Test]
        [Order(3)]
        public async Task GetAllObjectsReturnsAListBiggerThan0()
        {
            //Arrange
            //Act
            var randomObjects = await _randomDataAccess.GetAllAsync();

            //Assert
            Assert.IsNotEmpty(randomObjects, $"The list of bookings was empty.");
        }

        [Test]
        [Order(4)]
        public async Task UpdateAnObject()
        {
            //Arrange
            Booking newObject = new Booking() { Id = _lastCreatedId, TotalPrice = 200M, Date = DateTime.Now };
            //Act
            bool updated = await _randomDataAccess.UpdateAsync(newObject);
            Booking updatedObject = await _randomDataAccess.GetByIdAsync(_lastCreatedId);
            //Assert
            Assert.IsTrue(updated, $"The dataAccess method for updating a row with id: {_lastCreatedId} returned false.");
            Assert.IsTrue(updatedObject.TotalPrice == 200M, "The database row returned a different value.");
        }

        [Test]
        [Order(5)]
        public async Task DeleteAnObject()
        {
            //Arrange
            //Act
            bool deleted = await _randomDataAccess.DeleteAsync(_lastCreatedId);
            var objects = await _randomDataAccess.GetAllAsync();

            //Assert
            Assert.IsTrue(deleted, $"The dataAccess method for deletion for row with id: {_lastCreatedId} returned false.");
            Assert.IsFalse(objects.Any(randomObject => randomObject.Id == _lastCreatedId), $"The object was not deleted from the database.");
        }
    }
}
