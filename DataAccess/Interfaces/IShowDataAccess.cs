using DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IShowDataAccess : IBaseDataAccess<Show>
    {
        Task<IEnumerable<Show>> GetListByMovieAndCinemaIdAsync(int movieId, int cinemaId);
        Task<Show> GetByShowIdAsync(int showId);
    }
}
