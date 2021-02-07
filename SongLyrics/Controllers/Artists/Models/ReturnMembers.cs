using System.Collections.Generic;
using System.Text.Json.Serialization;
using SongLyrics.Shared;

namespace SongLyrics.Controllers.Artists.Models
{
    public class ReturnMembers
    {
        [JsonPropertyName("Members")]
        public List<Member> Members { get; set; }

        [JsonPropertyName("IsSucceeded")]
        public bool IsSucceeded { get; set; }

        [JsonPropertyName("Error")]
        public ErrorHandler Error { get; set; } = new ErrorHandler();
    }
}
