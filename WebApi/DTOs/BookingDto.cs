using System;

namespace WebApi.DTOs
{
    public class BookingDto
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime Date { get; set; }
    }
}
