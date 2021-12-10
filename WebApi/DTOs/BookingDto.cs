using System;
using System.Collections.Generic;

namespace WebApi.DTOs
{
    public class BookingDto
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public int ShowId { get; set; }
    }
}
