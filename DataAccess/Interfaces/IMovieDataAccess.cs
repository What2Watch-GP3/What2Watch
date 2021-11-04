using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IMovieDataAccess
    {

        Task<IEnumerable<Movie>> GetAllAsync();

        Task<Movie> GetByIdAsync(int id);
            
        Task<IEnumerable<Movie>> GetByPartOfNameAsync(string searchString);


    }
}
