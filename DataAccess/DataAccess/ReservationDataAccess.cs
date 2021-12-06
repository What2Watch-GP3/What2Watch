using Dapper;
using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DataAccess.DataAccess
{
    public class ReservationDataAccess : BaseDataAccess<Reservation>, IReservationDataAccess
    {
        public ReservationDataAccess(string connectionstring) : base(connectionstring)
        {
            Values = new List<string> { "time_stamp", "user_id", "seat_id", "show_id" };
            RawValues = new List<string> { "TimeStamp", "UserId", "SeatId", "ShowId" };
        } 

        override public async Task<int> CreateAsync(Reservation reservation)
        {
            string command = $"INSERT INTO [Reservation] (time_stamp, seat_id, show_id, user_id) OUTPUT INSERTED.Id VALUES (@TimeStamp, @SeatId, @ShowId, @UserId);";
            
            try
            {
                using var connection = CreateConnection();
                connection.Open();
                using var transaction = connection.BeginTransaction(IsolationLevel.RepeatableRead);
                try
                {
                    int reservationId = await connection.QuerySingleAsync<int>(command, reservation, transaction);
                    transaction.Commit();
                    return reservationId;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception($"Error during async creation of 'Reservation'!\nMessage was: '{ex.Message}'\nTable Name: Reservation\nCommand: {command}", ex);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error during establishing connection. Message was '{ex.Message}'", ex);
            }
        }
    }
}
