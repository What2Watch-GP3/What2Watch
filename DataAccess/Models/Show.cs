using System;

namespace DataAccess.Models
{
    public class Show
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public int MovieId { get; set; }
        public int RoomId { get; set; }
    }
}
