using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApiClient.DTOs
{
    public class BookingDto
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public IEnumerable<int> ReservationIds { get; set; }
        [Required]
        public int ShowId { get; set; }
    }
}
