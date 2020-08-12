using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BackEnd.Models.Json
{

    public class ReturnBandDetails
    {

        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("Established")]
        public DateTime Established { get; set; }

        [JsonPropertyName("ActiveUntil")]
        public DateTime ActiveUntil { get; set; }

        [JsonPropertyName("Genere")]
        public string Genere { get; set; }

        [JsonPropertyName("Members")]
        public List<Member> Members { get; set; }

        [JsonPropertyName("Error")]
        public ErrorHandler Error { get; set; }

        public ReturnBandDetails()
        {
            Error = new ErrorHandler();
        }

    }

}
