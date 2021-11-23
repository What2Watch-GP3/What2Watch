using Dapper;
using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.DataAccess
{
    public class ShowDataAccess : BaseDataAccess<Show>, IShowDataAccess
    {
        public ShowDataAccess(string connectionString) : base(connectionString) 
        {
            Values = new List<string> { "start_time", "StartTime" };
        }

        public async Task<IEnumerable<Show>> GetListByMovieAndCinemaIdAsync(int movieId, int cinemaId)
        {
            string command = "SELECT Show.id, Show.start_time AS StartTime FROM Show " +
                "LEFT JOIN[Movie] ON Show.movie_id = Movie.id " +
                "LEFT JOIN[Room] ON Room.id = Show.room_id " +
                "LEFT JOIN[Cinema] ON Cinema.id = Room.cinema_id " +
                "WHERE Movie.id = @MovieId AND Cinema.id = @CinemaId";
            try
            {
                using var connection = CreateConnection();
                return await connection.QueryAsync<Show>(command, new {MovieId = movieId, CinemaId = cinemaId  });
            }
            catch (Exception ex)
            {
                throw new Exception($"Error . Error message: {ex.Message}", ex);
            }
        }
    }
}