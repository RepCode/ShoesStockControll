using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Elipgo.ShoeStock.Database.Models
{
    public class Article
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("price")]
        public float Price { get; set; }
        [Column("total_in_shelf")]
        public int TotalInShelf { get; set; }
        [Column("total_in_vault")]
        public int TotalInVault { get; set; }
        [Column("store_id")]
        public int StoreId { get; set; }
        public Store Store { get; set; }
    }
}
