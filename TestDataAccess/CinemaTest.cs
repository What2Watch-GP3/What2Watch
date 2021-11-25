using DataAccess.DataAccess;
using DataAccess.Interfaces;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace TestDataAccess
{
    class CinemaTest
    {
        private ICinemaDataAccess _cinemaDataAccess;

        [OneTimeSetUp]
        public void SetUp()
        {
            _cinemaDataAccess = new CinemaDataAccess(Configuration.CONNECTION_STRING_TEST);
        }

        [Test]
        public async Task GettingOneCinemaById1ReturnsRightCinema()
        {
            //Arrange
            //Act
            var cinema = await _cinemaDataAccess.GetByIdAsync(1);

            //Assert
            Assert.NotNull(cinema, $"No Cinema found by the id 1");
        }

        [Test]
        public async Task GettingAllCinemasReturnsListBiggerThan0()
        {
            //Arrange
            //Act
            var cinemas = await _cinemaDataAccess.GetAllAsync();

            //Assert
            Assert.IsTrue(cinemas.Any(), "List of cinemas is currently 0");
        }

        [Test]
        public async Task GettingCinemasByMovieRturnsAListOfCinemas()
        {
            //Arrange
            //Act
            var cinemas = await _cinemaDataAccess.GetListByMovieIdAsync(1);

            //Assert
            Assert.IsTrue(cinemas.Any(), "List of cinemas is currently 0");
        }
    }
}
