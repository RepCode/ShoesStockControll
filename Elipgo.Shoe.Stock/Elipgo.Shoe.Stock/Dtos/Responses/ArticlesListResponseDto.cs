using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Elipgo.ShoeStock.Api.Dtos.Responses
{
    public class ArticlesListResponseDto: BaseResponse
    {
        public ArticlesListResponseDto()
        {
            Success = true;
        }
        [JsonPropertyName("total_elements")]
        public int TotalElements { get; set; }
        [JsonPropertyName("articles")]
        public List<ArticleDto> Articles { get; set; }
    }
}
