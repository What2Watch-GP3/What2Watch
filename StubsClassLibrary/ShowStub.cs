using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StubsClassLibrary
{
    public class ShowStub : IShowDataAccess
    {
        public async Task<int> CreateAsync(Show entity)
        {
            return await Task.FromResult(1);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await Task.FromResult(true);
        }

        public async Task<IEnumerable<Show>> GetAllAsync()
        {
            IEnumerable<Show> shows = new List<Show>() 
            {
                new Show() { Id = 1, StartTime = DateTime.Now },
                new Show() { Id = 2, StartTime = DateTime.Now },
                new Show() { Id = 3, StartTime = DateTime.Now }
            };

            return await Task.FromResult(shows);
        }

        public async Task<Show> GetByIdAsync(int id)
        {
            Show show = new Show() { Id = 1, StartTime = DateTime.Now };
            return await Task.FromResult(show);
        }

        public async Task<IEnumerable<Show>> GetListByMovieAndCinemaIdAsync(int movieId, int cinemaId)
        {
            IEnumerable<Show> shows = new List<Show>()
            {
                new Show() { Id = 1, StartTime = DateTime.Now },
                new Show() { Id = 2, StartTime = DateTime.Now },
                new Show() { Id = 3, StartTime = DateTime.Now }
            };

            return await Task.FromResult(shows);
        }

        public async Task<bool> UpdateAsync(Show entity)
        {
            return await Task.FromResult(true);
        }
    }
}