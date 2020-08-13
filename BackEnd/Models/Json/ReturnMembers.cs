using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BackEnd.Models.Json
{

    public class Member 
    {

        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("FirstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("LastName")]
        public string LastName { get; set; }

        [JsonPropertyName("Status")]
        public string Status { get; set; }

    }

    public class ReturnMembers
    {

        [JsonPropertyName("Members")]
        public List<Member> Members { get; set; }

        [JsonPropertyName("Error")]
        public ErrorHandler Error { get; set; }

        public ReturnMembers()
        {
            Error = new ErrorHandler();
        }

    }

}
