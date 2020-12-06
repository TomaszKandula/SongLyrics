using System.Text.Json.Serialization;

namespace SongLyrics.Controllers.Songs.Models
{

    public class SingleSong
    {

        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("Url")]
        public string Url { get; set; }

        [JsonPropertyName("Lyrics")]
        public string Lyrics { get; set; }

        [JsonPropertyName("ArtistName")]
        public string ArtistName { get; set; }

        [JsonPropertyName("AlbumName")]
        public string AlbumName { get; set; }

    }

}
