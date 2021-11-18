using System;
using System.ComponentModel.DataAnnotations;

namespace WebApiClient.DTOs
{
    public class BookingDto
    {
        public int Id { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
