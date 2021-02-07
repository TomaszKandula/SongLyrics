using System.Text.Json.Serialization;

namespace SongLyrics.Shared.Dto
{
    public class ErrorHandlerDto
    {
        [JsonPropertyName("ErrorDesc")]
        public string ErrorDesc { get; set; } = "n/a";

        [JsonPropertyName("ErrorCode")]
        public string ErrorCode { get; set; } = "no_errors_found";
    }
}
