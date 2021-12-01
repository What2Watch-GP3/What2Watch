using System.Collections.Generic;

namespace DataAccess.Models
{
    public class Cinema
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Room> Rooms { get; set; }
    }
}
