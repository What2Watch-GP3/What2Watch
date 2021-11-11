using DataAccess.DataAccess;
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
        private CinemaDataAccess _cinemaDataAccess;

        [SetUp]

        public void Setup()
        {
            _cinemaDataAccess = new CinemaDataAccess(Configuration.CONNECTION_STRING_TEST);

        }


        
        [Test]
        public async Task GettingOneCinemaByIdReturnsRightCinema()
        {
            //arrange
            Cinema cinema;
            //act
            cinema = await _cinemaDataAccess.GetByIdAsync(3);
            //assert
            Assert.NotNull(cinema, $"No Cinema found by the id 3");


        }

        [Test]

        public async Task GettingAllCinemasReturnsListOfMovies()
        {

            //arrange
            IEnumerable<Cinema> cinemas;

            //act
            cinemas = await _cinemaDataAccess.GetAllAsync();

            //assert
            Assert.IsTrue(cinemas.Count() > 0, "List of cinemas is currently 0");
        

        }

        [Test]
        public async Task GettingCinemasByMovieRturnsAListOfCinemas()
        {

            //arrange
            IEnumerable<Cinema> cinemas;

            //act
            cinemas = await _cinemaDataAccess.GetListByMovieIdAsync(1);

            //assert
            Assert.IsTrue(cinemas.Count() > 0, "List of cinemas is currently 0");
          
        }





    }
}
