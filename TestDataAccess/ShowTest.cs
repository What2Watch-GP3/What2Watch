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

        public async Task<Show> GettingOneShowById(int id)
        {
            //arrange
            //act
            //assert

            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Show>> GetListByMovieAndCinemaIdAsync(int movieId, int cinemaId)
        {
            throw new NotImplementedException();
        }
    }
}
