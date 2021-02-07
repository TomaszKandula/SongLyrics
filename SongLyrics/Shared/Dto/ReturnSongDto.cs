using System.Text.Json.Serialization;

namespace SongLyrics.Shared.Dto
{
    public class ReturnSongDto
    {
        [JsonPropertyName("Song")]
        public SingleSongDto Song { get; set; }

        [JsonPropertyName("IsSucceeded")]
        public bool IsSucceeded { get; set; }
    }
}
