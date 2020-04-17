using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Elipgo.ShoeStock.Api.Dtos.Responses
{
    public class StoresListResponseDto: BaseResponse
    {
        public StoresListResponseDto()
        {
            Success = true;
        }
        [JsonPropertyName("total_elements")]
        public int TotalElements { get; set; }
        [JsonPropertyName("stores")]
        public List<StoreDto> Stores { get; set; }
    }
}
