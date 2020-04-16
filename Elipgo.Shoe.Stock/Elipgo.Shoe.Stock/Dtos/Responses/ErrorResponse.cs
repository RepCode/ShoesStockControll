using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elipgo.ShoeStock.Api.Dtos.Responses
{
    public class ErrorResponse: BaseResponse
    {
        public ErrorResponse()
        {
            Success = false;
        }
        [JsonProperty(PropertyName = "error_code")]
        public int ErrorCode { get; set; }
        [JsonProperty(PropertyName = "error_message")]
        public string ErrorMessage { get; set; }
    }
}
