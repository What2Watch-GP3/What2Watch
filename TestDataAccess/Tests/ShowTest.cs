using DataAccess.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDataAccess.Tests
{
    class ShowTest
    {

        [SetUp]

        public void Setup()
        {


        }

        [Test]

        public async Task<Show> GettingOneShowById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Show>> GetListByMovieAndCinemaIdAsync(int movieId, int cinemaId)
        {
            throw new NotImplementedException();
        }
    }
}
