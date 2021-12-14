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
        private IShowDataAccess _randomDataAccess;
        private int _lastCreatedId;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _randomDataAccess = new ShowDataAccess(Configuration.CONNECTION_STRING_TEST);
        }
             
        [Test]
        [Order(1)]
        public async Task CreateAnObject()
        {
            //Arrange
            Show randomObject = new() { 
                StartTime = DateTime.Now,
                MovieId = 1,
                RoomId = 1,
                DubLanguage = "English",
                SubtitlesLanguage = "English",
                GraphicType = "_2D",
                SoundType = "iMax"
            };
            //Act
            _lastCreatedId = await _randomDataAccess.CreateAsync(randomObject);
            //Assert
            Assert.IsTrue(_lastCreatedId > 0, "The object was not created.");
        }

        [Test]
        [Order(2)]
        public async Task GetAnObject()
        {
            //Arrange
            //Act
            Show randomObject = await _randomDataAccess.GetByIdAsync(_lastCreatedId);

            //Assert
            Assert.IsNotNull(randomObject, $"Could not find an object with id: `{_lastCreatedId}`.");
        }

        [Test]
        [Order(3)]
        public async Task GetAllObjectsReturnsAListBiggerThan0()
        {
            //Arrange
            //Act
            var randomObjects = await _randomDataAccess.GetAllAsync();

            //Assert
            Assert.IsNotEmpty(randomObjects, $"The list of objects was empty.");
        }

        [Test]
        [Order(4)]
        public async Task UpdateAnObject()
        {
            //Arrange
            Show newObject = new()
            {
                Id = _lastCreatedId,
                StartTime = DateTime.Now,
                MovieId = 2, // Changed from 1
                RoomId = 1,
                DubLanguage = "English",
                SubtitlesLanguage = "English",
                GraphicType = "_2D",
                SoundType = "iMax"
            };
            //Act
            bool updated = await _randomDataAccess.UpdateAsync(newObject);
            Show updatedObject = await _randomDataAccess.GetByIdAsync(_lastCreatedId);
            //Assert
            Assert.IsTrue(updated, $"The dataAccess method for updating a row with id: {_lastCreatedId} returned false.");
            Assert.IsTrue(updatedObject.MovieId == 2, "The database row returned a different value.");
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
