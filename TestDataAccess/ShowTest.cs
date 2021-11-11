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
    class ShowTest
    {

        private ShowDataAccess _showDataAccess;


        [SetUp]

        public void Setup()
        {
            _showDataAccess = new ShowDataAccess(Configuration.CONNECTION_STRING_TEST);
           
        }

        [Test]

        public async Task GettingOneShowByIdReturnsAShow()
        {
            //arrange
            Show show;
            //act
            show = await _showDataAccess.GetByIdAsync(3);
            //assert
            Assert.NotNull(show, $"No Show found by the id 3");

        }

        [Test]
        public async Task GettingAListOfShowsByMovieAndCinemaReturnsListOfShows()
        {
            //arrange
            IEnumerable<Show> shows;

            //act
            shows = await _showDataAccess.GetListByMovieAndCinemaIdAsync(1,3);

            //assert
            Assert.IsTrue(shows.Count() > 0, "List of shows is currently 0");
        }
    }
}
