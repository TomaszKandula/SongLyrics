using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BackEnd.Models.Json
{

    public class Album 
    {

        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("AlbumName")]
        public string AlbumName { get; set; }

        [JsonPropertyName("Issued")]
        public DateTime Issued { get; set; }

        [JsonPropertyName("BandName")]
        public string BandName { get; set; }

    }

    public class ReturnAlbums
    {

        [JsonPropertyName("Albums")]
        public List<Album> Albums { get; set; }

        [JsonPropertyName("Error")]
        public ErrorHandler Error { get; set; }

        public ReturnAlbums()
        {
            Error = new ErrorHandler();
        }

    }

}
