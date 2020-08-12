using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BackEnd.Models.Json
{

    public class Member 
    { 
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }   
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
