using System.Text.Json.Serialization;

namespace SongLyrics.Controllers.Artists.Models
{
    public class Member
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
