using Dapper;
using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.DataAccess
{
    public class CinemaDataAccess : BaseDataAccess<Cinema>, ICinemaDataAccess
    {
        public CinemaDataAccess(string connectionString) : base(connectionString)
        {
        }
        public async Task<IEnumerable<Cinema>> GetListByMovieIdAsync(int movieId)
        {
            string command = "SELECT DISTINCT Cinema.id, Cinema.[name] FROM Cinema " +
                "LEFT JOIN [Room] ON Cinema.id = Room.cinema_id " +
                "LEFT JOIN [Show] ON Room.id = Show.room_id " +
                "LEFT JOIN [Movie] ON Show.movie_id = Movie.id " +
                "WHERE Movie.id = @MovieId";
            try
            {
                using var connection = CreateConnection();
                return await connection.QueryAsync<Cinema>(command, new { MovieId = movieId });
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting List of Cinemas by selected Movie id {movieId}. Error: {ex.Message}", ex);
            }
        }
    }
}
