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
            return await Task.FromResult<int>(1);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await Task.FromResult<bool>(true);
        }

        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            Movie movie = new Movie() { Id = 1, Title = "Movie1" , Duration=90};
            Movie movie2 = new Movie() { Id = 2, Title = "Movie2" , Duration = 90 };
            Movie movie3 = new Movie() { Id = 3, Title = "Movie3", Duration = 90 };
            IEnumerable<Movie> movies = new List<Movie>() { movie,movie2,movie3};
            
            return await Task.FromResult<IEnumerable<Movie>>(movies);
        }

        public async Task<Movie> GetByIdAsync(int id)
        {
            Movie movie = new Movie() { Id = id, Title = "Movie1" };

            return await Task.FromResult<Movie>(movie);
        }

        public async Task<IEnumerable<Movie>> GetListByPartOfNameAsync(string searchString)
        {
            Movie movie = new Movie() { Id = 1, Title = $"{searchString} Movie1", Duration = 90 };
            Movie movie2 = new Movie() { Id = 2, Title = $"{searchString} Movie2", Duration = 90 };
            Movie movie3 = new Movie() { Id = 3, Title = $"{searchString} Movie3", Duration = 90 };

            IEnumerable<Movie> movies = new List<Movie>() { movie, movie2, movie3 };

            return await Task.FromResult<IEnumerable<Movie>>(movies);
        }

        public async Task<bool> UpdateAsync(Movie entity)
        {
            return await Task.FromResult<bool>(true);
        }
    }
}
