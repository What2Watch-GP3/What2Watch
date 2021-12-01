using Dapper;
using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.DataAccess
{
    public class MovieDataAccess : BaseDataAccess<Movie>, IMovieDataAccess

    {
        public MovieDataAccess(string connectionString) : base(connectionString)
        {
        }

        public async Task<IEnumerable<Movie>> GetListByPartOfNameAsync(string searchString)
        {
            IEnumerable<Movie> movies;
            string command = $"SELECT * FROM Movie WHERE title LIKE @SearchString";
            try
            {
                using var connection = CreateConnection();
                movies = await connection.QueryAsync<Movie>(command, new { SearchString = $"%{searchString}%" });

                return movies;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting certain movies by part of name, by searchstring {searchString}. Error message: {ex.Message}", ex);
            }
        }
    }
}
