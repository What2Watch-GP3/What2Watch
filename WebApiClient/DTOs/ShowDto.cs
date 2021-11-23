using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiClient.DTOs
{
    public class ShowDto
    {
        public int Id { get; set; }


        [DisplayFormat(DataFormatString = "{0:dddd, dd MMMM yyyy}")]
        public DateTime StartTime { get; set; }

        
    }
}
