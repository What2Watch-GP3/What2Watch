using System;

namespace DataAccess.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime CreationTime { get; set; }
        public int SeatId { get; set; }
        public int ShowId { get; set; }
        public int UserId { get; set; }
    }
}