using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StubsClassLibrary
{
    public class ShowStub : IShowDataAccess
    {
        public async Task<int> CreateAsync(Show entity)
        {
            return await Task.FromResult<int>(1);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await Task.FromResult<bool>(true);
        }

        public async Task<IEnumerable<Show>> GetAllAsync()
        {
            DateTime time = DateTime.Now;
            Show show = new Show() { Id = 1, StartTime= time};
            Show show1 = new Show() { Id = 2, StartTime = time };
            Show show2 = new Show() { Id = 3, StartTime = time };

            IEnumerable<Show> shows = new List<Show>() {show,show1,show2 };


            return await Task.FromResult<IEnumerable<Show>>(shows);
        }

        public async Task<Show> GetByIdAsync(int id)
        {

            DateTime time = DateTime.Now;
            Show show = new Show() { Id = 1, StartTime = time };
            return await Task.FromResult<Show>(show);
        }

        public async Task<IEnumerable<Show>> GetListByMovieAndCinemaIdAsync(int movieId, int cinemaId)
        {
            DateTime time = DateTime.Now;
            Show show = new Show() { Id = 1, StartTime = time };
            Show show1 = new Show() { Id = 2, StartTime = time };
            Show show2 = new Show() { Id = 3, StartTime = time };

            IEnumerable<Show> shows = new List<Show>() { show, show1, show2 };


            return await Task.FromResult<IEnumerable<Show>>(shows);
        }

        public async Task<bool> UpdateAsync(Show entity)
        {
            return await Task.FromResult<bool>(true);
        }
    }
}
