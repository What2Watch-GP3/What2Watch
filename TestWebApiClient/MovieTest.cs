using NUnit.Framework;
using StubsClassLibrary;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.DTOs;

namespace TestWebApiClient
{
    public class MovieTest
    {
        private IWhatToWatchApiClient _stubClient;
        private IWhatToWatchApiClient _stubsClient;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            MovieDto movieDto = new MovieDto() { Id = 1, Duration = 90, Title = "Harry Tester: The Testosterone" };
            IEnumerable<MovieDto> movieDtos = new List<MovieDto>() { movieDto };

            _stubClient = new WhatToWatchApiClient(new RestClientStub() { ResponseData = movieDto });
            _stubsClient = new WhatToWatchApiClient(new RestClientStub() { ResponseData = movieDtos });
        }

        [Test]
        public async Task GettingAllMoviesReturnAListBiggerThan0()
        {
            //Arrange
            //Act
            var movies = await _stubsClient.GetAllMoviesAsync();

            //Assert
            Assert.IsTrue(movies.Any(), "The movie list is empty.");
        }

        [Test]
        public async Task GettingMovieById1ReturnRightMovie()
        {
            //Arrange
            //Act
            var movie = await _stubClient.GetMovieByIdAsync(1);

            //Assert
            Assert.AreEqual(1, movie.Id, $"The movie id is not 1, it was {movie.Id}.");
        }

        [Test]
        public async Task GettingMoviesByWordTestReturnsListOfRightMovies()
        {
            //Act
            var movies = (await _stubsClient.GetMoviesByPartOfNameAsync("Test")).ToList();

            //Assert
            Assert.IsTrue(movies.Count() > 0, "The list of movies searched by 'Test' is empty.");
            Assert.IsTrue(movies[0].Title.Contains("Test"), $"The title of the movie does not conatin 'Test' in it, basically not enough testosterone, the title is {movies[0].Title}.");
        }
    }
}
