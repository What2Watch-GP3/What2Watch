using DataAccess.Interfaces;
using DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StubsClassLibrary
{
    public class MovieStub : IMovieDataAccess
    {
        public async Task<int> CreateAsync(Movie entity)
        {
            return await Task.FromResult(1);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await Task.FromResult(true);
        }

        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            IEnumerable<Movie> movies = new List<Movie>()
            {
                new Movie() { Id = 1, Title = "Movie1" , Duration=90},
                new Movie() { Id = 2, Title = "Movie2" , Duration = 90 },
                new Movie() { Id = 3, Title = "Movie3", Duration = 90 }
            };
            
            return await Task.FromResult(movies);
        }

        public async Task<Movie> GetByIdAsync(int id)
        {
            Movie movie = new Movie() { Id = id, Title = "Movie1" };

            return await Task.FromResult(movie);
        }

        public async Task<IEnumerable<Movie>> GetListByPartOfNameAsync(string searchString)
        {
            IEnumerable<Movie> movies = new List<Movie>()
            {
                new Movie() { Id = 1, Title = $"Movie1{searchString}", Duration = 90 },
                new Movie() { Id = 2, Title = $"Movie2{searchString}", Duration = 90 },
                new Movie() { Id = 3, Title = $"Movie3{searchString}", Duration = 90 }
            };

            return await Task.FromResult(movies);
        }

        public async Task<bool> UpdateAsync(Movie entity)
        {
            return await Task.FromResult(true);
        }
    }
}
