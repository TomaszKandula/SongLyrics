using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SongLyrics.Shared.Dto
{
    public class ReturnArtistDetailsDto
    {
        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("Established")]
        public DateTime Established { get; set; }

        [JsonPropertyName("ActiveUntil")]
        public DateTime? ActiveUntil { get; set; }

        [JsonPropertyName("Genere")]
        public string Genere { get; set; }

        [JsonPropertyName("Members")]
        public List<MemberDto> Members { get; set; }

        [JsonPropertyName("IsSucceeded")]
        public bool IsSucceeded { get; set; }
    }
}
