using System.Text.Json.Serialization;
using BackEnd.Common;
using BackEnd.Models.Json;

namespace BackEnd.Controllers.Songs.Models
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

    public class ReturnSong
    {

        [JsonPropertyName("Song")]
        public SingleSong Song { get; set; }

        [JsonPropertyName("IsSucceeded")]
        public bool IsSucceeded { get; set; }

        [JsonPropertyName("Error")]
        public ErrorHandler Error { get; set; }

        public ReturnSong()
        {
            Error = new ErrorHandler();
        }

    }

}
