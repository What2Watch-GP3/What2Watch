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
            var show = await _showDataAccess.GetByIdAsync(3);
            //assert
            Assert.NotNull(show, $"No Show found by the id 3");
        }

        [Test]
        public async Task GettingAListOfShowsByMovieAndCinemaReturnsListBiggerThan0()
        {
            //act
            var shows = await _showDataAccess.GetListByMovieAndCinemaIdAsync(1,3);

            //assert
            Assert.IsTrue(shows.Count() > 0, "List of shows is currently 0");
        }
    }
}
