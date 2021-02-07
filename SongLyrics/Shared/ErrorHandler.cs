using System.Text.Json.Serialization;

namespace SongLyrics.Shared
{
    public class ErrorHandler
    {
        [JsonPropertyName("ErrorDesc")]
        public string ErrorDesc { get; set; } = "n/a";

        [JsonPropertyName("ErrorCode")]
        public string ErrorCode { get; set; } = "no_errors_found";
    }
}
