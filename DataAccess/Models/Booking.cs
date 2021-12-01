using System;
using System.ComponentModel;

namespace DataAccess.Model
{
    public class Booking
    {
        public int Id { get; set; }
        [Description("total_price")]
        public decimal TotalPrice { get; set; }
        public DateTime Date { get; set; }
    }
}
