using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DataAccess.Models
{
    public class Booking
    {
        public int Id { get; set; }
        [Description("total_price")]
        public decimal TotalPrice { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public IEnumerable<Ticket> Tickets { get; set; }
    }
}
