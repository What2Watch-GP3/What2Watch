using DataAccess.Interfaces;
using DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StubsClassLibrary
{
    public class CinemaStub : ICinemaDataAccess
    {
        public async Task<int> CreateAsync(Cinema entity)
        {
            return await Task.FromResult<int>(1);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await Task.FromResult<bool>(true);
        }

        public async Task<IEnumerable<Cinema>> GetAllAsync()
        {
            Cinema cinema = new Cinema() { Id = 1, Name = "Cinema 1" };
            Cinema cinema2 = new Cinema() { Id = 2, Name = "Cinema 2" };
            Cinema cinema3 = new Cinema() { Id = 3, Name = "Cinema 3" };

            IEnumerable<Cinema> cinemas = new List<Cinema>() { cinema, cinema2, cinema3 };

            return await Task.FromResult<IEnumerable<Cinema>>(cinemas);
        }

        public async Task<Cinema> GetByIdAsync(int id)
        {
            Cinema cinema = new Cinema() { Id = id, Name = "Cinema 1" };

            return await Task.FromResult<Cinema>(cinema);
        }

        public async Task<IEnumerable<Cinema>> GetListByMovieIdAsync(int movieId)
        {
            Cinema cinema = new Cinema() { Id = 1, Name = "Cinema 1" };
            Cinema cinema2 = new Cinema() { Id = 2, Name = "Cinema 2" };
            Cinema cinema3 = new Cinema() { Id = 3, Name = "Cinema 3" };

            IEnumerable<Cinema> cinemas = new List<Cinema>() { cinema, cinema2, cinema3 };

            return await Task.FromResult<IEnumerable<Cinema>>(cinemas);
        }

        public async Task<bool> UpdateAsync(Cinema entity)
        {
            return await Task.FromResult<bool>(true);
        }
    }
}
