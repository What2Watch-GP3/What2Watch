using System;
using Tools.Enums;

namespace WebApi.DTOs
{
    public class ShowDto
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public int MovieId { get; set; }
        public int RoomId { get; set; }
        public Language DubLanguage { get; set; }
        public Language SubtitlesLanguage { get; set; }
        public GraphicType GraphicType { get; set; }
        public SoundType SoundType { get; set; }
    }
}
