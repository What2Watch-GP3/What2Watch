using DataAccess.DataAccess;
using DataAccess.Interfaces;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace TestDataAccess
{
    class MovieTest
    {
        private IMovieDataAccess _movieDataAccess;

        [OneTimeSetUp]
        public void SetUp()
        {
            _movieDataAccess = new MovieDataAccess(Configuration.CONNECTION_STRING_TEST);
        }

        [Test]
        public async Task GettingAllMoviesReturnsListOfMoviesBiggerThan0()
        {
            //Arrange
            //Act
            var movies = await _movieDataAccess.GetAllAsync();

            //Assert
            Assert.IsTrue(movies.Any(), "List of movies is currently 0");
        }

        [Test]
        public async Task GettingOneMovieById1ReturnsRightMovie()
        {
            //Arrange
            //Act
            var movie = await _movieDataAccess.GetByIdAsync(1);
            
            //Assert
            Assert.NotNull(movie, $"No Movie found by the id 1");
            Assert.IsTrue(movie.Id == 1, $"The Id was not 1, it was {movie.Id}.");
        }

        [Test]
        public async Task GettingMovieListOfMoviesContainingSearchphrase()
        {
            //Arrange
            //Act
            var movies = (await _movieDataAccess.GetListByPartOfNameAsync("Harry")).ToList();

            //Assert
            Assert.IsTrue(movies.Count() > 0, "List of movies is currently 0");
            Assert.IsTrue(movies[0].Title.Contains("Harry"), "Searchphrase was not found");
        }
    }
}
