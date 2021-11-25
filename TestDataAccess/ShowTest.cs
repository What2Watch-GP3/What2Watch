using DataAccess.DataAccess;
using DataAccess.Interfaces;
using NUnit.Framework;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace TestDataAccess
{
    class ShowTest
    {
        private IShowDataAccess _showDataAccess;

        [OneTimeSetUp]

        public void SetUp()
        {
            _showDataAccess = new ShowDataAccess(Configuration.CONNECTION_STRING_TEST);
        }

        [Test]
        public async Task GettingOneShowById1ReturnsAShow()
        {
            //Arrange
            //Act
            var show = await _showDataAccess.GetByIdAsync(1);

            //Assert
            Assert.NotNull(show, $"No Show found by the id 1");
        }

        [Test]
        public async Task GettingAListOfShowsByMovieAndCinemaReturnsListBiggerThan0WithCorrectDate()
        {
            //Arrange
            string expectedStartTime = "17.11.2021 18:00:00";

            //Act
            var shows = (await _showDataAccess.GetListByMovieAndCinemaIdAsync(1, 1)).ToList();
           
            //Assert
            Assert.IsTrue(shows.Count > 0, "List of shows is currently 0");
            Assert.AreEqual(expectedStartTime, shows[0].StartTime.ToString("G", CultureInfo.CreateSpecificCulture("de-DE")), "The time was wrong.");
        }
    }
}
