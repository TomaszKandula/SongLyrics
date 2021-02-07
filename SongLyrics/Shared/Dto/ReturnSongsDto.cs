using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SongLyrics.Shared.Dto
{
    public class ReturnSongsDto
    {
        [JsonPropertyName("Songs")]
        public List<SongDto> Songs { get; set; }
    }
}
