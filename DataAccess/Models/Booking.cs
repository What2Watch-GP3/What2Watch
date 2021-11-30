using System;

namespace DataAccess.Model
{
    public class Booking
    {
        public int Id { get; set; }
        public decimal total_price { get; set; }
        public DateTime Date { get; set; }
    }
}
