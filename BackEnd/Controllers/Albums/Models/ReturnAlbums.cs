using System.Collections.Generic;
using System.Text.Json.Serialization;
using BackEnd.Shared;

namespace BackEnd.Controllers.Albums.Models
{

    public class ReturnAlbums
    {

        [JsonPropertyName("Albums")]
        public List<Album> Albums { get; set; }

        [JsonPropertyName("IsSucceeded")]
        public bool IsSucceeded { get; set; }

        [JsonPropertyName("Error")]
        public ErrorHandler Error { get; set; }

        public ReturnAlbums()
        {
            Error = new ErrorHandler();
        }

    }

}
