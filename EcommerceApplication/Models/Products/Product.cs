using Azure;
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
        public DateTime Created { get; set; }
        public Category ? Category { get; set; }
        public ICollection<ProductTag> ? Tags { get; set; }
        public string? PhotosURL1 { get; set; }
        public string? PhotosURL2 { get; set; }
        public string? PhotosURL3 { get; set; }
        public int AvailableQuantity { get; set; }
        public ICollection<Variant>? Variants { get; set; }
        public Statistics ? Statistics { get; set; }

        public bool HasTag(string tag)
        {
            if (tag == null || tag.Length == 0) return true;
            if (Tags == null || Tags.Count == 0) return false;
            foreach(ProductTag t in Tags)
            {
                if(t.Title.ToLower().Equals(tag.ToLower())) return true;
            }
            return false;
        }

        public bool HasVariant(string variantName)
        {
            if (variantName == null || variantName.Length == 0) return true;
            if (Variants == null || Variants.Count == 0) return false;
            foreach (Variant v in Variants)
            {
                if (v.Title.ToLower().Equals(variantName.ToLower())) return true;
            }
            return false;
        }
    }
}
