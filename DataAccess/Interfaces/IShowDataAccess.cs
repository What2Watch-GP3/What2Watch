using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IShowDataAccess :IBaseDataAccess<Show>
    {
        Task<IEnumerable<Show>> GetListByMovieAndCinemaIdAsync(int movieId, int cinemaId);

       
    }
}
