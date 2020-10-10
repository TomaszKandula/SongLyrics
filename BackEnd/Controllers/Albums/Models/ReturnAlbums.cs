using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using BackEnd.Common;

namespace BackEnd.Controllers.Albums.Models
{

    public class Album 
    {

        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("AlbumName")]
        public string AlbumName { get; set; }

        [JsonPropertyName("Issued")]
        public DateTime Issued { get; set; }

        [JsonPropertyName("ArtistName")]
        public string ArtistName { get; set; }

    }

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
