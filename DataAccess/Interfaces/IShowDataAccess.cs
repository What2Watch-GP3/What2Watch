using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IShowDataAccess
    {
        Task<IEnumerable<Show>> GetListByMovieAndCinemaIdAsync(int movieId, int cinemaId);

        Task<Show> GetByIdAsync(int id);
    }
}
