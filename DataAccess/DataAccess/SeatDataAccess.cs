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
    public class SeatDataAccess : BaseDataAccess<Seat>, ISeatDataAccess
    {
        public SeatDataAccess(string connectionString) : base(connectionString)
        {
        }
        public async Task<IEnumerable<Seat>> GetAllByRoomIdAsync(int roomId)
        {            
            string command = $"SELECT * FROM [Seat] WHERE room_id = @Id;";
            try
            {
                using var connection = CreateConnection();
                return await connection.QueryAsync<Seat>(command, new { Id = roomId});
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting all async of '{typeof(Seat).Name}'!\nMessage was: '{ex.Message}'\nCommand: {command}", ex);
            }
        }

    }
}
