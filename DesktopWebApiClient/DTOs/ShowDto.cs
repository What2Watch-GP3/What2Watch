using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Enums;

namespace DesktopApiClient.DTOs
{
    public class ShowDto
    {
        public DateTime StartTime { get; set; }
        public int RoomId { get; set; }
        public int MovieId { get; set; }
        public Language DubLanguage { get; set; }
        public Language SubtitlesLanguage { get; set; }
        public GraphicType GraphicType { get; set; }
        public SoundType SoundType { get; set; }
    }
}
