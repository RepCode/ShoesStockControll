using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elipgo.ShoeStock.Api.Dtos.Responses
{
    public class StoresListResponseDto: BaseResponse
    {
        public StoresListResponseDto()
        {
            Success = true;
        }
        [JsonProperty(PropertyName = "total_elements")]
        public int TotalElements { get; set; }
        public List<StoreDto> Stores { get; set; }
    }
}
