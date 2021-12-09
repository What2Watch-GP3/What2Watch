using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DataAccess.Interfaces;
using DataAccess.Models;

namespace DataAccess.DataAccess
{
    public class TicketDataAccess : BaseDataAccess<Ticket>, ITicketDataAccess
    {
        public TicketDataAccess(string connectionString) : base(connectionString) { }

        public Task<Ticket> GetByTicketIdAsync(int showId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Ticket>> GetListTicketsIdAsync(int movieId)
        {
            string command = "SELECT DISTINCT Cinema.id, Cinema.[name] FROM Cinema " +
                "LEFT JOIN [Room] ON Cinema.id = Room.cinema_id " +
                "LEFT JOIN [Show] ON Room.id = Show.room_id " +
                "LEFT JOIN [Movie] ON Show.movie_id = Movie.id " +
                "WHERE Movie.id = @MovieId";
            try
            {
                using var connection = CreateConnection();
                //return await connection.QueryAsync<Ticket>(command, new { TicketId = ticketId });
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting List of Cinemas by selected Movie id {movieId}. Error: {ex.Message}", ex);
            }
        }
    }
}
