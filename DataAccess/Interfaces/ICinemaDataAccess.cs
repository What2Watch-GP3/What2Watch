using DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface ICinemaDataAccess : IBaseDataAccess<Cinema>
    {
        Task<IEnumerable<Cinema>> GetListByMovieIdAsync(int movieId);
    }
}
