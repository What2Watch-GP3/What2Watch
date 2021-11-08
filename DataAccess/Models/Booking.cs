using System;

namespace DataAccess.Model
{
    public class Booking
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime Date { get; set; }
    }
}
