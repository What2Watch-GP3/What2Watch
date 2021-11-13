using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using StubsClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApi.Controllers;
using WebApi.DTOs;

namespace TestWebApi
{
    class MovieTest
    {
        MovieController _movieController;

        [SetUp]

        public void Setup()
        {
            _movieController = new MovieController(new MovieStub());
        }

        //arrange
        //act
        //assert

        [Test]
        public async Task GettingAllMoviesReturningAListOfMovies()
        {
            //arrange

            //act
            var movieResult = (await _movieController.GetAllAsync()).Result;

            //if you have populated the ok() with actual movies, then it returns an ObjectResult(e.g.  OKObjectResult, NotFoundObjectResult, they all have statuscode ).
            //Option 1. assert for StatusCode property or Option 2. Assert for type - e.g. Assert.That(movieResult, Is.TypeOf<OKObjectResult>())
            if (movieResult is ObjectResult objRes)
            {
                //assert.equals is deprecated wtf
                Assert.AreEqual(200, objRes.StatusCode, "Status code returned was not 200");
                //you need to convert the value of the ObjectResult
                IEnumerable<MovieDto> movies = (IEnumerable<MovieDto>)objRes.Value;

                Assert.IsTrue(movies.Count() > 0, "List of movies is curently 0");
            }
            else if (movieResult is StatusCodeResult scr)
            {
                Assert.AreEqual(200, scr.StatusCode);
            }
            //if an empty status is sent back, then we need to test for a StatusCodeResult(which inheritantly has OKResult, NotFOundResult, etc. no value)

        }

        [Test]
        public async Task GettingOneMovieByIdReturnsRightMovie()
        {
            //arrange

            //act
            MovieDto movie = (await _movieController.GetByIdAsync(2)).Value;

            //assert
            Assert.IsTrue(movie.Id == 2, "The correct movie with id 2 wasn't found");
        }

        [Test]
        public async Task GettingMovieListOfMoviesContainsSearchString()
        {
            //arrange
            IEnumerable<MovieDto> movies;
            List<MovieDto> moviesList;

            //act
            movies = (await _movieController.GetListByPartOfNameAsync("Movie")).Value;
            moviesList = movies.ToList();

            //assert
            Assert.IsTrue(movies.Count() > 0, "List of movies is currently 0");
            Assert.IsTrue(moviesList[0].Title.Contains("Movie"), "Searchphrase was not found");

        }






    }
}
