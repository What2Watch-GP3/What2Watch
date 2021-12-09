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
            Values = new List<string> { "start_time", "movie_id", "room_id", "dub_language", "subtitles_language", "graphic_type", "sound_type" };
        }

        public Task<Show> GetByShowIdAsync(int showId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Show>> GetListByMovieAndCinemaIdAsync(int movieId, int cinemaId)
        {
            string command = "SELECT Show.id, Show.start_time AS StartTime, Show.dub_language AS DubLanguage, Show.subtitles_language AS SubtitlesLanguage, Show.graphic_type AS GraphicType, Show.sound_type AS SoundType FROM Show " +
                "LEFT JOIN[Movie] ON Show.movie_id = Movie.id " +
                "LEFT JOIN[Room] ON Room.id = Show.room_id " +
                "LEFT JOIN[Cinema] ON Cinema.id = Room.cinema_id " +
                "WHERE Movie.id = @MovieId AND Cinema.id = @CinemaId";
            try
            {
                using var connection = CreateConnection();
                return await connection.QueryAsync<Show>(command, new { MovieId = movieId, CinemaId = cinemaId });
            }
            catch (Exception ex)
            {
                throw new Exception($"Error . Error message: {ex.Message}", ex);
            }
        }
    }
}