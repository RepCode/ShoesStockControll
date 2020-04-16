using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elipgo.ShoeStock.Api.Dtos.Responses
{
    public class ArticleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        [JsonProperty(PropertyName = "total_in_shelf")]
        public int TotalInShelf { get; set; }
        [JsonProperty(PropertyName = "total_in_vault")]
        public int TotalInVault { get; set; }
        [JsonProperty(PropertyName = "store_name")]
        public string StoreName { get; set; }
    }
}
