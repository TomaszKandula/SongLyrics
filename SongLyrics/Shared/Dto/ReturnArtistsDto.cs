using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SongLyrics.Shared.Dto
{
    public class ReturnArtistsDto
    {
        [JsonPropertyName("Artists")]
        public List<ArtistDto> Artists { get; set; }
    }
}
