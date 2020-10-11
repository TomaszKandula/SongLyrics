using System.Collections.Generic;
using System.Text.Json.Serialization;
using BackEnd.Common;

namespace BackEnd.Controllers.Songs.Models
{

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
