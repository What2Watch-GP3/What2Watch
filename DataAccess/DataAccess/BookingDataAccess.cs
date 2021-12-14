using Dapper;
using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tools.Converters;

namespace DataAccess.DataAccess
{
    public class BookingDataAccess : BaseDataAccess<Booking>, IBookingDataAccess
    {
        public BookingDataAccess(string connectionstring) : base(connectionstring)
        {
            Values = new List<string> { "total_price", "date" };
        }

        override public async Task<int> CreateAsync(Booking entity)
        {
            try
            {
                using var connection = CreateConnection();
                connection.Open();
                // Start transaction
                using var transaction = connection.BeginTransaction();
                try
                {
                    //took out reservations from Booking transaction for 1. lower coupling 2. faster transaction. Reading a reservation is not a problem.
                    // Get Reservations from DB based on Booking.ReservationIds
                    //string command = $"SELECT * FROM [Reservation] WHERE user_id = @UserId AND show_id = @ShowId";
                    //IEnumerable<Reservation> reservations = await connection.QueryAsync<Reservation>(command, new { UserId = entity.UserId, ShowId = entity.Tickets.FirstOrDefault().ShowId }, transaction);

                    // Turn Reservation Objects into Ticket Objects
                    //IEnumerable<Ticket> tickets = DtoConverter<Reservation, Ticket>.FromList(reservations);

                    // Put Booking DB
                    string command = $"INSERT INTO [Booking] (total_price, date, user_id) OUTPUT INSERTED.Id VALUES (@TotalPrice, @Date, @UserId);";
                    int bookingId = await connection.QuerySingleAsync<int>(command, new { TotalPrice = entity.TotalPrice, Date = entity.Date, UserId = entity.UserId }, transaction);


                    // Put Tickets in DB
                    command = $"INSERT INTO [Ticket] (creation_time, seat_id, show_id, booking_id) VALUES (@CreationTime, @SeatId, @ShowId, @BookingId);";
                    foreach (Ticket ticket in entity.Tickets)
                    {
                        bool isCreated = await connection.ExecuteAsync(command, new { CreationTime = ticket.CreationTime, SeatId = ticket.SeatId, ShowId = ticket.ShowId, bookingId}, transaction) > 0;
                        if (!isCreated)
                        {
                            transaction.Rollback();
                            return -1;
                        }
                    }
                    
                    // TODO: make it set user id and date to null

                    // Delete Reservations
                    //command = $"DELETE FROM [Reservation] WHERE seat_id=@SeatId AND show_id=@ShowId;";
                    //foreach (Ticket reservation in entity.Tickets)
                    //{
                    //    // Put Tickets in DB, Put Booking DB
                    //    bool isDeleted = await connection.ExecuteAsync(command, new { SeatId = reservation.SeatId, ShowId = reservation.ShowId }, transaction) > 0;
                    //    if (!isDeleted)
                    //    {
                    //        transaction.Rollback();
                    //        return -1;
                    //    }
                    //}
                    // Commit
                    transaction.Commit();
                    return bookingId;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception($"Error during async creation of 'Booking'!\nMessage was: '{ex.Message}'", ex);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error during establishing connection. Message was '{ex.Message}'", ex);
            }
        }
    }
}
