using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiClient.DTOs
{
    public class SeatDto
    {
        public int Number { get; set; }
        public int Row { get; set; }
        public bool IsAvailable { get; set; }
    }
}
