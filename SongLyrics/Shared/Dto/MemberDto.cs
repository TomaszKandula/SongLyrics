using System.Text.Json.Serialization;

namespace SongLyrics.Shared.Dto
{
    public class MemberDto
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("FirstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("LastName")]
        public string LastName { get; set; }

        [JsonPropertyName("Status")]
        public string Status { get; set; }
    }
}
