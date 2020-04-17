using System.Text.Json.Serialization;

namespace Elipgo.ShoeStock.Api.Dtos.Responses
{
    public class ErrorResponse: BaseResponse
    {
        public ErrorResponse()
        {
            Success = false;
        }
        [JsonPropertyName("error_code")]
        public int ErrorCode { get; set; }
        [JsonPropertyName("error_message")]
        public string ErrorMessage { get; set; }
    }
}
