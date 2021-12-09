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

        public async Task<IEnumerable<Ticket>> GetTicketsByShowIdAsync(int showId)
        {
            string command = "SELECT * FROM Ticket WHERE Show_id=@Showid";
            try
            {
                using var connection = CreateConnection();
                return await connection.QueryAsync<Ticket>(command, new { ShowId = showId });
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting List of Tickets by selected Show id {showId}. Error: {ex.Message}", ex);
            }
        }
    }
}
