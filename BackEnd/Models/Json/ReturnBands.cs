using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BackEnd.Models.Json
{

    public class Band 
    {

        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }

    }

    public class ReturnBands
    {

        [JsonPropertyName("Bands")]
        public List<Band> Bands { get; set; }

        [JsonPropertyName("Error")]
        public ErrorHandler Error { get; set; }

        public ReturnBands()
        {
            Error = new ErrorHandler();
        }

    }

}
