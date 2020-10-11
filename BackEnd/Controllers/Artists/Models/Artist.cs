using System.Text.Json.Serialization;

namespace BackEnd.Controllers.Artists.Models
{

    public class Artist
    {

        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }

    }

}
