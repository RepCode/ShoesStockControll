using System;
using System.Text.Json.Serialization;

namespace Elipgo.ShoeStock.Api.Dtos.Responses
{
    public class LoginResponseDto: BaseResponse
    {
        public LoginResponseDto()
        {
            Success = true;
        }
        [JsonPropertyName("user")]
        public UserDto User { get; set; }
    }
}
