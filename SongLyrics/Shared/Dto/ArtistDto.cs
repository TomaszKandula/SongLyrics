using System.Text.Json.Serialization;

namespace SongLyrics.Shared.Dto
{
    public class ArtistDto
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }
    }
}
