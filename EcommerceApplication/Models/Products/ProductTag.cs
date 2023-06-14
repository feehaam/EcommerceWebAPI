using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EcommerceApplication.Models.Products
{
    public class ProductTag
    {
        [Key]
        public int ProductTagId { get; set; }
        public string Title { get; set; } = string.Empty;
        [JsonIgnore]
        public Product ? Product { get; set; }
        public int ProductId { get; set; }
    }
}
