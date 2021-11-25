using System;

namespace WebApi.DTOs
{
    public class ShowDto
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public int MovieId { get; set; }
        public int RoomId { get; set; }
    }
}
