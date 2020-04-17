using System.Text.Json.Serialization;

namespace Elipgo.ShoeStock.Api.Dtos.Responses
{
    public class ArticleDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
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
        [JsonPropertyName("store_name")]
        public string StoreName { get; set; }
    }
}
