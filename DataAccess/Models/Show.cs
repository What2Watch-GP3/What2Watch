using System;

namespace DataAccess.Models
{
    public class Show
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public int MovieId { get; set; }
        public int RoomId { get; set; }
        public string DubLanguage { get; set; }
        public string SubtitlesLanguage { get; set; }
        public string GraphicType { get; set; }
        public string SoundType { get; set; }
    }
}
