using System;
using System.ComponentModel.DataAnnotations;
using Tools.Enums;

namespace WebApiClient.DTOs
{
    public class ShowDto
    {
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0: dddd, dd MMMM yyyy, HH:mm}")]
        public DateTime StartTime { get; set; }
        public Language DubLanguage { get; set; }
        public Language SubtitlesLanguage { get; set; }
        public GraphicType GraphicType { get; set; }
        public SoundType SoundType { get; set; }

    }
}
