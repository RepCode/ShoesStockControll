using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Elipgo.ShoeStock.Api.Dtos.Responses
{
    public class StoreResponseDto: BaseResponse
    {
        public StoreResponseDto()
        {
            Success = true;
        }
        [JsonPropertyName("store")]
        public StoreDto Store { get; set; }
    }
}
