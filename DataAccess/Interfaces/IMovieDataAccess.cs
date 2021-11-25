using DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IMovieDataAccess : IBaseDataAccess<Movie>
    {
        Task<IEnumerable<Movie>> GetListByPartOfNameAsync(string searchString);
    }
}
