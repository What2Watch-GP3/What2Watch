using System;

namespace DataAccess.Model
{
    public class Booking
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime Date { get; set; }

        public Booking(decimal TotalPrice, DateTime Date)
        {
            this.TotalPrice = TotalPrice;
            this.Date = Date;
        }


    }
}
