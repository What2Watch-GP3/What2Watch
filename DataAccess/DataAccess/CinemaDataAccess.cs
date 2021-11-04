using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataAccess
{
    class CinemaDataAccess : ICinemaDataAccess
    {
        
        public async Task<Cinema> GetByIdAsync(int id)
        {
           
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Cinema>> GetListByMovieIdAsync(int movieId)
        {
            throw new NotImplementedException();
        }
    }
}
