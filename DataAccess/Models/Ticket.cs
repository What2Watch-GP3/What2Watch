using System;
using System.ComponentModel;

namespace DataAccess.Models
{
    public class Ticket 
    {
        [Description("seat_id")]
        public int SeatId { get; set; }
        [Description("show_id")]
        public int ShowId { get; set; }
        [Description("user_id")]
        public int UserId { get; set; }
        [Description("creation_time")]
        public DateTime CreationTime { get; set; }

    }
}