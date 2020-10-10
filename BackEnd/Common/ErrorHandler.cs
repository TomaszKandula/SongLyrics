using System.Text.Json.Serialization;

namespace BackEnd.Common
{

    public class ErrorHandler
    {

        [JsonPropertyName("ErrorDesc")]
        public string ErrorDesc { get; set; }

        [JsonPropertyName("ErrorCode")]
        public string ErrorCode { get; set; }

        public ErrorHandler()
        {
            ErrorDesc = "n/a";
            ErrorCode = "no_errors_found";
        }

    }

}
