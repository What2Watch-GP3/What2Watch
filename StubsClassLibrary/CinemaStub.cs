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
            return await Task.FromResult(1);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await Task.FromResult(true);
        }

        public async Task<IEnumerable<Cinema>> GetAllAsync()
        {
            IEnumerable<Cinema> cinemas = new List<Cinema>() {
                new Cinema() { Id = 1, Name = "Cinema 1" },
                new Cinema() { Id = 2, Name = "Cinema 2" },
                new Cinema() { Id = 3, Name = "Cinema 3" }
            };

            return await Task.FromResult(cinemas);
        }

        public async Task<Cinema> GetByIdAsync(int id)
        {
            Cinema cinema = new Cinema() { Id = id, Name = "Cinema 1" };

            return await Task.FromResult(cinema);
        }

        public async Task<IEnumerable<Cinema>> GetListByMovieIdAsync(int movieId)
        {
            IEnumerable<Cinema> cinemas = new List<Cinema>() {
                new Cinema() { Id = 1, Name = "Cinema 1" },
                new Cinema() { Id = 2, Name = "Cinema 2" },
                new Cinema() { Id = 3, Name = "Cinema 3" }
            };

            return await Task.FromResult(cinemas);
        }

        public async Task<bool> UpdateAsync(Cinema entity)
        {
            return await Task.FromResult(true);
        }
    }
}