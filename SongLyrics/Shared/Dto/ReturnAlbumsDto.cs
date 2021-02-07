using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SongLyrics.Shared.Dto
{
    public class ReturnAlbumsDto
    {
        [JsonPropertyName("Albums")]
        public List<AlbumDto> Albums { get; set; }

        [JsonPropertyName("IsSucceeded")]
        public bool IsSucceeded { get; set; }
    }
}
