using System.Text.Json.Serialization;
using SongLyrics.Shared;

namespace SongLyrics.Controllers.Songs.Models
{
    public class ReturnSong
    {
        [JsonPropertyName("Song")]
        public SingleSong Song { get; set; }

        [JsonPropertyName("IsSucceeded")]
        public bool IsSucceeded { get; set; }

        [JsonPropertyName("Error")]
        public ErrorHandler Error { get; set; } = new ErrorHandler();
    }
}
