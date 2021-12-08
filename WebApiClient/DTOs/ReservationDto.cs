using System;

namespace WebApiClient.DTOs
{
    public class ReservationDto
    {
        public int Id { get; set; }
        public DateTime CreationTime { get; set; }
        public int SeatId { get; set; }
        public string SeatPosition { get; set; }
        public int ShowId { get; set; }
        public int UserId { get; set; }
    }
}