using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BackEnd.Models.Json
{

    public class Song 
    {

        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("Url")]
        public string Url { get; set; }

        [JsonPropertyName("Lyrics")]
        public string Lyrics { get; set; }

        [JsonPropertyName("BandName")]
        public string BandName { get; set; }

        [JsonPropertyName("AlbumName")]
        public string AlbumName { get; set; }

    }

    public class ReturnSongs
    {

        [JsonPropertyName("Songs")]
        public List<Song> Songs { get; set; }

        [JsonPropertyName("Error")]
        public ErrorHandler Error { get; set; }

        public ReturnSongs()
        {
            Error = new ErrorHandler();
        }

    }

}
