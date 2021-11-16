using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using StubsClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            var movies = (await _movieController.GetAllAsync()).Value;

            //assert
            Assert.IsTrue(movies.Count() > 0, "List of movies is curently 0");
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
