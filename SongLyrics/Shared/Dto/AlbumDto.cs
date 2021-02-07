using System;
using System.Text.Json.Serialization;

namespace SongLyrics.Shared.Dto
{
    public class AlbumDto
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("AlbumName")]
        public string AlbumName { get; set; }

        [JsonPropertyName("Issued")]
        public DateTime Issued { get; set; }

        [JsonPropertyName("ArtistName")]
        public string ArtistName { get; set; }
    }
}
