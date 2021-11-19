using Dapper;
using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataAccess
{
    public class ShowDataAccess : BaseDataAccess<Show>, IShowDataAccess
    {

        public ShowDataAccess(string connectionString) : base(connectionString)
        {

        }
        

        public async Task<IEnumerable<Show>> GetListByMovieAndCinemaIdAsync(int movieId, int cinemaId)
        {
            IEnumerable<Show> shows;
            string command = "SELECT Show.id, Show.start_time FROM Show " +
                "LEFT JOIN[Movie] ON Show.movie_id = Movie.id " +
                "LEFT JOIN[Room] ON Room.id = Show.room_id " +
                "LEFT JOIN[Cinema] ON Cinema.id = Room.cinema_id " +
                "WHERE Movie.id = @MovieId AND Cinema.id = @CinemaId";
            try
            {
                using var connection = CreateConnection();
                shows = await connection.QueryAsync<Show>(command, new {MovieId = movieId, CinemaId = cinemaId  });

                return shows;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error . Error message: {ex.Message}", ex);
            }
        }
    }
}
