using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Seat
    {
        public int Id { get; set; }
        public int Position { get; set; }
        [Description("row_number")]
        public int RowNumber { get; set; }
        public bool IsAvailable { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
    }
}
