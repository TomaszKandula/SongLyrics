using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SongLyrics.Shared.Dto
{
    public class ReturnMembersDto
    {
        [JsonPropertyName("Members")]
        public List<MemberDto> Members { get; set; }

        [JsonPropertyName("IsSucceeded")]
        public bool IsSucceeded { get; set; }
    }
}
