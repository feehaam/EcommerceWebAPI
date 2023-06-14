using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EcommerceApplication.Models.Products
{
    public class Variant
    {
        [Key]
        public int VariantId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string PhotoURL { get; set; } = string.Empty;
        public double Price { get; set; }

        // Parent reference
        public int ProductId { get; set; }
        [JsonIgnore]
        public virtual Product ? Product { get; set; }
    }
}
