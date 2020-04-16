using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elipgo.ShoeStock.Api.Dtos.Responses
{
    public class ArticlesListResponseDto: BaseResponse
    {
        public ArticlesListResponseDto()
        {
            Success = true;
        }
        [JsonProperty(PropertyName = "total_elements")]
        public int TotalElements { get; set; }
        public List<ArticleDto> Articles { get; set; }
    }
}
