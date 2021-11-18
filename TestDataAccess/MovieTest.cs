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
    class MovieTest
    {
        private IMovieDataAccess _movieDataAccess;

        [OneTimeSetUp]
        public async Task SetUp()
        {
            _movieDataAccess = new MovieDataAccess(Configuration.CONNECTION_STRING_TEST);
        }

        [Test]
        public async Task GettingAllMoviesReturnsListOfMoviesBiggerThan0()
        {
            //act
            var movies = await _movieDataAccess.GetAllAsync();

            //assert
            Assert.IsTrue(movies.Count() > 0, "List of movies is currently 0");
        }

        [Test]
        public async Task GettingOneMovieById1ReturnsRightMovie()
        {
            //act
            var movie = await _movieDataAccess.GetByIdAsync(1);
            
            //assert
            Assert.NotNull(movie, $"No Movie found by the id 1");
            Assert.IsTrue(movie.Id == 1, $"The Id was not 1, it was {movie.Id}.");
        }


        [Test]
        public async Task GettingMovieListOfMoviesContainingSearchphrase()
        {
            //act
            var movies = (await _movieDataAccess.GetListByPartOfNameAsync("Harry")).ToList();

            //assert
            Assert.IsTrue(movies.Count() > 0, "List of movies is currently 0");
            Assert.IsTrue(movies[0].Title.Contains("Harry"), "Searchphrase was not found");
        }
    }
}
