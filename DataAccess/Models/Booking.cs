using System;

namespace DataAccess.Model
{
    public class Booking
    {
        public decimal TotalPrice { get; set; };
        public DateTime Date { get; set; };

        public Booking(decimal TotalPrice, DateTime Date)
        {
            this.TotalPrice = TotalPrice;
            this.Date = Date;
        }


    }
}
