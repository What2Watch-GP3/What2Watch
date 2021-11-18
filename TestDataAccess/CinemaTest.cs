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
    class CinemaTest
    {
        private ICinemaDataAccess _cinemaDataAccess;

        [OneTimeSetUp]
        public async Task SetUp()
        {
            _cinemaDataAccess = new CinemaDataAccess(Configuration.CONNECTION_STRING_TEST);
        }

        [Test]
        public async Task GettingOneCinemaById1ReturnsRightCinema()
        {
            //act
            var cinema = await _cinemaDataAccess.GetByIdAsync(1);
            //assert
            Assert.NotNull(cinema, $"No Cinema found by the id 1");
        }

        [Test]
        public async Task GettingAllCinemasReturnsListBiggerThan0()
        {
            //act
            var cinemas = await _cinemaDataAccess.GetAllAsync();

            //assert
            Assert.IsTrue(cinemas.Count() > 0, "List of cinemas is currently 0");
        }

        [Test]
        public async Task GettingCinemasByMovieRturnsAListOfCinemas()
        {
            //act
            var cinemas = await _cinemaDataAccess.GetListByMovieIdAsync(1);

            //assert
            Assert.IsTrue(cinemas.Count() > 0, "List of cinemas is currently 0");
        }
    }
}
