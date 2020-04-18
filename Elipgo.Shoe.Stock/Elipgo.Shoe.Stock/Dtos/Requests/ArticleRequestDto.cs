using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Elipgo.ShoeStock.Api.Dtos.Requests
{
    public class ArticleRequestDto
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("price")]
        public float Price { get; set; }
        [JsonPropertyName("total_in_shelf")]
        public int TotalInShelf { get; set; }
        [JsonPropertyName("total_in_vault")]
        public int TotalInVault { get; set; }
        [JsonPropertyName("store_id")]
        public int StoreId { get; set; }
    }
}
