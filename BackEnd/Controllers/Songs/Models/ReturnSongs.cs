using System.Collections.Generic;
using System.Text.Json.Serialization;
using BackEnd.Common;

namespace BackEnd.Controllers.Songs.Models
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

    public class ReturnSongs
    {

        [JsonPropertyName("Songs")]
        public List<Song> Songs { get; set; }

        [JsonPropertyName("IsSucceeded")]
        public bool IsSucceeded { get; set; }

        [JsonPropertyName("Error")]
        public ErrorHandler Error { get; set; }

        public ReturnSongs()
        {
            Error = new ErrorHandler();
        }

    }

}
