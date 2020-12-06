using System.Text.Json.Serialization;

namespace SongLyrics.Controllers.Songs.Models
{

    public class Song
    {

        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("ArtistName")]
        public string ArtistName { get; set; }

        [JsonPropertyName("AlbumName")]
        public string AlbumName { get; set; }

    }

}
