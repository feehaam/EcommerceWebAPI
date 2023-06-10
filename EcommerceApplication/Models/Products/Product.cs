using EcommerceApplication.Models.Products;
using System.ComponentModel.DataAnnotations;

namespace EcommerceApplication.Models.Products
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public float Price { get; set; }
        public Category ? Category { get; set; }
        public ICollection<Tag> ? Tags { get; set; }
        public string? PhotosURL1 { get; set; }
        public string? PhotosURL2 { get; set; }
        public string? PhotosURL3 { get; set; }
        public int AvailableQuantity { get; set; }
        public ICollection<Variant>? Variants { get; set; }
        public Statistics ? Statistics { get; set; }
    }
}
