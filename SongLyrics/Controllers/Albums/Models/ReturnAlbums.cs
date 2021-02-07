using System.Collections.Generic;
using System.Text.Json.Serialization;
using SongLyrics.Shared;

namespace SongLyrics.Controllers.Albums.Models
{
    public class ReturnAlbums
    {
        [JsonPropertyName("Albums")]
        public List<Album> Albums { get; set; }

        [JsonPropertyName("IsSucceeded")]
        public bool IsSucceeded { get; set; }

        [JsonPropertyName("Error")]
        public ErrorHandler Error { get; set; } = new ErrorHandler();
    }
}
