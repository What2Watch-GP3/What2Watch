using System.ComponentModel;

namespace DataAccess.Models
{
    public class Ticket 
    {
        public int Id { get; set; }
        [Description("Seat_Id")]
        public int SeatId { get; set; }
        [Description("Show_Id")]
        public int ShowId { get; set; }
    }
}