﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiClient.DTOs
{
    public class SeatDto
    {
        public int Id { get; set; }
        public int Position { get; set; }
        public int RowNumber { get; set; }
        public bool IsReserved { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
    
    }
}
