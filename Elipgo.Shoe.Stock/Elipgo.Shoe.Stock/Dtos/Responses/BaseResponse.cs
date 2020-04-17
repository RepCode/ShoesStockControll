using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Elipgo.ShoeStock.Api.Dtos.Responses
{
    public class BaseResponse
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }
    }
}
