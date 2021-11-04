using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    interface ICinemaDataAccess
    {

        

        Task<Cinema> GetByIdAsync(int id);

        Task<IEnumerable<Cinema>> GetListByMovieIdAsync(int movieId);
    }
}
