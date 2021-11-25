using DataAccess.DataAccess;
using DataAccess.Interfaces;
using DataAccess.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDataAccess
{
    class ShowTest
    {
        private IShowDataAccess _showDataAccess;

        [OneTimeSetUp]

        public async Task SetUp()
        {
            _showDataAccess = new ShowDataAccess(Configuration.CONNECTION_STRING_TEST);
        }

        [Test]
        public async Task GettingOneShowById1ReturnsAShow()
        {
            //act
            var show = await _showDataAccess.GetByIdAsync(1);
            //assert
            Assert.NotNull(show, $"No Show found by the id 1");
        }

        [Test]
        public async Task GettingAListOfShowsByMovieAndCinemaReturnsListBiggerThan0()
        {
            //act
            var shows = await _showDataAccess.GetListByMovieAndCinemaIdAsync(1,1);

            //assert
            Assert.IsTrue(shows.Count() > 0, "List of shows is currently 0");
        }

        [Test]
        public async Task InsertingShowInDatabaseReturningId()
        {
            //arrange
            Show show = new() { StartTime = DateTime.Now, MovieId = 1, RoomId = 1 };
            //act
            int actualId = await _showDataAccess.CreateAsync(show);
            //assert
            Assert.IsTrue(actualId > 0, $"Created Show returned wrong id {actualId}");
        }
    }
}
