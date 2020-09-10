using System.Text.Json.Serialization;

namespace BackEnd.Models.Json
{

    public class SingleSong 
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
