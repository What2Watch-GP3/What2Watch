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
        public async Task GettingAListOfShowsByMovieAndCinemaReturnsListBiggerThan0WithCorrectDate()
        {
            //act
            var shows = (await _showDataAccess.GetListByMovieAndCinemaIdAsync(1, 1)).ToList();
            string expectedStartTime = "2021-11-17 18:00:00";

            //assert
            Assert.IsTrue(shows.Count() > 0, "List of shows is currently 0");
            Assert.AreEqual(expectedStartTime, shows[0].StartTime, "The time was wrong.");
        }
    }
}
