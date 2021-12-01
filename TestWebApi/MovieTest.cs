using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using StubsClassLibrary;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Controllers;
using WebApi.DTOs;

namespace TestWebApi
{
    class MovieTest
    {
        MoviesController _movieController;
        ObjectResult _objectResult;

        [SetUp]
        public void SetUp()
        {
            _objectResult = null;
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _movieController = new MoviesController(new MovieStub());
        }

        [Test]
        public async Task GettingAllMoviesReturningAListOfMovies()
        {
            //Arrange

            //Act
            var movieResult = (await _movieController.GetAllAsync()).Result;

            //if you have populated the ok() with actual movies, then it returns an ObjectResult(e.g.  OKObjectResult, NotFoundObjectResult, they all have statuscode ).
            //Option 1. assert for StatusCode property or Option 2. Assert for type - e.g. Assert.That(movieResult, Is.TypeOf<OKObjectResult>())
            if (movieResult is ObjectResult objRes)
            {
                //Assert
                Assert.AreEqual(200, objRes.StatusCode, "Status code returned was not 200");

                //you need to convert the value of the ObjectResult
                IEnumerable<MovieDto> movies = (IEnumerable<MovieDto>)objRes.Value;

                Assert.IsTrue(movies.Any(), "List of movies is curently 0");
            }
            else if (movieResult is StatusCodeResult scr)
            {
                Assert.AreEqual(200, scr.StatusCode);
            }
            //if an empty status is sent back, then we need to test for a StatusCodeResult(which inheritantly has OKResult, NotFOundResult, etc. no value)
        }

        /*This test is commented because it will be needed in future:
        [Test]
        public async Task GettingOneMovieById2ReturnsRightMovie()
        {
            //arrange
            MovieDto movie;

            //act
            var movieResult = (await _movieController.GetByIdAsync(2)).Result;
            _objectResult = (ObjectResult)movieResult;
            movie = (MovieDto)_objectResult.Value;

            //assert
            Assert.IsTrue(movie.Id == 2, "The correct movie with id 2 wasn't found");
            Assert.AreEqual(200, _objectResult.StatusCode, "Status was not OK (200).");
        }*/

        [Test]
        public async Task GettingMovieListOfMoviesContainsSearchString()
        {
            //Act
            var movieResult = (await _movieController.GetListByPartOfNameAsync("2")).Result;
            _objectResult = (ObjectResult)movieResult;
            var movies = ((IEnumerable<MovieDto>)_objectResult.Value).ToList();

            //Assert
            Assert.IsTrue(movies.Any(), "List of movies is currently 0");
            Assert.IsTrue(movies[0].Title.Contains("2"), "Searchphrase was not found");
            Assert.AreEqual(200, _objectResult.StatusCode, "Status code was not OK (200).");
        }






    }
}
