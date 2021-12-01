using System;
using System.ComponentModel.DataAnnotations;

namespace WebApiClient.DTOs
{
    public class ShowDto
    {
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0: dddd, dd MMMM yyyy, HH:mm}")]
        public DateTime StartTime { get; set; }


    }
}
