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
    class MovieTest
    {
        private MovieDataAccess _movieDataAccess;
        [SetUp]

        public void Setup()
        {
            _movieDataAccess = new MovieDataAccess(Configuration.CONNECTION_STRING_TEST);


        }

        [Test]

        public async Task GettingAllMoviesReturnsListOfMovies()
        {

            //arrange
            IEnumerable<Movie> movies ;

            //act
            movies = await _movieDataAccess.GetAllAsync();

            //assert
            Assert.IsTrue(movies.Count() > 0, "List of movies is currently 0");

        }

        [Test]
        public async Task GettingOneMovieByIdReturnsRightMovie()
        {
            //arrange
            Movie movie;
            //act
            movie = await _movieDataAccess.GetByIdAsync(1);           
            //assert
            Assert.NotNull(movie, $"No Movie found by the id 1");

        }


        [Test]
        public async Task GettingMovieListOfMoviesContainingSearchphrase()
        {

            //arrange
            IEnumerable<Movie> movies;
            List<Movie> moviesList;

            //act
            movies = await _movieDataAccess.GetByPartOfNameAsync("Harry");
            moviesList = movies.ToList();


            //assert
            Assert.IsTrue(movies.Count() > 0, "List of movies is currently 0");
            Assert.IsTrue(moviesList[0].Title.Contains("Harry"), "Searchphrase was not found");


        }
       
    }
}
