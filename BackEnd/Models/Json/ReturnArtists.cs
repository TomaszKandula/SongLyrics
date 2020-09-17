using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BackEnd.Models.Json
{

    public class Artist 
    {

        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }

    }

    public class ReturnArtists
    {

        [JsonPropertyName("Artists")]
        public List<Artist> Artists { get; set; }

        [JsonPropertyName("IsSucceeded")]
        public bool IsSucceeded { get; set; }

        [JsonPropertyName("Error")]
        public ErrorHandler Error { get; set; }

        public ReturnArtists()
        {
            Error = new ErrorHandler();
        }

    }

}
