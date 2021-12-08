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
            Values = new List<string> { "creation_time", "user_id", "seat_id", "show_id" };
            RawValues = new List<string> { "CreationTime", "UserId", "SeatId", "ShowId" };
        } 

        // Overload of the CreateAsync method from BaseDataAccess to accept and return IEnumerables
        public async Task<IEnumerable<int>> CreateAsync(IEnumerable<Reservation> reservations)
        {
            string command = $"INSERT INTO [Reservation] (creation_time, seat_id, show_id, user_id) OUTPUT INSERTED.Id VALUES (@CreationTime, @SeatId, @ShowId, @UserId);";
            try
            {
                List<int> listOfIds = new();
                int reservationId = 0;
                using var connection = CreateConnection();
                connection.Open();
                using var transaction = connection.BeginTransaction(IsolationLevel.RepeatableRead);
                try
                {
                    foreach (Reservation reservation in reservations) 
                    { 
                        reservationId = await connection.QuerySingleAsync<int>(command, reservation, transaction);
                        listOfIds.Add(reservationId);
                    }
                    transaction.Commit();
                    return listOfIds;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception($"Error during async creation of 'Reservation' with id '{reservationId}'!\nMessage was: '{ex.Message}'\nTable Name: Reservation\nCommand: {command}", ex);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error during establishing connection. Message was '{ex.Message}'", ex);
            }
        }
    }
}
