using System.Collections.Generic;

namespace DataAccess.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public IEnumerable<Seat> Seats { get; set; }
    }
}
